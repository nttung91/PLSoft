using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.CopyManager
{
    public class StandardCopyManager : CopyManagerBase
    {
        public StandardCopyManager(IPhuLiBusinessBase businessObject) : base(businessObject)
        {
        }

        public override IPhuLiBusinessBase Copy()
        {
            var duplicateableBusinessObject = (IDuplicateBusiness<IPhuLiBusinessBase>) BusinessObject;
            return duplicateableBusinessObject.Duplicate();
        }
    }
}