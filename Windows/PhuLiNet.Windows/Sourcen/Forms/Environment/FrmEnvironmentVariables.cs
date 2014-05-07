using System;
using System.Collections;
using System.Collections.Generic;
using Windows.Core.BaseForms;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms.Environment
{
    internal partial class FrmEnvironmentVariables : FrmDialogBase
    {
        private IList<KeyValuePair<string, string>> _envVars;
        private int _selectedEnvVarType = 0;

        public FrmEnvironmentVariables()
        {
            InitializeComponent();
            InitBindings();
            InitControls();
        }

        protected override void InitBindings()
        {
            _envVars = new List<KeyValuePair<string, string>>();

            Hashtable envVars = null;
            envVars =
                (Hashtable) System.Environment.GetEnvironmentVariables((EnvironmentVariableTarget) _selectedEnvVarType);

            if (_envVars != null)
            {
                foreach (DictionaryEntry de in envVars)
                {
                    _envVars.Add(new KeyValuePair<string, string>(de.Key.ToString(), de.Value.ToString()));
                }
            }

            gcEnvVars.DataSource = _envVars;
        }

        protected override void InitControls()
        {
            AcceptButtonVisible = false;
        }

        private void cbeEnvVarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedEnvVarType = cbeEnvVarType.SelectedIndex;
            InitBindings();
        }
    }
}