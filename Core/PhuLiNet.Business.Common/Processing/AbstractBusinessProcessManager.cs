using System.Collections.Generic;

namespace PhuLiNet.Business.Common.Processing
{
    /// <summary>
    /// Basisklasse für die Ausführung von mehreren Geschäftsprozessen nacheinander.
    /// Es können mehrere Prozesse hinzugefügt und innerhalb einer Transaktion
    /// ausgeführt werden.
    /// ACHTUNG: Nicht als Basisklasse für einen einzelnen Prozess benutzen.
    /// </summary>
    public abstract class AbstractBusinessProcessManager : AbstractBusinessProcess
    {
        protected IList<IBusinessProcess> _businessProcessesToExecute;

        public AbstractBusinessProcessManager()
        {
            _businessProcessesToExecute = new List<IBusinessProcess>();
            _isComposable = false;
        }

        public void AddProcess(IBusinessProcess process)
        {
            _businessProcessesToExecute.Add(process);
        }

        public void RemoveProcess(IBusinessProcess process)
        {
            _businessProcessesToExecute.Remove(process);
        }

        public void RemoveAll()
        {
            _businessProcessesToExecute.Clear();
        }
    }
}