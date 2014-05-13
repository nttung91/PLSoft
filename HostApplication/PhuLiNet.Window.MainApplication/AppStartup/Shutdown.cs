using Windows.Core.Helpers;

namespace PhuLiNet.Window.MainApplication.AppStartup
{
    internal class Shutdown
    {
        public Shutdown()
        {
        }

        public void DeInitContexts()
        {
            //ContextHandler beenden
           // ContextHandler.DestroyInstance();
        }

        public void Logout()
        {
            //Benutzer ausloggen
           // ManorPrincipal.Logout();
        }

        public void UnSetMainForm()
        {
            StatusBusy.UnSetMainForm();
        }
    }
}