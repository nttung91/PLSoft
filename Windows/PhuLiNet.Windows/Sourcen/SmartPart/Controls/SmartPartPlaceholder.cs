using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Windows.Core.SmartPart.Utility;

namespace Windows.Core.SmartPart.Controls
{
    /// <summary>
    /// A <see cref="Control"/> that acts as a placeholder for a smartpart.
    /// </summary>
    [DesignerCategory("Code")]
    [ToolboxBitmap(typeof (SmartPartPlaceholder), "SmartPartPlaceholder")]
    public class SmartPartPlaceholder : Control, ISmartPartPlaceholder
    {
        private ISmartPart _smartPart;
        private string _placeholderName;

        /// <summary>
        /// Fires when a smartpart is shown in the placeholder.
        /// </summary>
        public event EventHandler<SmartPartPlaceholderEventArgs> SmartPartShown;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartPartPlaceholder"/> class.
        /// </summary>
        public SmartPartPlaceholder()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the default name for the PlaceholderName
        /// </summary>
        public string PlaceholderName
        {
            get { return _placeholderName; }
            set
            {
                _placeholderName = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a reference to the smartpart after it has been added.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISmartPart SmartPart
        {
            get { return _smartPart; }
            set
            {
                bool activeAlready = false;

                Guard.ArgumentNotNull(value, "value");
                if (value.Control is Control == false)
                {
                    throw new ArgumentException(Localization.SmartPart.SmartPartNotControl);
                }

                if (_smartPart != null && _smartPart.Key == value.Key)
                {
                    activeAlready = true;
                    Debug.Assert(false, string.Format("The SmartPart [{0}] is active already.", value.Key));
                }

                if (!activeAlready)
                {
                    RemoveSmartPart();
                    _smartPart = value;

                    //init smart part
                    if (!_smartPart.InitDone)
                        _smartPart.Init();

                    var spcontrol = (Control) _smartPart.Control;
                    spcontrol.Dock = DockStyle.Fill;
                    spcontrol.Show();
                    Controls.Clear();
                    Controls.Add(spcontrol);
                }

                OnSmartPartShown(_smartPart);
            }
        }

        /// <summary>
        /// Removes the current SmartPart from the placeholder
        /// </summary>
        public void RemoveSmartPart()
        {
            if (_smartPart != null && _smartPart.Control is Control)
            {
                //A previous smartpart exists
                var ctrl = _smartPart.Control as Control;
                ctrl.Hide();
                //Deinit smart part
                _smartPart.Deinit();
                _smartPart = null;

                Controls.Clear();
            }
        }

        #endregion

        private void OnSmartPartShown(ISmartPart smartPartShown)
        {
            if (SmartPartShown != null)
            {
                SmartPartShown(this, new SmartPartPlaceholderEventArgs(smartPartShown));
            }
        }

        #region Protected

        /// <summary>
        /// Paints a border at design time.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!DesignMode)
                return;

            using (var p = new Pen(ForeColor))
            using (Brush b = new SolidBrush(ForeColor))
            {
                Rectangle r = ClientRectangle;
                r.Height -= 1;
                r.Width -= 1;

                p.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(p, r);
                e.Graphics.DrawString(PlaceholderName, Font, b, r.X + 2, r.Y + 2);
            }
        }

        #endregion

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);
        }
    }
}