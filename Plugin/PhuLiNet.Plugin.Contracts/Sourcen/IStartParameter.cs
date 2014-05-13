using System.Collections.Generic;

namespace PhuLiNet.Plugin.Contracts
{
    public interface IStartParameter
    {
        /// <summary>
        /// Plugin start parameters
        /// </summary>
        Dictionary<string, object> Parameters { get; }

        /// <summary>
        /// Plugin return values
        /// </summary>
        Dictionary<string, object> ReturnValues { get; }

        /// <summary>
        /// Control button pressed
        /// </summary>
        bool CtrlPressed { get; }
    }
}