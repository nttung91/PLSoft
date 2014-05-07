namespace Windows.Core.Messaging.Handler
{
    public interface IMessageReceiver
    {
        /// <summary>
        /// Receives message
        /// </summary>
        /// <param name="message"></param>
        void Receive(IMessage message);
    }
}