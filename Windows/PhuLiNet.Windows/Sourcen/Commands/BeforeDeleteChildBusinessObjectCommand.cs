using PhuLiNet.Business.Common.CslaBase;

namespace Windows.Core.Commands
{
    public class BeforeDeleteChildBusinessObjectCommand<T> : BaseDeleteBusinessObjectCommand<T>
        where T : IPhuLiBusinessBase
    {
        public bool DeleteConfirmed { get; private set; }

        public BeforeDeleteChildBusinessObjectCommand(T businessObject)
            : base(businessObject)
        {
        }

        public override void Execute()
        {
            DeleteConfirmed = CheckAndConfirmDelete();
        }
    }
}