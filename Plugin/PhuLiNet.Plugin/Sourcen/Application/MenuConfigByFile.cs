using Manor.Plugin.Application;

namespace PhuLiNet.Plugin.Application
{
    internal class MenuConfigByFile : IMenuConfig
    {
        public string Type { get; set; }
        public string ConfigFile { get; set; }
    }
}