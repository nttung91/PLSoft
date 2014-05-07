using System;

namespace Windows.Core.Messaging
{
    public class PreviewItemBaseMessage : IMessage
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public bool Active { get; protected set; }

        public Type PreviewItemType { get; private set; }
        public object BusinessObjectId { get; private set; }

        protected PreviewItemBaseMessage()
        {
            var msgId = GetType().Name;
            Id = msgId;
            Name = msgId;
            Active = true;
        }

        protected PreviewItemBaseMessage(object businessObjectId, Type previewItemType)
            : this()
        {
            BusinessObjectId = businessObjectId;
            PreviewItemType = previewItemType;
        }
    }
}