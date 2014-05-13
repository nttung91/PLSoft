using System.Collections.Generic;
using System.Diagnostics;
using Manor.Plugin.Application;

namespace PhuLiNet.Plugin.Application
{
    internal class Configurations : List<Configuration>
    {
        public Configuration GetDefault()
        {
            Configuration defaultConfig = null;

            foreach (Configuration config in this)
            {
                if (config.Default)
                {
                    defaultConfig = config;
                    break;
                }
            }

            Debug.Assert(defaultConfig != null, "Default config not found");

            return defaultConfig;
        }

        public Configuration GetById(string id)
        {
            Debug.Assert(id != null, "config id not found");

            Configuration found = null;

            foreach (Configuration config in this)
            {
                if (config.Id.ToLower() == id.ToLower())
                {
                    found = config;
                    break;
                }
            }

            Debug.Assert(found != null, string.Format("Config [{0}] not found", id));

            return found;
        }
    }
}