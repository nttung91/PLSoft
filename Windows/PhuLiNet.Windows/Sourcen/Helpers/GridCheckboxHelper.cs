using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Card.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using Windows.Core.Localization;
using Windows.Core.Properties;

namespace Windows.Core.Helpers
{
    // =====================================================================================
    /// <summary>
    /// GridCheckboxHelper
    /// Die Helper-Klasse verwaltet eine (Checkbox-)Column in einem Grid, mit der ein- oder
    /// mehrere Zeilen ausgewählt werden können.
    /// Das an die checkbox gebundene Feld sollte drei States verwalten können. Verwendbar
    /// sind zB string, int, bool? Probleme macht die Verwendung von bool.
    /// Es wird ein RepositoryItemCheckEdit als ColumnEdit auf der GridColumn erwarten, 
    /// falls es nicht vorhanden ist, wird es angelegt.
    /// Die Properties ValueChecked, ValueUnchecked und ValueGrayed sollten korrekt gesetzt sein.
    /// 
    /// Features:
    /// - Es wird ein "Alle selektieren"-Button verwaltet.
    /// - Es wird ein Label verwaltet, das die Anzahl der selektierten Sätze anzeigt.
    /// - Aendert sich die Anzahl der selektieren Sätze, kann ein Event getriggert werden.
    /// - Das Kontext-Menu bekommt drei Einträge "Select all", "Deselect all" und "Invert selection"
    /// - Ist das Grid Gruppiert, bekommt das Kontext-Menu 2 weitere Einträge "select Group" und "Add Group"
    /// - Ueber ein Delegate kann eine Prüfung angehängt werden, ob ein Satz überhaupt selektierbar ist. 
    ///   Ist er das nicht, wird die Checkbox versteckt. 
    /// - Filter:
    ///   Wird ein Filter gesetzt, werden Rows, die nicht mehr sichtbar sind auch nicht mehr als
    ///   selektiert gewertet. Wird der Filter aufgehoben, sind sie aber wieder selektiert.
    /// Texte:
    /// Die Default-Texte für den Button, das Label und die Kontext-MenuItems sind über Properties
    /// änderbar.
    /// </summary>
    public delegate void SelectCountChangeDelegate();

    /// <summary>
    /// Zum Überprüfen, ob eine Row selektiert werden darf.
    /// </summary>
    /// <param name="rowHandle">Handle auf die zu prüfende Row</param>
    /// <returns>True, wenn Row selektiert werden darf.</returns>
    public delegate bool AllowSelectDelegate(int rowHandle);

    public class GridCheckboxHelper
    {
        private static string[] selectAllMsgs = {"Select All", "Alle selektieren"};
        private static string[] deselectAllMsgs = {"Deselect All", "Alle deselektieren"};
        private static string[] toggleSelectionMsgs = {"Invert Selection", "Auswahl umkehren"};
        private static string[] selectGroupMsgs = {"Select only this group", "Nur diese Gruppe auswählen"};
        private static string[] addGroupToSelectionMsgs = {"Add group to selection", "Gruppe zur Auswahl zufügen"};
        private static string[] selectedMsgs = {"{0} Rows selected.", "{0} Sätze ausgewählt."};
        private static string[] oneOrNoSelectedMsgs = {"{0} Row selected.", "{0} Satz ausgewählt."};

        // - - GridView und GridColumn
        private ColumnView _view;
        private GridColumn _checkColumn;

        private GridView GridView
        {
            get { return _view as GridView; }
        }

        private CardView CardView
        {
            get { return _view as CardView; }
        }

        private LayoutView LayoutView
        {
            get { return _view as LayoutView; }
        }

        // - - Button und Label.
        private Control buttonAll;

        private Control ButtonAll
        {
            get { return buttonAll; }
            set { buttonAll = value; }
        }

        private Control selectedLabel;

        private Control SelectedLabel
        {
            get { return selectedLabel; }
            set { selectedLabel = value; }
        }

        private int language = 0;

