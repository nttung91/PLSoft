namespace Core.DbModel.Infrastructure.Profiling
{
    public static class Profiler
    {
        private static IProfiler _profiler;

        public static void SetProfiler(IProfiler profiler)
        {
            _profiler = profiler;
            _profiler.Initialize();
        }

        public static IProfiler Get()
        {
            if (_profiler == null) _profiler = new RhinosProfiler();
            return _profiler;
        }
    }
}