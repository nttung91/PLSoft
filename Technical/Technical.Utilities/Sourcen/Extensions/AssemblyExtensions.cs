using System;
using System.IO;
using System.Reflection;

namespace Technical.Utilities.Extensions
{
    public static class AssemblyExtensions
    {
        public static string GetCurrentExecutingDirectory(this Assembly assembly)
        {
            string filePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }
    }
}