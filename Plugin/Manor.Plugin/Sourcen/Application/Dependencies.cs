using System.Collections.Generic;
using Manor.Plugin.Application;

namespace PhuLiNet.Plugin.Application
{
    internal class Dependencies : List<Dependency>
    {
        internal Dependencies()
        {
        }

        public Dependency GetById(string id)
        {
            Dependency found = null;

            foreach (Dependency d in this)
            {
                if (d.Id == id)
                {
                    found = d;
                    break;
                }
            }

            return found;
        }
    }
}