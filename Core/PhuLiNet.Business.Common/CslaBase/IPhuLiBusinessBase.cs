using Csla.Core;
using PhuLiNet.Business.Common.Authorization;
using PhuLiNet.Business.Common.Rules;

namespace PhuLiNet.Business.Common.CslaBase
{
    public interface IPhuLiBusinessBase : IValidateBusiness, IEditableBusinessObject, ISavable, IBrokenBusinessRules
    {
        object IdValue { get; }
        CheckCommandResult CanDelete();
        bool IsPropertyDirty(IPropertyInfo property);
        void RemoveIsDirtyFlag();
        void RemoveIsDirtyAndIsNewFlag();
        IParent Parent { get; }
    }
}