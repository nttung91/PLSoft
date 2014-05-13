using System;

namespace PhuLiNet.Plugin.Application
{
    public interface IApplicationInfo
    {
        string Name { get; }
        Version Version { get; }
        DateTime Date { get; }
        bool AutoStart { get; }
    }
}