        public int Language
        {
            get { return language; }
            set
            {
                if (value == 0 || value == 1)
                {
                    language = value;
                    selectAllMsg = selectAllMsgs[language];
                    deselectAllMsg = deselectAllMsgs[language];
                    toggleSelectionMsg = toggleSelectionMsgs[language];
                    selectGroupMsg = selectGroupMsgs[language];
                    addGroupToSelectionMsg = addGroupToSelectionMsgs[language];
                    selectedMsg = selectedMsgs[language];
                    oneOrNoSelectedMsg = oneOrNoSelectedMsgs[language];
                }
                else if (value == -1)
                {
                    selectAllMsg = GridCheckboxHelperMessages.AlleSelektieren;
                    deselectAllMsg = GridCheckboxHelperMessages.AlleDeselektieren;
                    toggleSelectionMsg = GridCheckboxHelperMessages.AuswahlUmkehren;
                    selectGroupMsg = GridCheckboxHelperMessages.NurDieseGruppeAuswählen;
                    addGroupToSelectionMsg = GridCheckboxHelperMessages.GruppeZurAuswahlZufügen;
                    selectedMsg = GridCheckboxHelperMessages.X0SätzeAusgewählt;
                    oneOrNoSelectedMsg = GridCheckboxHelperMessages.X0SatzAusgewählt;
                }
                else
                    Debug.Assert(false, "GridCheckBoxHelper: Sprache nur Englisch (0) oder Deutsch (1)");
            }
        }

        private bool useSingleSelMsg = false;

        public bool UseSingleSelMsg
        {
            get { return useSingleSelMsg; }
            set { useSingleSelMsg = value; }
        }

        // - - Die Meldungen für Button und Label.
        /// <summary>
        /// Meldung für den "Select All"-Button und das MenuItem im Kontextmenu für Select all
        /// </summary>
        private string selectAllMsg = selectAllMsgs[0];

        public string SelectAllMsg
        {
            get { return selectAllMsg; }
            set
            {
                selectAllMsg = value;

                if (buttonAll != null && StatusAlleButton == EnumStatusAlleButton.Alle)
                    buttonAll.Text = value;
            }
        }

        /// <summary>
        /// Meldung für den "Select All"-Button und das MenuItem im Kontextmenu für Deselect all
        /// </summary>
        private string deselectAllMsg = deselectAllMsgs[0];

        public string DeselectAllMsg
        {
            get { return deselectAllMsg; }
            set
            {
                deselectAllMsg = value;

                if (buttonAll != null && StatusAlleButton == EnumStatusAlleButton.Keine)
                    buttonAll.Text = value;
            }
        }

        /// <summary>
        /// Meldung für das MenuItem im Kontextmenu für "Toggle selection"
        /// </summary>
        private string toggleSelectionMsg = toggleSelectionMsgs[0];

        public string ToggleSelectionMsg
        {
            get { return toggleSelectionMsg; }
            set { toggleSelectionMsg = value; }
        }

        /// <summary>
        /// Meldung für das MenuItem im Kontextmenu für "Nur diese Gruppe selektieren"
        /// </summary>
        private string selectGroupMsg = selectGroupMsgs[0];

        public string SelectGroupMsg
        {
            get { return selectGroupMsg; }
            set { selectGroupMsg = value; }
        }

        /// <summary>
        /// Meldung für das MenuItem im Kontextmenu für "Gruppe zu Selektion zufügen"
        /// </summary>
        private string addGroupToSelectionMsg = addGroupToSelectionMsgs[0];

        public string AddGroupToSelectionMsg
        {
            get { return addGroupToSelectionMsg; }
            set { addGroupToSelectionMsg = value; }
        }


        /// <summary>
        /// Falls selectedLabel gesetzt ist, wird dieser Text auf das Label geschrieben.
        /// Es muss {0} enthalten, das wird durch die Anzahl der selektieren Datensätze ersetzt.
        /// Beispiel: {0} Zeilen ausgewählt.
        /// </summary>
        private string selectedMsg = selectedMsgs[0];

        public string SelectedMsg
        {
            get { return selectedMsg; }
            set
            {
                if (value.Contains("{0}"))
                    selectedMsg = value;
                else
                    selectedMsg = "{0} " + value;

                if (selectedLabel != null)
                    selectedLabel.Text = string.Format(SelectedMsg, selectCount);
            }
        }

        /// <summary>
        /// Meldung, wenn nur ein Satz selektiert ist.
        /// </summary>
        private string oneOrNoSelectedMsg = oneOrNoSelectedMsgs[0];

        public string OneOrNoSelectedMsg
        {
            get { return oneOrNoSelectedMsg; }
            set
            {
                oneOrNoSelectedMsg = value;
                useSingleSelMsg = true;
            }
        }

