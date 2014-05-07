using System;
using Technical.Utilities.Cryptography;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms.Cryptography
{
    internal partial class FrmCryptString : FrmReadOnlyBase, ILoadableForm
    {
        public FrmCryptString()
        {
            InitializeComponent();
        }

        protected override void InitBusinessData()
        {
            //load business data here
        }

        protected override void InitBindings()
        {
            //bind business data here
        }

        protected override void InitControls()
        {
            //init controls here
        }

        public void LoadBusiness()
        {
            InitBusinessData();
            InitBindings();
            InitControls();
        }

        private void sbCrypt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mePlainText.Text))
            {
                var cryptEngine = new CryptEngine(CryptEngine.AlgorithmType.Des);
                meCryptedText.Text = cryptEngine.Encrypt(mePlainText.Text);
            }
        }
    }
}