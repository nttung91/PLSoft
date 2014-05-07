namespace Technical.Utilities.AppInit
{
    /// <summary>
    /// Early initalize an assembly or component at application startup.
    /// This interface is used on assemblies with a time-consuming initialize phase (NHibernate, iBatis, etc.).
    /// 
    /// All IEarlyInitialize implementations are executed on application startup.
    /// </summary>
    public interface IEarlyInitialize
    {
        void Init();
    }
}