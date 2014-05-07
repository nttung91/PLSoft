using System.Collections.Generic;
using PhuLiNet.Business.Common.Lookup;

namespace Windows.Core.Commands
{
    public class CommandLookupObject
    {
        public bool AllowNullSelection { get; set; }
        public bool UnitTestingMode { get; set; }

        public TO Lookup<TO, TL>(TL lookupObjectList, TO selectedObject)
            where TO : class, ILookupObject
            where TL : ILookupObjectList
        {
            var selectedObjects = new List<ILookupObject>();
            if (selectedObject != null) selectedObjects.Add(selectedObject);

            var command = new CommandLookup(lookupObjectList, selectedObjects, AllowNullSelection, false);
            command.UnitTestingMode = UnitTestingMode;
            CommandExecutor.Execute(command);

            if (command.SelectedObjects != null && command.SelectedObjects.Count == 1)
            {
                return (TO) command.SelectedObjects[0];
            }
            return default(TO);
        }
    }
}