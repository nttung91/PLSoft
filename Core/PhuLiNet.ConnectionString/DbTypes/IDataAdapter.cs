namespace Manor.ConnectionStrings.DbTypes
{
    public interface IDataAdapter
    {
        DatabaseTypeList Load();
        void Validate();
    }
}