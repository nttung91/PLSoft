using System;
using System.Diagnostics;
using Windows.Core.Messaging.Handler;

namespace Windows.Core.Messaging.Sender
{
    internal class NoMessageSender : IMessageSender
    {
        internal NoMessageSender()
        {
        }

        #region IMessageSender Members

        public void Send(object sender, IMessage message)
        {
            Debug.Assert(false, "Cannot send a message with NoMessageSender");
        }

        public void Send(object sender, IMessage message, Type receiverType)
        {
            Debug.Assert(false, "Cannot send a message with NoMessageSender");
        }

        public void Send(object sender, IMessage message, Type[] receiverTypes)
        {
            Debug.Assert(false, "Cannot send a message with NoMessageSender");
        }

        public void Send(object sender, IMessage message, IMessageReceiver instance)
        {
            Debug.Assert(false, "Cannot send a message with NoMessageSender");
        }

        #endregion
    }
}