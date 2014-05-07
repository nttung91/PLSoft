namespace Manor.ConnectionStrings.DbTypes
{
    public class Database
    {
        public string Id { get; set; }

        public override string ToString()
        {
            return Id;
        }
    }
}