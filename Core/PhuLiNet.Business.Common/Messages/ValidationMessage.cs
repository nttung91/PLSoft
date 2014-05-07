using System;

namespace PhuLiNet.Business.Common.Messages
{
    /// <summary>
    /// Validation message base class
    /// </summary>
    [Serializable()]
    public class ValidationMessage : IValidationMessage, ICloneable
    {
        private int? _artId;
        private string _messageType;
        private DateTime? _messageDate;
        private MessageSeverity? _severity;
        private string _description;
        private string _affectedId;
        private string _affectedDescr;

        public int? ArtId
        {
            get { return _artId; }
        }

        public string MessageType
        {
            get { return _messageType; }
        }

        public DateTime? MessageDate
        {
            get { return _messageDate; }
        }

        public MessageSeverity? Severity
        {
            get { return _severity; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string AffectedId
        {
            get { return _affectedId; }
        }

        public string AffectedDescr
        {
            get { return _affectedDescr; }
        }

        private ValidationMessage(int? artId, string messageType, DateTime? messageDate, MessageSeverity? severity,
            string description, string affectedId, string affectedDecr)
        {
            _artId = artId;
            _messageType = messageType;
            _messageDate = messageDate;
            _severity = severity;
            _description = description;
            _affectedId = affectedId;
            _affectedDescr = affectedDecr;
        }

        public static ValidationMessage NewValidationMessage(int? artId, string messageType, DateTime? messageDate,
            MessageSeverity? severity, string description, string affectedId, string affectedDecr)
        {
            return new ValidationMessage(artId, messageType, messageDate, severity, description, affectedId,
                affectedDecr);
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return GetClone();
        }

        #endregion

        public ValidationMessage Clone()
        {
            return GetClone();
        }

        private ValidationMessage GetClone()
        {
            var clone = new ValidationMessage(_artId, _messageType, _messageDate, _severity, _description, _affectedId,
                _affectedDescr);
            return clone;
        }
    }
}