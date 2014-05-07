using System.Collections.Generic;
using System.Windows.Forms;
using Windows.Core.Helpers;
using PhuLiNet.Business.Common.Lookup;
using Windows.Core.Forms.Lookup;
using Windows.Core.Helpers;

namespace Windows.Core.Commands
{
    public class CommandLookup : BaseDialogCommand
    {
        private IList<ILookupObject> _selectedObjects;
        private readonly ILookupObjectList _lookupObjectList;
        private readonly bool _allowNullSelection;
        private readonly bool _allowMultiSelection;
        private bool _lookupByKey = true;
        private bool _lookupByName;

        public bool LookupByKey
        {
            get { return _lookupByKey; }
            set { _lookupByKey = value; }
        }

        public bool LookupByName
        {
            get { return _lookupByName; }
            set
            {
                _lookupByName = value;
                _lookupByKey = !value;
            }
        }

        public bool UnitTestingMode { get; set; }

        public IList<ILookupObject> SelectedObjects
        {
            get { return _selectedObjects; }
        }

        public CommandLookup(ILookupObjectList lookupObjectList, IList<ILookupObject> selectedObjects,
            bool allowNullSelection, bool allowMultiSelection)
        {
            _selectedObjects = selectedObjects;
            _lookupObjectList = lookupObjectList;
            _allowNullSelection = allowNullSelection;
            _allowMultiSelection = allowMultiSelection;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (!UnitTestingMode)
            {
                FrmLookupObject lookupDialog;

                using (new StatusBusy("Auswahl wird geladen", false))
                {
                    lookupDialog = new FrmLookupObject(_lookupObjectList, _selectedObjects, _allowNullSelection,
                        _allowMultiSelection, _lookupByKey, _lookupByName);
                }

                var dr = lookupDialog.ShowDialog();

                if (dr == DialogResult.OK)
                    _selectedObjects = lookupDialog.SelectedObjects;

                lookupDialog.Dispose();
            }
            else
            {
                if (_selectedObjects == null) _selectedObjects = new List<ILookupObject>();
            }
        }

        #endregion
    }
}