        private int? allRowsCount = null;

        private int AllRowsCount
        {
            get
            {
                if (allRowsCount == null)
                    setAllRowsCount();
                return (int) allRowsCount;
            }
        }

        /// <summary>
        /// Anzahl der selektierten (angekreuzten) Zeilen
        /// </summary>
        private int selectCount = -1;

        public int SelectCount
        {
            get { return selectCount; }
            set
            {
                if (selectCount == value) return;

                selectCount = value;
                if (selectedLabel != null)
                {
                    if (useSingleSelMsg && value <= 1)
                        selectedLabel.Text = string.Format(OneOrNoSelectedMsg, selectCount);
                    else
                        selectedLabel.Text = string.Format(SelectedMsg, selectCount);
                }

                if (value == 0)
                    StatusAlleButton = EnumStatusAlleButton.Alle;
                else if (value == AllRowsCount)
                    StatusAlleButton = EnumStatusAlleButton.Keine;

                // Wenn gewünscht, über das Change-Event informieren.
                if (OnSelectCountChange != null)
                    OnSelectCountChange();
            }
        }

        /// <summary>
        /// Wenn > 0, wird bei SetAllRows der MausZeiger als Sanduhr angezeigt.
        /// </summary>
        private int hourglassThreshold = 100;

        public int HourglassThreshold
        {
            get { return hourglassThreshold; }
            set { hourglassThreshold = value; }
        }

        /// <summary>
        /// Eine Event-Routine, die immer ausgelöst wird, wenn sich der Zähler der 
        /// selektierten Zeilen ändert.
        /// </summary>
        public SelectCountChangeDelegate OnSelectCountChange;

        /// <summary>
        /// Ueber diese Routine kann gesetzt werden, ob eine Row überhaupt selektierbar ist.
        /// </summary>
        public AllowSelectDelegate AllowSelect;

        // - - StatusAlleButton: Was zeigt der "Alle" Button - - - - - - - - - - -
        private enum EnumStatusAlleButton
        {
            Alle,
            Keine
        };

        private EnumStatusAlleButton statusAlleButton = EnumStatusAlleButton.Keine;

        /// <summary>
        /// Reflektiert den Status des "Alle" / "Keine"-Buttons
        /// </summary>
        private EnumStatusAlleButton StatusAlleButton
        {
            get { return statusAlleButton; }
            set
            {
                statusAlleButton = value;
                if (buttonAll == null) return; // Gibt keinen Button.
                if (statusAlleButton == EnumStatusAlleButton.Alle)
                    buttonAll.Text = SelectAllMsg;
                else
                    buttonAll.Text = DeselectAllMsg;
            }
        }

        private RepositoryItemCheckEdit riceSelect;
        private RepositoryItemButtonEdit ribeHidden;

        public GridCheckboxHelper(GridColumn col)
            : this(col.View as GridView, col, null, null, -1)
        {
        }

        public GridCheckboxHelper(GridView gv, GridColumn col, int language)
            : this(gv, col, null, null, language)
        {
        }

        public GridCheckboxHelper(GridView gv, GridColumn col)
            : this(gv, col, null, null, 0)
        {
        }

        public GridCheckboxHelper(GridView gv, GridColumn col, Control buttonAll, Control selectedLabel)
            : this(gv, col, buttonAll, selectedLabel, 0)
        {
        }

        public GridCheckboxHelper(GridView gv, GridColumn col, Control buttonAll, Control selectedLabel, int language)
        {
            _view = gv;
            _checkColumn = col;
            Language = language;

            gv.ColumnFilterChanged -= new EventHandler(columnFilterChanged);
            gv.ColumnFilterChanged += new EventHandler(columnFilterChanged);

            setColumnEdit();

            ribeHidden = new RepositoryItemButtonEdit();
            ribeHidden.Name = "ribeButtonHidden";
            ribeHidden.Buttons.Clear();
            ribeHidden.TextEditStyle = TextEditStyles.HideTextEditor;

            gv.CustomRowCellEdit += new CustomRowCellEditEventHandler(gv_CustomRowCellEdit);

            this.buttonAll = buttonAll;
            if (this.buttonAll != null)
            {
                this.buttonAll.Click -= new EventHandler(buttonAllClicked);
                this.buttonAll.Click += new EventHandler(buttonAllClicked);
            }

            this.selectedLabel = selectedLabel;

            AdjustSelectedRows();

            setGridEvents();
        }

