using System;
using System.ComponentModel;
using System.Drawing;
using PhuLiNet.Business.Common.Languages.DescriptionBase;
using PhuLiNet.Business.Common.Localization;
using Windows.Core.Binding;
using Windows.Core.Controls.Adapters;

namespace Windows.Core.Controls
{
    [ToolboxItem(false)]
    // ReSharper disable InconsistentNaming
    public partial class UCDescriptions : UCEditBusinessListBase
        // ReSharper restore InconsistentNaming
    {
        private static readonly Font MonoRegularFont = new Font("Courier New", 8.25F, FontStyle.Regular,
            GraphicsUnit.Point, 0);

        // ReSharper disable InconsistentNaming
        private Type _parentDSType;
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// The name of the data member for desriptions list in parent object
        /// </summary>
        protected virtual string DataMember
        {
            get { return "Descriptions"; }
        }

        protected virtual Size UcSize
        {
            get { return new Size(751, 421); }
        }

        protected virtual int ColLangWidth
        {
            get { return 114; }
        }

        protected virtual int ColShortDescrWidth
        {
            get { return 196; }
        }

        protected virtual int ColDescrWidth
        {
            get { return 360; }
        }

        /// <summary>
        /// Gets the position of the marker in column "description", starts with 1.
        /// Only impact if mono fonts are used (see constructor)
        /// </summary>
        protected virtual int ColDescrMarkerPosition
        {
            get { return 28; }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UCDescriptions()
        {
            InitializeComponent();
            InitColumnCaptions();
        }

        /// <summary>
        /// Spezialized Constructor.
        /// </summary>
        /// <param name="parentDS">type of parent data source</param>
        /// <param name="withShortDescr"><c>true</c> if grid should display short description, <c>false</c> if not.</param>
        /// <param name="useMonoFonts"><c>true</c> if mono fonts should be used for description and short description (header and cell)</param>
        protected UCDescriptions(Type parentDS, bool withShortDescr, bool useMonoFonts = true)
            : this()
        {
            InitCustomComponent(parentDS, withShortDescr);

            if (useMonoFonts)
                SetToMonoFont();
        }

        protected override void InitListControl()
        {
            ListControl = new GridViewAdapter(gvDescriptions) {NotAllowToAddOrDeleteRow = true};
        }

        private void InitColumnCaptions()
        {
            colLang.Caption = DescriptionEdit.Language;
            colShortDescr.Caption = DescriptionEdit.ShortDescription;
            colDescr.Caption = DescriptionEdit.Description;
        }

        private void SetToMonoFont()
        {
            colDescr.AppearanceCell.Font = MonoRegularFont;
            colDescr.AppearanceCell.Options.UseFont = true;
            colDescr.AppearanceHeader.Font = MonoRegularFont;
            colDescr.AppearanceHeader.Options.UseFont = true;

            colShortDescr.AppearanceCell.Font = MonoRegularFont;
            colShortDescr.AppearanceCell.Options.UseFont = true;
            colShortDescr.AppearanceHeader.Font = MonoRegularFont;
            colShortDescr.AppearanceHeader.Options.UseFont = true;

            // set right side marker on description column header
            colDescr.Caption = string.Format("{0}|",
                DescriptionEdit.Description.PadRight(Math.Max(0, ColDescrMarkerPosition - 1)));
        }

        private void InitCustomComponent(Type parentDS, bool withShortDescr)
        {
            _parentDSType = parentDS;
            SetDataSourceNoBusinessObjectAvailable();
            if (!withShortDescr)
            {
                colShortDescr.VisibleIndex = -1;
            }
            Size = gcDescriptions.Size = UcSize;
            colLang.Width = ColLangWidth;
            colShortDescr.Width = colShortDescr.MinWidth = ColShortDescrWidth;
            colDescr.Width = colDescr.MinWidth = ColDescrWidth;
        }

        private void SetDataSourceNoBusinessObjectAvailable()
        {
            bsParent.DataSource = _parentDSType;
            SetDescriptionsDataMember();
        }

        protected override BindingSourceNode BindingSource
        {
            get
            {
                var result = new BindingSourceNode(bsParent);
                result.AddChild(bsDescriptions);
                return result;
            }
        }

        protected override void AfterInitBindings()
        {
            if (bsDescriptions.List == null || bsDescriptions.List.Count <= 0)
                return;
            var descrRow = bsDescriptions.List[0] as IDescriptionBusinessObject;
            if (descrRow == null)
                return;

            if (descrRow.MaxLengthDescription.HasValue)
                descriptionTextEdit.MaxLength = descrRow.MaxLengthDescription.Value;

            if (descrRow.MaxLengthShortDescription.HasValue)
                shortDescriptionTextEdit.MaxLength = descrRow.MaxLengthShortDescription.Value;
        }

        public override void BestFitColumns()
        {
            gvDescriptions.BestFitColumns();
        }

        public override void ClearBusiness()
        {
            BusinessObjectToBind = null;
            base.ClearBusiness();
        }

        public override void RefreshBusiness()
        {
            if (BusinessObjectToBind != null)
            {
                base.RefreshBusiness();
                SetDescriptionsDataMember();
            }
            else
            {
                SetDataSourceNoBusinessObjectAvailable();
                _objectBindingManager.RestoreBindings(bsParent, true);
                AfterInitBindings();
            }
        }

        private void SetDescriptionsDataMember()
        {
            if (bsParent.DataSource != null)
            {
                bsDescriptions.DataMember = DataMember;
            }
        }

        public void ChangeDescriptionGridState(bool state)
        {
            gvDescriptions.OptionsBehavior.Editable = state;
        }
    }
}