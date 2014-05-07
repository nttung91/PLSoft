namespace Windows.Core.Messaging
{
    /// <summary>
    /// Expired Data Message
    /// Informs a form that the data is not up to date anymore and that it should reload it's content.
    /// </summary>
    public class DataExpiredMessage : BaseMessage
    {
        internal DataExpiredMessage()
            : base("DataExpiredMessage",
                "DataExpiredMessage")
        {
        }
    }
}