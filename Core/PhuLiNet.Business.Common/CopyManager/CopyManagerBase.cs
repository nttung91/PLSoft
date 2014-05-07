using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.CopyManager
{
    public abstract class CopyManagerBase : ICopyManager<IPhuLiBusinessBase>
    {
        protected readonly IPhuLiBusinessBase BusinessObject;

        public static string CopyPrefixText = CopyManagerMessages.CopyPrefixText;

        protected CopyManagerBase(IPhuLiBusinessBase businessObject)
        {
            BusinessObject = businessObject;
        }

        public abstract IPhuLiBusinessBase Copy();
    }
}