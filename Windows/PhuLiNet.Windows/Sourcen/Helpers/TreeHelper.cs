using DevExpress.XtraTreeList;
using Windows.Core.Settings;

namespace Windows.Core.Helpers
{
    public static class TreeHelper
    {
        public const string StandardLayout = "STANDARD";
        public const string ResetLayout = "RESET";

        /// <summary>
        /// Der Pfad zum Key ist als Application Default gespeichert.
        /// </summary>
        /// <param name="Layout"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private static string GetLayoutPath(string Layout, string form)
        {
            return RegistryHelper.CurrentUserApplicationPath + "_" + Layout + "_" + form;
        }

        public static void SaveLayout(TreeList tree, string layout, string formName)
        {
            string path = GetLayoutPath(layout, formName);
            tree.SaveLayoutToRegistry(path);
        }


        /// <summary>
        /// Zurücklesen eines Tree Layouts aus der User Registry
        /// </summary>
        public static void RestoreLayout(TreeList tree, string layout, string formName)
        {
            string path = GetLayoutPath(layout, formName);
            tree.RestoreLayoutFromRegistry(path);
        }
    }
}