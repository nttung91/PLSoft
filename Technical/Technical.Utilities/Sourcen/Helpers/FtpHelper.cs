using System.Diagnostics;
using System.IO;
using System.Net;

namespace Technical.Utilities.Helpers
{
    public class FtpHelper
    {
        #region Fields

        private string _ftpServer;
        private int _ftpPort = 21;
        private string _targetFolder;

        private string _fileName;
        private string _userName;
        private string _password;

        #endregion

        #region Properties

        public string FtpServer
        {
            get { return _ftpServer; }
            set { _ftpServer = value; }
        }

        public int FtpPort
        {
            get { return _ftpPort; }
            set { _ftpPort = value; }
        }

        public string TargetFolder
        {
            get { return _targetFolder; }
            set { _targetFolder = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        #endregion

        public FtpHelper()
        {
        }

        public FtpHelper(string ftpServer)
        {
            _ftpServer = ftpServer;
        }

        public FtpHelper(string ftpServer, int port) : this(ftpServer)
        {
            _ftpPort = port;
        }

        public FtpHelper(string ftpServer, int port, string targetFolder) : this(ftpServer, port)
        {
            _targetFolder = targetFolder;
        }

        public FtpHelper(string ftpServer, string targetFolder) : this(ftpServer)
        {
            _targetFolder = targetFolder;
        }

        public FtpHelper(string ftpServer, string targetFolder, string userName)
            : this(ftpServer, targetFolder)
        {
            _userName = userName;
        }

        public FtpHelper(string ftpServer, string targetFolder, string userName, string password)
            : this(ftpServer, targetFolder, userName)
        {
            _password = password;
        }

        public FtpHelper(string ftpServer, string targetFolder, string userName, string password, string fileName)
            : this(ftpServer, targetFolder, userName, password)
        {
            _fileName = fileName;
        }

        public void Upload()
        {
            Debug.Assert(_fileName != null, "No file name specified !");

            Upload(File.ReadAllBytes(_fileName));
        }

        public void Upload(string fileName)
        {
            _fileName = fileName;
            Upload();
        }

        public void Upload(byte[] byteStream)
        {
            FtpWebRequest ftpRequest = CreateFtpRequest();

            using (Stream ftpStream = ftpRequest.GetRequestStream())
            {
                ftpStream.Write(byteStream, 0, byteStream.Length);
            }
        }

        private FtpWebRequest CreateFtpRequest()
        {
            Debug.Assert(!string.IsNullOrEmpty(_ftpServer), "No FTP Server specified");

            string url = string.Format("ftp://{0}:{1}{2}/{3}", _ftpServer, _ftpPort, _targetFolder, _fileName);

            var ftpRequest = (FtpWebRequest) WebRequest.Create(url);
            ftpRequest.Credentials = new NetworkCredential(_userName, _password);
            ftpRequest.KeepAlive = false;
            ftpRequest.UseBinary = false;
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpRequest.UsePassive = false;

            return ftpRequest;
        }
    }
}