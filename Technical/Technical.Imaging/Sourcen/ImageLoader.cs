using System.Diagnostics;
using System.IO;
using System.Net;
using Technical.Imaging.Validation;

namespace Technical.Imaging
{
    /// <summary>
    /// Funktionen zum Bilder laden
    /// </summary>
    public class ImageLoader
    {
        /// <summary>
        /// Byte-Array aus Datei lesen
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static byte[] GetByteFromFile(string fileName)
        {
            byte[] result = null;

            if (File.Exists(fileName))
            {
                result = File.ReadAllBytes(fileName);

                if (!ImageValidator.GetInstance().IsValidImage(result))
                {
                    result = null;
                }
            }

            return result;
        }

        public static byte[] GetByteFromURL(string url)
        {
            byte[] picture = null;

            var webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;

            try
            {
                picture = webClient.DownloadData(url);
            }
            catch (WebException)
            {
                Debug.Assert(false, "picture not found");
                picture = null;
            }

            return picture;
        }
    }
}