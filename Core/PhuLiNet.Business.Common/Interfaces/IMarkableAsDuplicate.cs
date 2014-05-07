namespace PhuLiNet.Business.Common.Interfaces
{
    /// <summary>
    /// Object is markable as a duplicate. 
    /// The MarkAsDuplicate() function is called automatically by the EditTreeDuplicator.
    /// You can implement this interface on editable classes, maybe to reset database id's.
    /// </summary>
    public interface IMarkableAsDuplicate
    {
        void MarkAsDuplicate();
    }
}