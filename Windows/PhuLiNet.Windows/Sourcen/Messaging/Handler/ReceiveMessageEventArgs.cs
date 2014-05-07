namespace Windows.Core.Messaging.Handler
{
    /// <summary>
    /// Receive message event arguments
    /// </summary>
    public class ReceiveMessageEventArgs
    {
        private IMessage _message;

        public IMessage Message
        {
            get { return _message; }
        }

        public ReceiveMessageEventArgs(IMessage message)
        {
            _message = message;
        }
    }
}