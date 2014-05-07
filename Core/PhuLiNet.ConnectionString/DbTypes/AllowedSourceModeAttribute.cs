using System;
using Manor.Utilities.Environment;

namespace Manor.ConnectionStrings.DbTypes
{
    /// <summary>
    /// Defines allowed source mode for database mode
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class AllowedSourceModeAttribute : Attribute
    {
        public ESourceMode SourceMode { get; set; }

        public AllowedSourceModeAttribute(ESourceMode sourceMode)
        {
            SourceMode = sourceMode;
        }

        public override string ToString()
        {
            return string.Format("{0}", SourceMode);
        }
    }
}