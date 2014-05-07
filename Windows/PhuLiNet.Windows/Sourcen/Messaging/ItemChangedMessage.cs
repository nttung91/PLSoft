using System;

namespace Windows.Core.Messaging
{
    public enum ItemChangedMode
    {
        AddOrUpdate,
        Delete
    }

    public class ItemChangedMessage : PreviewItemBaseMessage
    {
        public ItemChangedMode Mode { get; private set; }

        public ItemChangedMessage()
        {
        }

        public ItemChangedMessage(object businessObjectId, Type previewItemType,
            ItemChangedMode mode = ItemChangedMode.AddOrUpdate)
            : base(businessObjectId, previewItemType)
        {
            Mode = mode;
        }
    }
}