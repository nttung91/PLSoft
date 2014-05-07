using Windows.Core.Messaging.Handler;

namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Defines that the form can send and receive messages
    /// </summary>
    public interface IFormMessages
    {
        IMessageHandler MessageHandler { get; }
        IMessageReceiver MessageReceiver { get; }
    }
}