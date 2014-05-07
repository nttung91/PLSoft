using System;

namespace PhuLiNet.Business.Common.Messages
{
    /// <summary>
    /// Validation message interface
    /// </summary>
    public interface IValidationMessage
    {
        int? ArtId { get; }
        string MessageType { get; }
        DateTime? MessageDate { get; }
        MessageSeverity? Severity { get; }
        string Description { get; }
        string AffectedId { get; }
        string AffectedDescr { get; }
    }
}