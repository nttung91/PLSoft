using System.Collections.Generic;
using Techical.Dynamic.Property;

namespace Techical.Dynamic.Manager
{
    public class ColumnManagerHandler : ColumnManagerHandlerBase
    {
        public IList<IHasDynamicProperties> ListOfObjectsWithDynamicProperties { get; set; }

        public ColumnManagerHandler()
        {
        }

        public ColumnManagerHandler(IList<IHasDynamicProperties> listOfObjectsWithDynamicProperties)
        {
            ListOfObjectsWithDynamicProperties = listOfObjectsWithDynamicProperties;
        }

        public override void CreateData()
        {
            foreach (var columnManager in ColumnManagers)
            {
                var columnManagerBase = columnManager as ColumnManagerBase;
                if (columnManagerBase != null)
                {
                    columnManagerBase.ListOfObjectsWithDynamicProperties = ListOfObjectsWithDynamicProperties;
                }
                columnManager.CreateData();
            }
        }
    }
}