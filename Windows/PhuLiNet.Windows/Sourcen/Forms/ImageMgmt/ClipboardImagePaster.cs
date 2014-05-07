using System.ComponentModel;
using Technical.Imaging;

namespace Windows.Core.Forms.ImageMgmt
{
    public partial class ClipboardImagePaster : Component
    {
        public ClipboardImagePaster()
        {
            InitializeComponent();
        }

        public byte[] PictureAsBytes { get; set; }

        public ClipboardImagePaster(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public bool Execute()
        {
            bool result;
            if (ImageClipboardHelper.ContainsImage())
            {
                PictureAsBytes = ImageClipboardHelper.GetByteArray();
                result = true;
            }
            else
            {
                MessageBox.ShowError("Fehler", "Kein Bild in der Zwischenablage", "Bild einfügen");
                result = false;
            }

            return result;
        }
    }
}