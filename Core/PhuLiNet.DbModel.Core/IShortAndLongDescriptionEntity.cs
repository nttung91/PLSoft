namespace DbModel.Core
{
    public interface IShortAndLongDescriptionEntity : IDescriptionEntity
    {
        string ShortDescr { get; set; }
    }
}