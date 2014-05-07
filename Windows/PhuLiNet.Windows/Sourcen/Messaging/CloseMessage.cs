using System;

namespace Windows.Core.Messaging
{
    public class CloseMessage : PreviewItemBaseMessage
    {
        public bool Save { get; set; }
        public bool Handled { get; set; }
        public bool Closed { get; set; }

        public CloseMessage()
        {
        }

        public CloseMessage(object businessObjectId, Type previewItemType, bool save = false)
            : base(businessObjectId, previewItemType)
        {
            Save = save;
        }
    }
}