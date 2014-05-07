using PhuLiNet.Business.Common.CslaBase;

namespace Windows.Core.Commands
{
    public class DeleteChildBusinessObjectCommand : DeleteChildBusinessObjectCommand<IPhuLiBusinessBase>
    {
        public DeleteChildBusinessObjectCommand(IPhuLiBusinessBase businessObject)
            : base(businessObject)
        {
        }
    }

    public class DeleteChildBusinessObjectCommand<T> : BaseDeleteBusinessObjectCommand<T>
        where T : IPhuLiBusinessBase
    {
        public bool WasDeleted { get; private set; }

        public DeleteChildBusinessObjectCommand(T businessObject)
            : base(businessObject)
        {
        }

        public override void Execute()
        {
            if (!CheckAndConfirmDelete())
            {
                return;
            }

            DeleteCall();
        }

        protected override bool Confirmation()
        {
            return true;
        }

        public virtual void DeleteCall()
        {
            var parentEditList = (IPhuLiBusinessBindingListBase) BusinessObject.Parent;
            parentEditList.RemoveChild(BusinessObject);
            WasDeleted = true;
        }
    }
}