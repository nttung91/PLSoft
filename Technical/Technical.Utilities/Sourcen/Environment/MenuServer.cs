using Technical.Utilities.Helpers;

namespace Technical.Utilities.Environment
{
    public class MenuServer
    {
        private const string TechnicalSourceMode = "MiSrcMode";
        private const string TechnicalModules = "MiModules";

        public const string DefaultModulesPath = @"D:\TechnicalModules";

        public static void SetModulesPath(string path)
        {
            System.Environment.SetEnvironmentVariable(TechnicalModules, path);
        }

        public static void SetDefaultModulesPath()
        {
            System.Environment.SetEnvironmentVariable(TechnicalModules, DefaultModulesPath);
        }

        public static void ClearModulesPath()
        {
            System.Environment.SetEnvironmentVariable(TechnicalModules, null);
        }

        public static void SetSourceModeTest()
        {
            System.Environment.SetEnvironmentVariable(TechnicalSourceMode, SourceModeValue(ESourceMode.Testing));
        }

        public static void ClearSourceMode()
        {
            System.Environment.SetEnvironmentVariable(TechnicalSourceMode, null);
        }

        public static ESourceMode SourceMode()
        {
            var sourceMode = SourceModeValue();
            return EnumHelper.GetEnumValueFromDescription<ESourceMode>(sourceMode);
        }

        public static string SourceModeValue()
        {
            var sourceMode = System.Environment.GetEnvironmentVariable(TechnicalSourceMode);
            return !string.IsNullOrEmpty(sourceMode) ? sourceMode.ToUpper() : null;
        }

        public static string SourceModeShortcut()
        {
            string sourceMode = SourceModeValue();
            return GetSourceModeShortcut(sourceMode);
        }

        private static string GetSourceModeShortcut(string sourceModeValue)
        {
            if (!string.IsNullOrEmpty(sourceModeValue)) return sourceModeValue.Substring(0, 1);
            return null;
        }

        public static bool SourceModeExists()
        {
            return !string.IsNullOrEmpty(SourceModeValue());
        }

        public static string SourceModeValue(ESourceMode sourceMode)
        {
            return EnumHelper.GetEnumDescription(sourceMode);
        }

        public static string SourceModeShortcut(ESourceMode sourceMode)
        {
            return GetSourceModeShortcut(EnumHelper.GetEnumDescription(sourceMode));
        }

        public static string ModulesPath()
        {
            return System.Environment.GetEnvironmentVariable(TechnicalModules);
        }

        public static bool ModulesPathExists()
        {
            return !string.IsNullOrEmpty(ModulesPath());
        }
    }
}