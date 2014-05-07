namespace DbModel.Core
{
    public interface IHasUnitOfWork
    {
        IUnitOfWork UnitOfWork { get; set; }
    }
}