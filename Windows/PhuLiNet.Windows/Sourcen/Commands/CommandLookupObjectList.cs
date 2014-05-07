using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhuLiNet.Business.Common.Lookup;

namespace Windows.Core.Commands
{
    public class CommandLookupObjectList
    {
        public bool AllowNullSelection { get; set; }
        public bool UnitTestingMode { get; set; }

        public string SelectedDisplayText { get; private set; }

        public IList<TO> Lookup<TO, TL>(TL lookupObjectList, IList<TO> selectedObjects)
            where TO : class, ILookupObject
            where TL : ILookupObjectList
        {
            IList<ILookupObject> selected = null;
            if (selectedObjects != null) selected = selectedObjects.Cast<ILookupObject>().ToList();

            var command = new CommandLookup(lookupObjectList, selected, AllowNullSelection, true);
            command.UnitTestingMode = UnitTestingMode;
            CommandExecutor.Execute(command);

            SelectedDisplayText = BuildDisplayText(command.SelectedObjects);

            return command.SelectedObjects != null ? command.SelectedObjects.Cast<TO>().ToList() : null;
        }

        public static string BuildDisplayText<TO>(IEnumerable<TO> selectedObjects) where TO : class, ILookupObject
        {
            var text = string.Empty;
            if (selectedObjects != null)
            {
                var displayTextBuilder = new StringBuilder();

                foreach (var selected in selectedObjects)
                {
                    displayTextBuilder.Append(string.Format("{0} {1}, ", selected.LookupKey, selected.LookupName));
                }
                text = displayTextBuilder.ToString().TrimEnd(new[] {',', ' '});
            }
            return text;
        }
    }
}