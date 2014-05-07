using System.Windows.Forms;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.Localization;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.Commands
{
    public abstract class BaseDeleteBusinessObjectCommand<T> : BaseWindowCommand
        where T : IPhuLiBusinessBase
    {
        protected readonly T BusinessObject;

        protected BaseDeleteBusinessObjectCommand(T businessObject)
        {
            BusinessObject = businessObject;
        }

        protected bool CheckAndConfirmDelete()
        {
            if (NeedsDeleteCheck())
            {
                var result = BusinessObject.CanDelete();
                if (!result.Allowed)
                {
                    var reason = result.CreateMessage(CommandRes.CantDelete);
                    MessageBox.ShowWarning(reason);
                    return false;
                }
            }

            return Confirmation();
        }

        protected virtual bool Confirmation()
        {
            var dr = MessageBox.ShowYesNo(CommandRes.DeleteConfirmation, CommandRes.DeleteEntry);
            return (dr == DialogResult.Yes);
        }

        protected virtual bool NeedsDeleteCheck()
        {
            return true;
        }
    }
}