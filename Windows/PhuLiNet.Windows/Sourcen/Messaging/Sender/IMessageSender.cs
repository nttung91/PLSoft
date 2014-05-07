using System;
using Windows.Core.Messaging.Handler;

namespace Windows.Core.Messaging.Sender
{
    internal interface IMessageSender
    {
        /// <summary>
        /// Send a message to all forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        void Send(object sender, IMessage message);

        /// <summary>
        /// Send a message only to a specific form type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiverType"></param>
        /// <param name="message"></param>
        void Send(object sender, IMessage message, Type receiverType);

        /// <summary>
        /// Send a message only to some specific form types
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiverTypes"></param>
        /// <param name="message"></param>
        void Send(object sender, IMessage message, Type[] receiverTypes);

        /// <summary>
        /// Send a message only to a specific message receiver instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="instance"></param>
        void Send(object sender, IMessage message, IMessageReceiver instance);
    }
}