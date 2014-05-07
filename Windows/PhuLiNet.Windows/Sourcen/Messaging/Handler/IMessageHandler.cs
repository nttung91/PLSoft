using System;
using System.Collections.Generic;

namespace Windows.Core.Messaging.Handler
{
    public interface IMessageHandler
    {
        event OnReceiveMessageEventHandler OnReceiveMessage;

        /// <summary>
        /// Add message to receive
        /// </summary>
        /// <param name="message"></param>
        void Add(IMessage message);

        /// <summary>
        /// Remove message to receive
        /// </summary>
        /// <param name="message"></param>
        void Remove(IMessage message);

        /// <summary>
        /// Returns all messages which are receivable
        /// </summary>
        /// <returns></returns>
        IList<IMessage> Messages();

        /// <summary>
        /// Returns all active messages
        /// </summary>
        /// <returns></returns>
        IList<IMessage> ActiveMessages();

        /// <summary>
        /// Activates an message
        /// </summary>
        /// <param name="message"></param>
        void Activate(IMessage message);

        /// <summary>
        /// Deactivates an message
        /// </summary>
        /// <param name="message"></param>
        void Deactivate(IMessage message);

        /// <summary>
        /// Is the message existent?
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool Exists(IMessage message);

        /// <summary>
        /// Is the message existent and active?
        /// </summary>
        /// <returns></returns>
        bool ExistsAndActive(IMessage message);

        /// <summary>
        /// Is the message active?
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool IsActive(IMessage message);

        /// <summary>
        /// Can the message be received?
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool CanReceive(IMessage message);

        /// <summary>
        /// Sends a message to all forms
        /// </summary>
        /// <param name="message"></param>
        void Send(IMessage message);

        /// <summary>
        /// Sends a message only to a specific form type
        /// </summary>
        /// <param name="message"></param>
        /// <param name="receiverType"></param>
        void Send(IMessage message, Type receiverType);
    }
}