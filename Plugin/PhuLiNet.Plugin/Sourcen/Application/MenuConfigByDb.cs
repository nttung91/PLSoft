using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhuLiNet.Plugin.Application
{
    internal class MenuConfigByDb : IMenuConfig
    {
        private string _configString;
        private Dictionary<string, string> _parameters;

        public string Type { get; set; }

        public string MenuRootNode
        {
            get { return Convert.ToString(_parameters["MenuRootNode"]); }
        }

        public string ConfigString
        {
            get { return _configString; }
            set
            {
                _configString = value;
                Parse();
            }
        }

        public MenuConfigByDb()
        {
            _parameters = new Dictionary<string, string>();
        }

        public void Parse()
        {
            var regex = new Regex("([^=;]*)=([^=;]*)");
            var matchCollection = regex.Matches(_configString);

            foreach (Match match in matchCollection)
            {
                string key = match.Groups[1].Value;
                string keyValue = match.Groups[2].Value;

                _parameters.Add(key, keyValue);
            }
        }
    }
}