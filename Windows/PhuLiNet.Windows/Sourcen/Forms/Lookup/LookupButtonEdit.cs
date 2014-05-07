using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Windows.Core.Forms.Lookup
{
    public class LookupButtonEdit : ButtonEdit
    {
        public delegate void OnLookupEventHandler();

        public event OnLookupEventHandler OnLookup;

        public LookupButtonEdit()
            : base()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var lookupProperties = fProperties as RepositoryItemButtonEdit;
            ((ISupportInitialize) (lookupProperties)).BeginInit();
            SuspendLayout();
            // 
            // lookupProperties
            //
            lookupProperties.TextEditStyle = TextEditStyles.DisableTextEditor;
            // 
            // LookupButtonEdit
            // 
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LookupButtonEdit_MouseDown);
            KeyDown += new KeyEventHandler(LookupButtonEdit_KeyDown);
            ButtonPressed += new ButtonPressedEventHandler(LookupButtonEdit_ButtonPressed);
            ((ISupportInitialize) (lookupProperties)).EndInit();
            ResumeLayout(false);
        }

        private void LookupButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (OnLookup != null)
                    OnLookup();
            }
        }

        private void LookupButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (sender.GetType() == typeof (LookupButtonEdit))
            {
                if (OnLookup != null)
                    OnLookup();
            }
        }

        /*
        private void LookupButtonEdit_MouseDown(object sender, MouseEventArgs e)
        {
            if (OnLookup != null)
                OnLookup();
        }
        */
    }
}