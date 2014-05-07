namespace PhuLiNet.Business.Common.Context.Base
{
    public interface IBusinessContext<T>
    {
        T BusinessContext { get; set; }
    }
}