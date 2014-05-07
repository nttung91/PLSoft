using System;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.Messaging;
using Windows.Core.Messaging.Handler;

namespace Windows.Core.Commands
{
    public class DeleteBusinessObjectCommand : DeleteBusinessObjectCommand<IPhuLiBusinessBase>
    {
        public DeleteBusinessObjectCommand(IPhuLiBusinessBase businessObject, Type previewItemType)
            : base(businessObject, previewItemType)
        {
        }
    }

    public class DeleteBusinessObjectCommand<T> : BaseDeleteBusinessObjectCommand<T>
        where T : IPhuLiBusinessBase
    {
        private readonly Type _previewItemType;
        private readonly IMessageHandler _msgHandler;

        public DeleteBusinessObjectCommand(T businessObject, Type previewItemType)
            : base(businessObject)
        {
            _previewItemType = previewItemType;
            _msgHandler = MessageHandlerFactory.GetDefaultMessageHandler();
        }

        public override void Execute()
        {
            if (!CheckAndConfirmDelete())
            {
                return;
            }

            var msg = new CloseMessage(BusinessObject.IdValue, _previewItemType);
            _msgHandler.Send(msg);
            if (msg.Handled && !msg.Closed)
            {
                return;
            }

            if (!BusinessObject.IsNew)
            {
                BusinessObject.CancelEdit();
                DeleteCall();
                BusinessObject.ApplyEdit();

                BusinessObject.Save();

                var message = new ItemChangedMessage(BusinessObject.IdValue, _previewItemType, ItemChangedMode.Delete);
                _msgHandler.Send(message);
            }
        }

        public virtual void DeleteCall()
        {
            BusinessObject.Delete();
        }

        protected override bool NeedsDeleteCheck()
        {
            return !BusinessObject.IsNew;
        }
    }
}