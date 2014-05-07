namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    /// <summary>
    /// Business object and database entity synchronization
    /// </summary>
    public interface IObjectFactorySynchronization
    {
        object EntityAsObject { get; set; }
        void InsertPreparation();
        void UpdatePreparation();
    }
}