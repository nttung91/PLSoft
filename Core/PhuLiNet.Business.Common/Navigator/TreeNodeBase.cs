using System.Diagnostics;
using PhuLiNet.Business.Common.Navigator.Interfaces;

namespace PhuLiNet.Business.Common.Navigator
{
    public abstract class TreeNodeBase : ITreeNodeBase
    {
        public TreeNodeBase(int id, int parentID, string description)
        {
            Debug.Assert(id != 0, "Id ist 0");
            Debug.Assert(description != null, "Description ist null");

            ID = id;
            ParentID = parentID;
            Description = description;
        }

        public int ID { get; private set; }
        public int ParentID { get; private set; }
        public string Description { get; private set; }
    }
}