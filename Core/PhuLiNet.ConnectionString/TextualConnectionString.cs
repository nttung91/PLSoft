namespace Manor.ConnectionStrings
{
    public class TextualConnectionString : IConnectionString
    {
        #region IConnectionString Members

        public string ConnectionString { get; set; }

        #endregion

        public TextualConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}