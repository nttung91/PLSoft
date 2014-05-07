using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Core.Messaging.Sender;

namespace Windows.Core.Messaging.Handler
{
    /// <summary>
    /// Default message handler.
    /// </summary>
    internal class DefaultMessageHandler : BaseMessageHandler
    {
        protected Dictionary<string, IMessage> _messages;
        protected IMessageSender _messageSender;

        internal DefaultMessageHandler()
        {
            _messages = new Dictionary<string, IMessage>();
            _messageSender = MessageSenderFactory.GetDefaultMessageSender();
        }

        public override void Add(IMessage message)
        {
            Debug.Assert(message != null, "message is null");
            Debug.Assert(!_messages.ContainsKey(message.Id), "message exists already");
            Debug.Assert(!_messages.ContainsValue(message), "message exists already");

            if (!_messages.ContainsKey(message.Id))
            {
                _messages.Add(message.Id, message);
            }
        }

        public override void Remove(IMessage message)
        {
            Debug.Assert(message != null, "message is null");

            if (_messages.ContainsKey(message.Id))
            {
                _messages.Remove(message.Id);
            }
        }

        public override IList<IMessage> Messages()
        {
            IList<IMessage> messageList = new List<IMessage>();

            foreach (KeyValuePair<string, IMessage> pair in _messages)
            {
                messageList.Add(pair.Value);
            }

            return messageList;
        }

        public override IList<IMessage> ActiveMessages()
        {
            IList<IMessage> messageList = new List<IMessage>();

            foreach (KeyValuePair<string, IMessage> pair in _messages)
            {
                if (pair.Value.Active)
                {
                    messageList.Add(pair.Value);
                }
            }

            return messageList;
        }

        public override void Activate(IMessage message)
        {
            Debug.Assert(message != null, "message is null");
            Debug.Assert(_messages.ContainsKey(message.Id), "message does not exist");

            if (_messages.ContainsKey(message.Id))
            {
                ((BaseMessage) _messages[message.Id]).Active = true;
            }
        }

        public override void Deactivate(IMessage message)
        {
            Debug.Assert(message != null, "message is null");
            Debug.Assert(_messages.ContainsKey(message.Id), "message does not exist");

            if (_messages.ContainsKey(message.Id))
            {
                ((BaseMessage) _messages[message.Id]).Active = false;
            }
        }

        public override bool Exists(IMessage message)
        {
            Debug.Assert(message != null, "message is null");

            return _messages.ContainsKey(message.Id);
        }

        public override bool ExistsAndActive(IMessage message)
        {
            Debug.Assert(message != null, "message is null");

            return (_messages.ContainsKey(message.Id) && _messages[message.Id].Active);
        }

        public override bool CanReceive(IMessage message)
        {
            Debug.Assert(message != null, "message is null");

            return (_messages.ContainsKey(message.Id) && _messages[message.Id].Active);
        }

        public override bool IsActive(IMessage message)
        {
            Debug.Assert(message != null, "message is null");
            Debug.Assert(_messages.ContainsKey(message.Id), "message does not exist");

            return (_messages[message.Id].Active);
        }

        public override void Receive(IMessage message)
        {
            Debug.Assert(message != null, "message is null");
            Debug.Assert(_messages.ContainsKey(message.Id), "message does not exist");
            Debug.Assert(_messages[message.Id].Active, "message is not active");

            if (_messages.ContainsKey(message.Id) && _messages[message.Id].Active)
            {
                InvokeReceiveEvent(message);
            }
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