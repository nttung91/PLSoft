namespace PhuLiNet.Business.Common.Navigator.Interfaces
{
    public interface ITreeNodeBase
    {
        int ID { get; }
        int ParentID { get; }
        string Description { get; }
    }
}