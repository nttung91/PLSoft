namespace PhuLiNet.Plugin.Application
{
    internal class Dependency
    {
        public string Id { get; set; }
        public string ConfigFile { get; set; }
        public string ResolverType { get; set; }

        internal Dependency()
        {
        }
    }
}