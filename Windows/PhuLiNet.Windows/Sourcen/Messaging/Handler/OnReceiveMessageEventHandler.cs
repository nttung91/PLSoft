namespace Windows.Core.Messaging.Handler
{
    /// <summary>
    /// Receive message event delegate
    /// </summary>
    public delegate void OnReceiveMessageEventHandler(IMessageHandler sender, ReceiveMessageEventArgs e);
}