using Manor.Plugin;

namespace PhuLiNet.Plugin
{
    internal static class DependencyLoaderFactory
    {
        public static IDependencyLoader GetInstance(string startupPath, string appConfigFile)
        {
            var dependencyLoader = new DependencyLoader();
            dependencyLoader.StartupPath = startupPath;
            dependencyLoader.AppConfigFile = appConfigFile;
            dependencyLoader.Run();

            return dependencyLoader;
        }
    }
}