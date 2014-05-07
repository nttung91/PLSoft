namespace Windows.Core.Messaging.Handler
{
    /// <summary>
    /// Creates all message handlers
    /// </summary>
    public static class MessageHandlerFactory
    {
        public static BaseMessageHandler GetNoMessageHandler()
        {
            return new NoMessageHandler();
        }

        public static BaseMessageHandler GetDefaultMessageHandler()
        {
            return new DefaultMessageHandler();
        }
    }
}