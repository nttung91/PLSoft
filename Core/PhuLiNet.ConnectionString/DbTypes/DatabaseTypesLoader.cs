namespace Manor.ConnectionStrings.DbTypes
{
    public class DatabaseTypesLoader
    {
        private readonly IDataAdapter _dataAdapter;

        internal DatabaseTypesLoader(IDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        public DatabaseTypesLoader()
            : this(new AppConfigDataAdapter())
        {
        }

        public DatabaseTypeList Load()
        {
            _dataAdapter.Validate();
            return _dataAdapter.Load();
        }
    }
}