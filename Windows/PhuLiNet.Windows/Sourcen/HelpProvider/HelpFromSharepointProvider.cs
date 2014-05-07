using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Technical.Utilities.Exceptions;
using Windows.Core.BaseForms;
using Windows.Core.Forms;
using Windows.Core.HelpProvider.Settings;
using Windows.Core.Localization;

namespace Windows.Core.HelpProvider
{
    public class HelpFromSharepointProvider : HelpProviderBase
    {
        private static readonly HttpStatusCode[] HttpStatusCodesOk = {HttpStatusCode.OK, HttpStatusCode.Found};

        protected override bool FileExists(string filePath)
        {
            var request = WebRequest.Create(filePath) as HttpWebRequest;
            if (request == null)
                throw new PhuLiException(String.Format("unable to create WebRequest using url '{0}'", filePath));

            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "HEAD";

            try
            {
                return HttpStatusCodesOk.Contains(((HttpWebResponse) request.GetResponse()).StatusCode);
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse == null)
                    throw;
                switch (errorResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return false;
                    case HttpStatusCode.Unauthorized:
                    {
                        MessageBox.ShowWarning(string.Format(HelpProviderMessages.UnauthorizedResource, filePath));
                        throw;
                    }
                    default:
                        throw;
                }
            }
        }

        protected override string GetHelpfileFullName(IHelpOnForm help, bool useLanguage)
        {
            var helpfilename = GetHelpFileNameWithoutPath(help, useLanguage);
            return !string.IsNullOrEmpty(helpfilename)
                ? HelpProviderSettings.SharepointPath + helpfilename
                : null;
        }

        protected override void OpenHelpfile(string fullName)
        {
            Process.Start(fullName);
        }
    }
}