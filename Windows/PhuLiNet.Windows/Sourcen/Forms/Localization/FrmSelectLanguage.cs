using System;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using DevExpress.XtraEditors;
using PhuLiNet.Business.Common.Languages;
using Windows.Core.BaseForms;
using Windows.Core.Commands;

namespace Windows.Core.Forms.Localization
{
    internal partial class FrmSelectLanguage : FrmDialogBase
    {
        private LanguageList languageList;
        private Language _language;

        public FrmSelectLanguage()
        {
            InitializeComponent();
            InitBindings();
            InitControls();
        }

        protected override void InitBindings()
        {
            languageList = new LanguageList();
            _objectBindingManager.BindBO(languageList, languageBindingSource);
        }

        protected override void InitControls()
        {
            var langList = new LanguageList();
            Language currentLanguage = langList.SearchCurrentCulture();

            if (currentLanguage != null)
            {
                _language = currentLanguage;
                leLanguage.EditValue = _language;
            }

            setOKEnaDisa();
        }

        protected override void AcceptButtonCloseForm()
        {
            if (_language != null)
            {
                CommandExecutor.Execute(new CommandSetLanguage(_language));
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void leLanguage_EditValueChanged(object sender, EventArgs e)
        {
            _language = (Language) leLanguage.EditValue;
            setOKEnaDisa();
        }

        private void setOKEnaDisa()
        {
            ((SimpleButton) AcceptButton).Enabled = (_language != null);
        }
    }
}