        private void setColumnEdit()
        {
            if (_checkColumn.ColumnEdit == null)
            {
                riceSelect = new RepositoryItemCheckEdit();
                _checkColumn.ColumnEdit = riceSelect;
            }
            else
                riceSelect = _checkColumn.ColumnEdit as RepositoryItemCheckEdit;

            riceSelect.CheckedChanged -= new EventHandler(checkedChanged);
            riceSelect.CheckedChanged += new EventHandler(checkedChanged);
        }


        private void setGridEvents()
        {
            if (GridView != null)
            {
                GridView.PopupMenuShowing -= new PopupMenuShowingEventHandler(showGridMenu);
                GridView.PopupMenuShowing += new PopupMenuShowingEventHandler(showGridMenu);
            }
            else
            {
                _view.MouseDown -= view_MouseDown;
                _view.MouseDown += view_MouseDown;
            }

            _view.RowCountChanged -= new EventHandler(gvRowCountChanged);
            _view.RowCountChanged += new EventHandler(gvRowCountChanged);

            _view.DataSourceChanged -= new EventHandler(gvDataSourceChanged);
            _view.DataSourceChanged += new EventHandler(gvDataSourceChanged);
        }


        private void checkedChanged(object sender, EventArgs e)
        {
            var edit = sender as CheckEdit;

            foreach (int zeilenNr in _view.GetSelectedRows())
            {
                _view.SetRowCellValue(zeilenNr, _checkColumn,
                    edit.Checked ? riceSelect.ValueChecked : riceSelect.ValueUnchecked);
                if (edit.Checked)
                    SelectCount++;
                else
                    SelectCount--;
            }
        }

        private void gv_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column != _checkColumn) return;

            bool allow = true;
            if (AllowSelect != null)
                allow = AllowSelect(e.RowHandle);

