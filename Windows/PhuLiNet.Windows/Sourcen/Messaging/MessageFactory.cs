namespace Windows.Core.Messaging
{
    public static class MessageFactory
    {
        public static IMessage DataExpiredMessage()
        {
            return new DataExpiredMessage();
        }
    }
}