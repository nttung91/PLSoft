using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.WXPaint;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Design;
using Technical.Settings;
using Windows.Core.Style;

namespace Windows.Core.BaseForms
{
    public partial class FrmOptionenBase : FrmBase
    {
        private readonly string _xtraGridAppearancesFile = Application.StartupPath +
                                                           "\\DevExpress.XtraGrid.Appearances.xml";

        private EStyles _style = EStyles.Default;
        private readonly UserLookAndFeel _lookAndFeel = UserLookAndFeel.Default;

        public FrmOptionenBase()
        {
            InitializeComponent();
        }

        public void HideAppParameterTab()
        {
            xtpApplication.PageVisible = false;
        }

        private void FrmOptionenBase_Load(object sender, EventArgs e)
        {
            if (IsDesignerHosted) return;

            InitStyleSchemas();
            ReadSettings();
            InitStylesRg();
            InitSkinNames(lbSkins);
            lbSkins.Enabled = (rgStyles.EditValue.ToString() == EStyles.Skin.ToString());
            lbSkins.SelectedIndexChanged += lbSkins_SelectedIndexChanged;
            rgStyles.SelectedIndexChanged += rgStyles_SelectedIndexChanged;
        }

        private void ReadSettings()
        {
            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");

            lbSkins.SelectedValue = section.GetSetting("Skin", "Default").Value;
            ceWaitForm.Checked = section.GetSetting("ShowWaitForm", true).Value;
            _style = GetStyleAsEnum(section.GetSetting<string>("LookAndFeel", null).Value);

            if (cboSchemas.Properties.Items.Count > 1)
            {
                cboSchemas.SelectedItem = section.GetSetting<string>("StyleSchemaFormatName", null).Value;
            }

            var customFont = section.GetSetting("CustomFont", AppearanceObject.DefaultFont).Value;
            if (customFont == null) customFont = Style.DefaultFont.Get();
            SetFont(customFont);
        }

        private void WriteSettings()
        {
            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");

            section.GetSetting<bool>("ShowWaitForm").Value = ceWaitForm.Checked;
            section.GetSetting<string>("Skin").Value = lbSkins.SelectedValue.ToString();
            section.GetSetting<string>("LookAndFeel").Value = _style.ToString();

            if (cboSchemas.SelectedItem != null)
            {
                section.GetSetting<string>("StyleSchemaFormatName").Value = cboSchemas.SelectedItem.ToString();
            }
            else
            {
                section.GetSetting<string>("StyleSchemaFormatName").Value = null;
            }

            section.GetSetting<Font>("CustomFont").Value = GetFont();

            settingsProvider.SaveSection(section);
        }

        private void InitStylesRg()
        {
            bool useXp = Painter.ThemesEnabled;
            if (!useXp)
            {
                rgStyles.Properties.Items.RemoveAt(rgStyles.Properties.Items.Count - 1);
            }

            rgStyles.SelectedIndex = GetStyleIndex(_style);
        }

        private void rgStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var group = sender as RadioGroup;
            Debug.Assert(group != null, "group != null");
            _style = GetStyleAsEnum(group.EditValue.ToString());

            lbSkins.Enabled = (_style == EStyles.Skin);

            var appearance = new SetAppearance();
            appearance.SetLookAndFeel(_style, lbSkins.SelectedValue.ToString());
        }

        private void InitSkinNames(ListBoxControl listBox)
        {
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                listBox.Items.Add(cnt.SkinName);
            }

            listBox.SelectedValue = _lookAndFeel.SkinName;
        }

        private void InitStyleSchemas()
        {
            if (!new FileInfo(_xtraGridAppearancesFile).Exists)
                return;

            var xapp = new XAppearances(_xtraGridAppearancesFile) {ShowNewStylesOnly = true};

            cboSchemas.Properties.Items.Clear();
            cboSchemas.Properties.Items.AddRange(xapp.FormatNames);
        }

        private EStyles GetStyleAsEnum(string styleName)
        {
            EStyles style;
            Enum.TryParse(styleName, out style);
            return style;
        }

        private int GetStyleIndex(EStyles style)
        {
            int index = 0;
            switch (style)
            {
                case EStyles.Default:
                    index = 0;
                    break;
                case EStyles.Flat:
                    index = 1;
                    break;
                case EStyles.Ultraflat:
                    index = 2;
                    break;
                case EStyles.Style3D:
                    index = 3;
                    break;
                case EStyles.Office2003:
                    index = 4;
                    break;
                case EStyles.Skin:
                    index = 5;
                    break;
                case EStyles.XP:
                    index = 6;
                    break;
                default:
                    break;
            }
            return index;
        }

        private void lbSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            var skins = sender as ListBoxControl;
            _lookAndFeel.Style = LookAndFeelStyle.Skin;
            Debug.Assert(skins != null, "skins != null");
            _lookAndFeel.SkinName = skins.SelectedValue.ToString();
        }

        private void sbOk_Click(object sender, EventArgs e)
        {
            WriteSettings();
            Close();
        }

        private void sbAbbrechen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbStandardFont_Click(object sender, EventArgs e)
        {
            SetFont(Style.DefaultFont.Get());
        }

        private void SetFont(Font font)
        {
            if (font != null)
            {
                fontEdit.EditValue = font.FontFamily.Name;
                spiFontSize.EditValue = font.Size;
                ceFontBold.EditValue = font.Bold;
            }
        }

        private Font GetFont()
        {
            var fontStyle = ceFontBold.Checked ? FontStyle.Bold : FontStyle.Regular;
            return new Font((string) fontEdit.EditValue, Convert.ToSingle(spiFontSize.EditValue), fontStyle);
        }
    }
}