            if (allow)
            {
                e.RepositoryItem = riceSelect;
            }
            else
            {
                e.RepositoryItem = ribeHidden;
                // gv.SetRowCellValue(e.RowHandle, col, riceSelect.ValueUnchecked);
            }
        }

        private void view_MouseDown(object sender, MouseEventArgs e)
        {
            // Für CardView und LayoutView gibt es leider kein GridMenu-Event.
            if (e.Button != MouseButtons.Right) return;

            bool showMenu = false;
            if (_view is CardView)
            {
                CardHitInfo hi = (_view as CardView).CalcHitInfo(e.Location);
                showMenu = (hi.InCard);
            }
            else if (_view is LayoutView)
            {
                LayoutViewHitInfo hi = (_view as LayoutView).CalcHitInfo(e.Location);
                showMenu = (hi.InCard);
            }
            if (!showMenu) return;

            var dxMenu = new DXPopupMenu();
            createMenuItems(dxMenu);

            GridControl gc = _view.GridControl;
            MenuManagerHelper.ShowMenu(dxMenu, gc.LookAndFeel, null, gc, e.Location);


            ////             LayoutViewHitInfo hi = -.CalcHitInfo(GridControl1.PointToClient(p))
            ////        }
            ////        dxMenu.Items.Add(New DXMenuItem("Item1"))
            ////        dxMenu.Items.Add(New DXMenuItem("Item2"))
            ////        Dim p As Point = Control.MousePosition
            ////        Dim view As LayoutView = CType(sender, LayoutView)
            ////        Dim hi As LayoutViewHitInfo = view.CalcHitInfo(GridControl1.PointToClient(p))
            ////        If hi.HitTest = LayoutViewHitTest.CardCaption Then
            ////            MenuManagerHelper.ShowMenu(dxMenu, GridControl1.LookAndFeel, GridControl1, Nothing,
            ////GridControl1.PointToClient(p))
            ////        End If
            ////    End Sub
        }

        private void showGridMenu(object sender, PopupMenuShowingEventArgs e)
        {
            // Sind wir überhaupt auf einer Spalte?
            if (e.MenuType != GridMenuType.Row && e.MenuType != GridMenuType.Column)
                return;

            // Ist das die Select-Spalte oder eine Gruppierungrow?
            if (e.HitInfo.Column != _checkColumn && e.HitInfo.RowHandle >= 0)
                return;

            if (e.Menu.Items.Count > 0)
                e.Menu.Items[0].BeginGroup = true;

            int groupRowHandle = 0;
            if (GridView.GroupCount > 0 && e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle < 0)
                    groupRowHandle = e.HitInfo.RowHandle;
                else
                    groupRowHandle = GridView.GetParentRowHandle(e.HitInfo.RowHandle);
            }
            createMenuItems(e.Menu, groupRowHandle);
        }

        private void createMenuItems(DXPopupMenu menu)
        {
            createMenuItems(menu, 0);
        }

        private void createMenuItems(DXPopupMenu menu, int groupRowHandle)
        {
            // Jetzt gehts los.
            int menuItemNr = 0;
            DXMenuItem menuItem = null;

            // Menupunkte für Gruppen, falls Gruppierung an ist.
            if (groupRowHandle < 0)
            {
                menuItem = new DXMenuItem(SelectGroupMsg, menuItemSelectGroupClicked);
                menuItem.Tag = groupRowHandle;
                menuItem.Image = Resources.SelectGroup;
                menu.Items.Insert(menuItemNr++, menuItem);

                menuItem = new DXMenuItem(AddGroupToSelectionMsg, menuItemAddGroupClicked);
                menuItem.Tag = groupRowHandle;
                menuItem.Image = Resources.AddGroup;
                menu.Items.Insert(menuItemNr++, menuItem);
            }

            menuItem = new DXMenuItem(SelectAllMsg, menuItemAllClicked);
            menuItem.Tag = riceSelect.ValueChecked;
            menuItem.Image = Resources.SelectAll;
            menuItem.Enabled = selectCount < AllRowsCount;
            menu.Items.Insert(menuItemNr++, menuItem);

            menuItem = new DXMenuItem(DeselectAllMsg, menuItemAllClicked);
            menuItem.Tag = riceSelect.ValueUnchecked;
            menuItem.Image = Resources.DeselectAll;
            menuItem.Enabled = selectCount > 0;
            menu.Items.Insert(menuItemNr++, menuItem);

            menuItem = new DXMenuItem(ToggleSelectionMsg, menuItemToggleClicked);
            menuItem.Image = Resources.InvertSelection;
            menu.Items.Insert(menuItemNr++, menuItem);
        }


        // Daten filtern:
        // Hier folgt ein kleiner Hack: Wenn Daten gefiltert werden, bleiben die 
        // "rausgefilterten" Zeilen intern "angekreuzt"
        //
        // schalten wir den Filter kurzfristig aus, setzen dann alle angekreuzten Rows von checked auf grayed
        // schalten dann den Filter wieder an und alle jetzt sichtbaren Sätze von grayed auf checked.
        // (die unsichtbaren bleiben also auf grayed).
        //
        // Allerdings bewirkt das Setzen des Filters einen rekursiven Aufruf dieser Event-Methode.
        // Deswegen setzen wir ein Flag "onFiltering", um nicht in der Rekursion verloren zu gehen.
        private bool onFiltering = false;

        private void columnFilterChanged(object sender, EventArgs e)
        {
            if (onFiltering) return; // Rekursiver Aufruf...

            onFiltering = true;
            _view.ActiveFilterEnabled = false; // "Zeige" alle Rows

            bool triStatePossible = true;
            for (int handle = 0; handle < _view.DataRowCount; handle++)
            {
                if (_view.GetRowCellValue(handle, _checkColumn) != null &&
                    _view.GetRowCellValue(handle, _checkColumn).Equals(riceSelect.ValueChecked))
                {
                    _view.SetRowCellValue(handle, _checkColumn, riceSelect.ValueGrayed); // Alle angekreuzten auf grayed
                    if (_view.GetRowCellValue(handle, _checkColumn) != null &&
                        _view.GetRowCellValue(handle, _checkColumn).Equals(riceSelect.ValueChecked))
                        triStatePossible = false;
                    Debug.Assert(triStatePossible,
                        "GridCheckBoxHelper: Filter funktioniert nur bei Tri-State Cell-Values (eg bool?)");
                    // Hinweis: Wenn das nicht geklappt hat, dann ist für die Spalte kein TriState möglich
                    // (Datentyp bool), und wir können diese Logik leider nicht anwenden.
                    // Die ausgefilterten Sätze bleiben in diesem Fall angekreuzt.
                    // 
                    // Known Bug: Dann funktionert der "Select All"-Button nicht mehr richtig.
                }
            }

            _view.ActiveFilterEnabled = true; // Filter wieder anwenden.
            if (triStatePossible || _view.ActiveFilter.IsEmpty)
            {
                int cnt = 0;
                for (int handle = 0; handle < _view.DataRowCount; handle++)
                {
                    if (Equals(riceSelect.ValueGrayed, _view.GetRowCellValue(handle, _checkColumn))
                        || Equals(riceSelect.ValueChecked, _view.GetRowCellValue(handle, _checkColumn)))
                    {
                        _view.SetRowCellValue(handle, _checkColumn, riceSelect.ValueChecked);
                            // angekreuzten wieder auf zurück auf 1
                        cnt++;
                    }
                }
                SelectCount = cnt;
            }
            onFiltering = false;
        }

        private void menuItemToggleClicked(object sender, EventArgs e)
        {
            ToggleAllRows();
        }

        private void menuItemAllClicked(object sender, EventArgs e)
        {
            object value = (sender as DXMenuItem).Tag;
            SetAllRows(value);
        }

        private void menuItemSelectGroupClicked(object sender, EventArgs e)
        {
            var groupIndex = (int) (sender as DXMenuItem).Tag;
            selectGroup(groupIndex, true);
        }

        private void menuItemAddGroupClicked(object sender, EventArgs e)
        {
            var groupIndex = (int) (sender as DXMenuItem).Tag;
            selectGroup(groupIndex, false);
        }


        private void buttonAllClicked(object sender, EventArgs e)
        {
            object value = StatusAlleButton == EnumStatusAlleButton.Alle
                ? riceSelect.ValueChecked
                : riceSelect.ValueUnchecked;
            SetAllRows(value);
        }

        public void ChangeView(ColumnView newView, GridColumn newColumn)
        {
            _view = newView;
            _checkColumn = newColumn;

            setColumnEdit();
            setAllRowsCount();
            AdjustSelectedRows();
            setGridEvents();
        }

        /// <summary>
        /// Alle Zeilen ankreuzen oder wegkreuzen.
        /// (Alle Zeilen werden auf "value" gesetzt)
        /// </summary>
        /// <param name="value"></param>
        public void SetAllRows(object value)
        {
            Cursor saveCursor = Cursor.Current;
            if (HourglassThreshold > 0 && _view.DataRowCount >= HourglassThreshold)
                Cursor.Current = Cursors.WaitCursor;

            int cnt = SelectCount;
            try
            {
                for (int handle = 0; handle < _view.DataRowCount; handle++)
                {
                    bool allow = true;
                    if (Equals(riceSelect.ValueChecked, value) && AllowSelect != null)
                        allow = AllowSelect(handle);

                    if (allow && !Equals(_view.GetRowCellValue(handle, _checkColumn), value))
                    {
                        _view.SetRowCellValue(handle, _checkColumn, value);
                        cnt++;
                    }

                    // Console.WriteLine("Handle = " + handle + " = " + gv.GetRowLevel(handle) + " Parent = " + gv.GetParentRowHandle(handle));
                }

                // SelectedRows erst nach dem Ankreuzen ändern (Event nur einmal triggern)
                if (Equals(riceSelect.ValueChecked, value))
                    SelectCount = cnt;
                else
                    SelectCount = 0;
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        /// <summary>
        /// Eine einzelne Zeile ankreuzen oder wegkreuzen.
        /// </summary>
        /// <param name="rowHandle"></param>
        /// <param name="value"></param>
        public void SetRow(int rowHandle, object value)
        {
            bool allow = true;
            if (Equals(_view.GetRowCellValue(rowHandle, _checkColumn), value) && AllowSelect != null)
                allow = AllowSelect(rowHandle);

            if (allow && !Equals(_view.GetRowCellValue(rowHandle, _checkColumn), value))
            {
                _view.SetRowCellValue(rowHandle, _checkColumn, value);
                if (Equals(value, riceSelect.ValueChecked))
                    SelectCount++;
                else
                    SelectCount--;
            }
        }


        private void selectGroup(int groupHandle, bool resetOther)
        {
            var gridView = (_view as GridView);
            if (gridView == null) return;

            int cnt = SelectCount;
            for (int handle = 0; handle < _view.DataRowCount; handle++)
            {
                bool isInGroup = false;

                int parentHandle = gridView.GetParentRowHandle(handle);
                while (parentHandle != GridControl.InvalidRowHandle)
                {
                    if (parentHandle == groupHandle)
                    {
                        isInGroup = true;
                        break;
                    }
                    parentHandle = gridView.GetParentRowHandle(parentHandle);
                }


                if (isInGroup)
                {
                    bool allow = true;
                    if (AllowSelect != null)
                        allow = AllowSelect(handle);

                    if (allow && !Equals(_view.GetRowCellValue(handle, _checkColumn), riceSelect.ValueChecked))
                    {
                        _view.SetRowCellValue(handle, _checkColumn, riceSelect.ValueChecked);
                        cnt++;
                    }
                }
                else
                {
                    if (resetOther && !Equals(_view.GetRowCellValue(handle, _checkColumn), riceSelect.ValueUnchecked))
                    {
                        _view.SetRowCellValue(handle, _checkColumn, riceSelect.ValueUnchecked);
                        cnt--;
                    }
                }
            }
            // SelectedRows erst nach dem Ankreuzen ändern (Event nur einmal triggern)
            SelectCount = cnt;
        }


        public void ToggleAllRows()
        {
            Cursor saveCursor = Cursor.Current;
            if (HourglassThreshold > 0 && _view.DataRowCount >= HourglassThreshold)
                Cursor.Current = Cursors.WaitCursor;
            try
            {
                int cnt = 0;
                for (int handle = 0; handle < _view.DataRowCount; handle++)
                {
                    if (Equals(_view.GetRowCellValue(handle, _checkColumn), riceSelect.ValueChecked))
                    {
                        _view.SetRowCellValue(handle, _checkColumn, riceSelect.ValueUnchecked);
                        cnt--;
                    }
                    else
                    {
                        bool allow = true;
                        if (AllowSelect != null)
                            allow = AllowSelect(handle);
                        if (allow)
                        {
                            _view.SetRowCellValue(handle, _checkColumn, riceSelect.ValueChecked);
                            cnt++;
                        }
                    }
                }
                SelectCount += cnt;
            }
                // SelectedRows erst nach dem Ankreuzen ändern (Event nur einmal triggern)
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void gvRowCountChanged(object sender, EventArgs e)
        {
            setAllRowsCount();
        }

        // Wenn die DataSource geändert wird, müssen die bereits "angekreuzen" Rows gezählt werden.
        private void gvDataSourceChanged(object sender, EventArgs e)
        {
            AdjustSelectedRows();
        }

        /// <summary>
        /// Zählt, wieviele Rows insgesamt angekreuzt werden können
        /// </summary>
        public void setAllRowsCount()
        {
            // Wenn alle erlaubt sind, einfach die Anzahl Rows
            if (AllowSelect == null)
            {
                allRowsCount = _view.DataRowCount;
                return;
            }

            // Wenn das individuell ist, für jede Row prüfen ob sie ankreuzbar ist.
            int cnt = 0;
            for (int handle = 0; handle < _view.DataRowCount; handle++)
            {
                if (AllowSelect(handle))
                    cnt++;
            }
            allRowsCount = cnt;
        }

        /// <summary>
        /// Prüft für alle Rows, ob sie eigentlich angekreuzt werden dürfen. 
        /// Ist eine Row angekreuzt, obwohl sie es gar nicht dürfte, wird sie zurückgesetzt.
        /// Wird bei Aenderung der DataSource aufgerufen, und kann von aussen aufgerufen werden, wenn 
        /// sich in den Daten etwas ändert, dass Konsequenzen auf die "AllowEdit"-Eigenschaft hat.
        /// </summary>
        public void AdjustSelectedRows()
        {
            int cnt = 0;
            int allCnt = 0;

            for (int handle = 0; handle < _view.DataRowCount; handle++)
            {
                bool allow = true;
                if (AllowSelect != null)
                {
                    allow = AllowSelect(handle);
                }
                if (allow)
                {
                    allCnt++;
                    if (Equals(riceSelect.ValueChecked, _view.GetRowCellValue(handle, _checkColumn)))
                        cnt++;
                }
                else
                {
                    if (Equals(riceSelect.ValueChecked, _view.GetRowCellValue(handle, _checkColumn)))
                    {
                        _view.SetRowCellValue(handle, _checkColumn, riceSelect.ValueUnchecked);
                    }
                }
            }
            allRowsCount = allCnt;
            SelectCount = cnt;
        }
    }
}