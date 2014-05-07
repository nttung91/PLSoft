using PhuLiNet.Business.Common.Navigator.Interfaces;

namespace Windows.Core.Forms.Navigator.Controls
{
    partial class UCNavigator
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCNavigator));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.tlObjectTree = new DevExpress.XtraTreeList.TreeList();
            this.colLinkIcon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ripeLinkIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBrokenRulesPreview = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsValid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.riceStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bsObjectTree = new System.Windows.Forms.BindingSource(this.components);
            this.prNavigator = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.riicSeverity = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.icStatus = new DevExpress.Utils.ImageCollection(this.components);
            this.ribeJumpTo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rimeDescr = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.riteDescription = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.icNodeIcons = new DevExpress.Utils.ImageCollection(this.components);
            this.tcNavigator = new DevExpress.Utils.ToolTipController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bmNavigator = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bbiStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpandAll = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.tlObjectTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ripeLinkIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicSeverity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeJumpTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rimeDescr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icNodeIcons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmNavigator)).BeginInit();
            this.SuspendLayout();
            // 
            // tlObjectTree
            // 
            resources.ApplyResources(this.tlObjectTree, "tlObjectTree");
            this.tlObjectTree.Appearance.Preview.Font = ((System.Drawing.Font)(resources.GetObject("tlObjectTree.Appearance.Preview.Font")));
            this.tlObjectTree.Appearance.Preview.ForeColor = ((System.Drawing.Color)(resources.GetObject("tlObjectTree.Appearance.Preview.ForeColor")));
            this.tlObjectTree.Appearance.Preview.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tlObjectTree.Appearance.Preview.GradientMode")));
            this.tlObjectTree.Appearance.Preview.Image = ((System.Drawing.Image)(resources.GetObject("tlObjectTree.Appearance.Preview.Image")));
            this.tlObjectTree.Appearance.Preview.Options.UseFont = true;
            this.tlObjectTree.Appearance.Preview.Options.UseForeColor = true;
            this.tlObjectTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colLinkIcon,
            this.colDescription,
            this.colBrokenRulesPreview,
            this.colIsValid});
            this.tlObjectTree.DataSource = this.bsObjectTree;
            this.tlObjectTree.ExternalRepository = this.prNavigator;
            this.tlObjectTree.Name = "tlObjectTree";
            this.tlObjectTree.OptionsView.AutoCalcPreviewLineCount = true;
            this.tlObjectTree.OptionsView.ShowIndicator = false;
            this.tlObjectTree.OptionsView.ShowPreview = true;
            this.tlObjectTree.OptionsView.ShowVertLines = false;
            this.tlObjectTree.PreviewFieldName = "BrokenRulesPreview";
            this.tlObjectTree.SelectImageList = this.icNodeIcons;
            this.tlObjectTree.ToolTipController = this.tcNavigator;
            this.tlObjectTree.CustomDrawNodePreview += new DevExpress.XtraTreeList.CustomDrawNodePreviewEventHandler(this.tlObjectTree_CustomDrawNodePreview);
            this.tlObjectTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tlObjectTree_MouseClick);
            // 
            // colLinkIcon
            // 
            resources.ApplyResources(this.colLinkIcon, "colLinkIcon");
            this.colLinkIcon.ColumnEdit = this.ripeLinkIcon;
            this.colLinkIcon.FieldName = "LinkIcon";
            this.colLinkIcon.Name = "colLinkIcon";
            // 
            // ripeLinkIcon
            // 
            resources.ApplyResources(this.ripeLinkIcon, "ripeLinkIcon");
            this.ripeLinkIcon.Name = "ripeLinkIcon";
            // 
            // colDescription
            // 
            resources.ApplyResources(this.colDescription, "colDescription");
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowFocus = false;
            // 
            // colBrokenRulesPreview
            // 
            resources.ApplyResources(this.colBrokenRulesPreview, "colBrokenRulesPreview");
            this.colBrokenRulesPreview.FieldName = "BrokenRulesPreview";
            this.colBrokenRulesPreview.Name = "colBrokenRulesPreview";
            // 
            // colIsValid
            // 
            resources.ApplyResources(this.colIsValid, "colIsValid");
            this.colIsValid.ColumnEdit = this.riceStatus;
            this.colIsValid.FieldName = "IsValid";
            this.colIsValid.Name = "colIsValid";
            this.colIsValid.OptionsColumn.FixedWidth = true;
            this.colIsValid.OptionsColumn.ReadOnly = true;
            // 
            // riceStatus
            // 
            resources.ApplyResources(this.riceStatus, "riceStatus");
            this.riceStatus.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.riceStatus.Name = "riceStatus";
            this.riceStatus.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("riceStatus.PictureUnchecked")));
            // 
            // bsObjectTree
            // 
            this.bsObjectTree.DataSource = typeof(ITreeNode);
            // 
            // prNavigator
            // 
            this.prNavigator.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riicSeverity,
            this.ribeJumpTo,
            this.rimeDescr,
            this.ripeLinkIcon,
            this.riceStatus,
            this.riteDescription});
            // 
            // riicSeverity
            // 
            resources.ApplyResources(this.riicSeverity, "riicSeverity");
            this.riicSeverity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riicSeverity.Buttons"))))});
            this.riicSeverity.Name = "riicSeverity";
            this.riicSeverity.SmallImages = this.icStatus;
            // 
            // icStatus
            // 
            this.icStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icStatus.ImageStream")));
            // 
            // ribeJumpTo
            // 
            resources.ApplyResources(this.ribeJumpTo, "ribeJumpTo");
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            resources.ApplyResources(toolTipTitleItem1, "toolTipTitleItem1");
            resources.ApplyResources(toolTipItem1, "toolTipItem1");
            toolTipItem1.LeftIndent = 6;
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.ribeJumpTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ribeJumpTo.Buttons"))), resources.GetString("ribeJumpTo.Buttons1"), ((int)(resources.GetObject("ribeJumpTo.Buttons2"))), ((bool)(resources.GetObject("ribeJumpTo.Buttons3"))), ((bool)(resources.GetObject("ribeJumpTo.Buttons4"))), ((bool)(resources.GetObject("ribeJumpTo.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("ribeJumpTo.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("ribeJumpTo.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("ribeJumpTo.Buttons8"), ((object)(resources.GetObject("ribeJumpTo.Buttons9"))), superToolTip1, ((bool)(resources.GetObject("ribeJumpTo.Buttons10"))))});
            this.ribeJumpTo.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("ribeJumpTo.Mask.AutoComplete")));
            this.ribeJumpTo.Mask.BeepOnError = ((bool)(resources.GetObject("ribeJumpTo.Mask.BeepOnError")));
            this.ribeJumpTo.Mask.EditMask = resources.GetString("ribeJumpTo.Mask.EditMask");
            this.ribeJumpTo.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("ribeJumpTo.Mask.IgnoreMaskBlank")));
            this.ribeJumpTo.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ribeJumpTo.Mask.MaskType")));
            this.ribeJumpTo.Mask.PlaceHolder = ((char)(resources.GetObject("ribeJumpTo.Mask.PlaceHolder")));
            this.ribeJumpTo.Mask.SaveLiteral = ((bool)(resources.GetObject("ribeJumpTo.Mask.SaveLiteral")));
            this.ribeJumpTo.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("ribeJumpTo.Mask.ShowPlaceHolders")));
            this.ribeJumpTo.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("ribeJumpTo.Mask.UseMaskAsDisplayFormat")));
            this.ribeJumpTo.Name = "ribeJumpTo";
            this.ribeJumpTo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // rimeDescr
            // 
            resources.ApplyResources(this.rimeDescr, "rimeDescr");
            this.rimeDescr.Name = "rimeDescr";
            // 
            // riteDescription
            // 
            resources.ApplyResources(this.riteDescription, "riteDescription");
            this.riteDescription.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("riteDescription.Mask.AutoComplete")));
            this.riteDescription.Mask.BeepOnError = ((bool)(resources.GetObject("riteDescription.Mask.BeepOnError")));
            this.riteDescription.Mask.EditMask = resources.GetString("riteDescription.Mask.EditMask");
            this.riteDescription.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("riteDescription.Mask.IgnoreMaskBlank")));
            this.riteDescription.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("riteDescription.Mask.MaskType")));
            this.riteDescription.Mask.PlaceHolder = ((char)(resources.GetObject("riteDescription.Mask.PlaceHolder")));
            this.riteDescription.Mask.SaveLiteral = ((bool)(resources.GetObject("riteDescription.Mask.SaveLiteral")));
            this.riteDescription.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("riteDescription.Mask.ShowPlaceHolders")));
            this.riteDescription.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("riteDescription.Mask.UseMaskAsDisplayFormat")));
            this.riteDescription.Name = "riteDescription";
            // 
            // icNodeIcons
            // 
            this.icNodeIcons.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icNodeIcons.ImageStream")));
            // 
            // tcNavigator
            // 
            this.tcNavigator.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.tcNavigator_GetActiveObjectInfo);
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.tcNavigator.SetAllowHtmlText(this.barDockControlTop, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("barDockControlTop.AllowHtmlText"))));
            this.barDockControlTop.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlTop.Appearance.GradientMode")));
            this.barDockControlTop.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlTop.Appearance.Image")));
            this.barDockControlTop.CausesValidation = false;
            this.tcNavigator.SetTitle(this.barDockControlTop, resources.GetString("barDockControlTop.Title"));
            this.tcNavigator.SetToolTip(this.barDockControlTop, resources.GetString("barDockControlTop.ToolTip"));
            this.tcNavigator.SetToolTipIconType(this.barDockControlTop, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("barDockControlTop.ToolTipIconType"))));
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.tcNavigator.SetAllowHtmlText(this.barDockControlBottom, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("barDockControlBottom.AllowHtmlText"))));
            this.barDockControlBottom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlBottom.Appearance.GradientMode")));
            this.barDockControlBottom.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlBottom.Appearance.Image")));
            this.barDockControlBottom.CausesValidation = false;
            this.tcNavigator.SetTitle(this.barDockControlBottom, resources.GetString("barDockControlBottom.Title"));
            this.tcNavigator.SetToolTip(this.barDockControlBottom, resources.GetString("barDockControlBottom.ToolTip"));
            this.tcNavigator.SetToolTipIconType(this.barDockControlBottom, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("barDockControlBottom.ToolTipIconType"))));
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.tcNavigator.SetAllowHtmlText(this.barDockControlLeft, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("barDockControlLeft.AllowHtmlText"))));
            this.barDockControlLeft.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlLeft.Appearance.GradientMode")));
            this.barDockControlLeft.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlLeft.Appearance.Image")));
            this.barDockControlLeft.CausesValidation = false;
            this.tcNavigator.SetTitle(this.barDockControlLeft, resources.GetString("barDockControlLeft.Title"));
            this.tcNavigator.SetToolTip(this.barDockControlLeft, resources.GetString("barDockControlLeft.ToolTip"));
            this.tcNavigator.SetToolTipIconType(this.barDockControlLeft, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("barDockControlLeft.ToolTipIconType"))));
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.tcNavigator.SetAllowHtmlText(this.barDockControlRight, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("barDockControlRight.AllowHtmlText"))));
            this.barDockControlRight.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlRight.Appearance.GradientMode")));
            this.barDockControlRight.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlRight.Appearance.Image")));
            this.barDockControlRight.CausesValidation = false;
            this.tcNavigator.SetTitle(this.barDockControlRight, resources.GetString("barDockControlRight.Title"));
            this.tcNavigator.SetToolTip(this.barDockControlRight, resources.GetString("barDockControlRight.ToolTip"));
            this.tcNavigator.SetToolTipIconType(this.barDockControlRight, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("barDockControlRight.ToolTipIconType"))));
            // 
            // bmNavigator
            // 
            this.bmNavigator.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.bmNavigator.DockControls.Add(this.barDockControlTop);
            this.bmNavigator.DockControls.Add(this.barDockControlBottom);
            this.bmNavigator.DockControls.Add(this.barDockControlLeft);
            this.bmNavigator.DockControls.Add(this.barDockControlRight);
            this.bmNavigator.Form = this;
            this.bmNavigator.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiExpandAll,
            this.bbiStandard});
            this.bmNavigator.MaxItemId = 2;
            this.bmNavigator.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExpandAll)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar3, "bar3");
            // 
            // bbiStandard
            // 
            resources.ApplyResources(this.bbiStandard, "bbiStandard");
            this.bbiStandard.Id = 1;
            this.bbiStandard.Name = "bbiStandard";
            this.bbiStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStandard_ItemClick);
            // 
            // bbiExpandAll
            // 
            resources.ApplyResources(this.bbiExpandAll, "bbiExpandAll");
            this.bbiExpandAll.Id = 0;
            this.bbiExpandAll.Name = "bbiExpandAll";
            this.bbiExpandAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpandAll_ItemClick);
            // 
            // UCNavigator
            // 
            resources.ApplyResources(this, "$this");
            this.tcNavigator.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlObjectTree);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UCNavigator";
            this.tcNavigator.SetTitle(this, resources.GetString("$this.Title"));
            this.tcNavigator.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.tcNavigator.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
            ((System.ComponentModel.ISupportInitialize)(this.tlObjectTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ripeLinkIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicSeverity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeJumpTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rimeDescr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icNodeIcons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmNavigator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlObjectTree;
        private System.Windows.Forms.BindingSource bsObjectTree;
        private DevExpress.XtraBars.BarManager bmNavigator;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem bbiExpandAll;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection icStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicSeverity;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribeJumpTo;
        private DevExpress.XtraEditors.Repository.PersistentRepository prNavigator;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rimeDescr;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit ripeLinkIcon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceStatus;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLinkIcon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBrokenRulesPreview;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsValid;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riteDescription;
        private DevExpress.Utils.ToolTipController tcNavigator;
        private DevExpress.XtraBars.BarButtonItem bbiStandard;
        private DevExpress.Utils.ImageCollection icNodeIcons;
    }
}
