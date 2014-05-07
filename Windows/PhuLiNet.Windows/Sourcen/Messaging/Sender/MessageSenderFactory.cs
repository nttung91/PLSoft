namespace Windows.Core.Messaging.Sender
{
    internal static class MessageSenderFactory
    {
        public static IMessageSender GetNoMessageSender()
        {
            return new NoMessageSender();
        }

        public static IMessageSender GetDefaultMessageSender()
        {
            return new DefaultMessageSender();
        }
    }
}