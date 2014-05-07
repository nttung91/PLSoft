using System;
using System.Collections.Generic;

namespace Windows.Core.Messaging.Handler
{
    public abstract class BaseMessageHandler : IMessageHandler, IMessageReceiver
    {
        protected BaseMessageHandler()
        {
        }

        #region IMessageHandler Members

        public event OnReceiveMessageEventHandler OnReceiveMessage;

        /// <summary>
        /// Add message to receive
        /// </summary>
        /// <param name="message"></param>
        public virtual void Add(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove message to receive
        /// </summary>
        /// <param name="message"></param>
        public virtual void Remove(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all messages which are receivable
        /// </summary>
        /// <returns></returns>
        public virtual IList<IMessage> Messages()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all active messages
        /// </summary>
        /// <returns></returns>
        public virtual IList<IMessage> ActiveMessages()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Activates an message
        /// </summary>
        /// <param name="message"></param>
        public virtual void Activate(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deactivates an message
        /// </summary>
        /// <param name="message"></param>
        public virtual void Deactivate(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is the message existent?
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual bool Exists(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is the message existent and active?
        /// </summary>
        /// <returns></returns>
        public virtual bool ExistsAndActive(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is the message active?
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual bool IsActive(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Can the message be received?
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual bool CanReceive(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a message to all forms
        /// </summary>
        /// <param name="message"></param>
        public virtual void Send(IMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a message only to a specific form type
        /// </summary>
        /// <param name="message"></param>
        /// <param name="receiverType"></param>
        public virtual void Send(IMessage message, Type receiverType)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IMessageReceiver Members

        public virtual void Receive(IMessage message)
        {
            throw new NotImplementedException();
        }

        #endregion

        // Invoke the receive message event
        protected virtual void InvokeReceiveEvent(IMessage message)
        {
            //send event to owner
            if (OnReceiveMessage != null)
                OnReceiveMessage(this, new ReceiveMessageEventArgs(message));
        }
    }
}