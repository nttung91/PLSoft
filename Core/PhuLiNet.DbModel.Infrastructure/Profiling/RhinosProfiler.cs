using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace Core.DbModel.Infrastructure.Profiling
{
    internal class RhinosProfiler : IProfiler
    {
        public void Initialize()
        {
            NHibernateProfiler.Initialize();
        }
    }
}