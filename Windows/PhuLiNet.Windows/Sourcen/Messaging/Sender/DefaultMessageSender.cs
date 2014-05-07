using System;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.Messaging.Handler;
using Windows.Core.WindowsManager;

namespace Windows.Core.Messaging.Sender
{
    internal class DefaultMessageSender : IMessageSender
    {
        internal DefaultMessageSender()
        {
        }

        #region IMessageSender Members

        public void Send(object sender, IMessage message)
        {
            foreach (Form form in WindowManager.GetInstance().GetMainWindow().MdiChildren)
            {
                var formMessages = form as IFormMessages;

                if (formMessages != null &&
                    formMessages.MessageHandler != null &&
                    formMessages.MessageHandler != sender &&
                    !(formMessages.MessageHandler is NoMessageHandler))
                {
                    if (formMessages.MessageHandler.CanReceive(message))
                    {
                        formMessages.MessageReceiver.Receive(message);
                    }
                }
            }
        }

        public void Send(object sender, IMessage message, Type receiverType)
        {
            foreach (Form form in WindowManager.GetInstance().GetMainWindow().MdiChildren)
            {
                var formMessages = form as IFormMessages;

                if (formMessages != null &&
                    formMessages.MessageHandler != null &&
                    formMessages.MessageHandler != sender &&
                    !(formMessages.MessageHandler is NoMessageHandler) &&
                    form.GetType() == receiverType)
                {
                    if (formMessages.MessageHandler.CanReceive(message))
                    {
                        formMessages.MessageReceiver.Receive(message);
                    }
                }
            }
        }

        public void Send(object sender, IMessage message, Type[] receiverTypes)
        {
            throw new NotImplementedException();
        }

        public void Send(object sender, IMessage message, IMessageReceiver instance)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}