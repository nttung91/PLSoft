using System.Collections.Generic;
using PhuLiNet.Plugin.Contracts;

namespace PhuLiNet.Plugin
{
    public class StartParameter : IStartParameter
    {
        public Dictionary<string, object> Parameters { get; set; }
        public Dictionary<string, object> ReturnValues { get; set; }
        public bool CtrlPressed { get; set; }

        public StartParameter()
        {
            ReturnValues = new Dictionary<string, object>();
        }
    }
}