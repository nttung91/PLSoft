namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    /// <summary>
    /// Object factory interface for CSLA root objects with unique artifical key
    /// </summary>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TK"></typeparam>
    public interface IGenericObjectFactory<TE, TK>
    {
        TE Entity { get; set; }
        TK Id { get; }
        void Get(TK id);
        void Delete(TK id);
    }
}