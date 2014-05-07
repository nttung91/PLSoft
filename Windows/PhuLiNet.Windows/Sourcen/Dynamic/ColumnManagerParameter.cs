using Windows.Core.Dynamic;
using Techical.Dynamic.Manager;
using Techical.Dynamic.Manager;

namespace Windows.Core.Dynamic
{
    public class ColumnManagerParameter
    {
        public ColumnManagerBase ColumnManager { get; set; }
        public IGridCreateParameters Parameters { get; set; }

        public ColumnManagerParameter(ColumnManagerBase columnManager, IGridCreateParameters parameters)
        {
            ColumnManager = columnManager;
            Parameters = parameters;
        }

        public void SetHeader()
        {
            Parameters.HeaderList = ColumnManager.GetHeader();
        }
    }
}