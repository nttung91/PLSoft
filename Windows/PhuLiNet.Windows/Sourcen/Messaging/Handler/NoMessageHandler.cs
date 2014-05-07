using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Core.Messaging.Sender;

namespace Windows.Core.Messaging.Handler
{
    /// <summary>
    /// An message handler with no messages and no messages can be received.
    /// </summary>
    internal class NoMessageHandler : BaseMessageHandler
    {
        protected IMessageSender _messageSender;

        internal NoMessageHandler()
        {
            _messageSender = MessageSenderFactory.GetNoMessageSender();
        }

        public override void Add(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
        }

        public override void Remove(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
        }

        public override IList<IMessage> Messages()
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
            return null;
        }

        public override IList<IMessage> ActiveMessages()
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
            return null;
        }

        public override void Activate(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
        }

        public override void Deactivate(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
        }

        public override bool Exists(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
            return false;
        }

        public override bool ExistsAndActive(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
            return false;
        }

        public override bool IsActive(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
            return false;
        }

        public override bool CanReceive(IMessage message)
        {
            Debug.Assert(false, "Not possible with NoMessageHandler");
            return false;
        }

        public override void Receive(IMessage message)
        {
        }

        public override void Send(IMessage message)
        {
            _messageSender.Send(this, message);
        }

        public override void Send(IMessage message, Type receiverType)
        {
            _messageSender.Send(this, message, receiverType);
        }
    }
}