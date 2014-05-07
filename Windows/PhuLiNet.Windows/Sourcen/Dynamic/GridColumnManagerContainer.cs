using System;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.BandedGrid;
using Techical.Dynamic.Manager;
using Techical.Dynamic.Property;

namespace Windows.Core.Dynamic
{
    /// <summary>
    /// Manages a list of column managers which create grid columns dynamically during runtime
    /// </summary>
    public class GridColumnManagerContainer
    {
        private readonly Dictionary<string, ColumnManagerParameter> _columnManagers =
            new Dictionary<string, ColumnManagerParameter>();

        public GridOptions DefaultOptions { get; set; }
        private GridBand _defaultBand;
        private BandedGridView _defaultGridView;

        public GridBand DefaultBand
        {
            get { return _defaultBand; }
            set
            {
                _defaultBand = value;
                SetExistingBand(value);
            }
        }

        public BandedGridView DefaultGridView
        {
            get { return _defaultGridView; }
            set
            {
                _defaultGridView = value;
                SetExistingView(value);
            }
        }

        private void SetExistingView(BandedGridView existingView)
        {
            foreach (var parameter in _columnManagers)
            {
                parameter.Value.Parameters.ExistingGridView = existingView;
            }
        }

        public GridColumnManagerContainer()
        {
            DefaultOptions = new GridOptions();
        }

        public void Add(ColumnManagerParameter columnManagerParameter)
        {
            if (string.IsNullOrEmpty(columnManagerParameter.ColumnManager.Identifier.Key))
                throw new ArgumentException("ColumnManager.Identifier.Key is empty");
            _columnManagers.Add(columnManagerParameter.ColumnManager.Identifier.Key, columnManagerParameter);
        }

        public void Add(ColumnManagerBase columnManager)
        {
            var newParameters = new ColumnManagerParameter(columnManager,
                new GridColumnParameters {Options = (GridOptions) DefaultOptions.Clone()});
            Add(newParameters);
        }

        private void SetExistingBand(GridBand existingBand)
        {
            foreach (var parameter in _columnManagers)
            {
                parameter.Value.Parameters.ExistingBand = existingBand;
            }
        }

        public void CreateBands()
        {
            foreach (var parameter in _columnManagers)
            {
                CreateBands(parameter.Key);
            }
        }

        public void CreateBands(string columnManagerKey)
        {
            var columnManagerParameters = _columnManagers[columnManagerKey];
            columnManagerParameters.Parameters.Options.BandOptions.BandIdentifier =
                columnManagerParameters.ColumnManager.Identifier;
            DynamicBandedGridHelper.AddDynamicBand(columnManagerParameters.Parameters);
        }

        public void RemoveBands()
        {
            foreach (var parameter in _columnManagers)
            {
                RemoveBands(parameter.Key);
            }
        }

        public void RemoveBands(string columnManagerKey)
        {
            var columnManagerParameters = _columnManagers[columnManagerKey];

            columnManagerParameters.Parameters.Options.BandOptions.BandIdentifier =
                columnManagerParameters.ColumnManager.Identifier;

            if (columnManagerParameters.Parameters.ExistingBand != null)
            {
                DynamicBandedGridHelper.RemoveDynamicBand(columnManagerParameters.Parameters.ExistingBand,
                    columnManagerParameters.Parameters.Options.BandOptions);
            }
            else
            {
                DynamicBandedGridHelper.RemoveDynamicBand(columnManagerParameters.Parameters.ExistingGridView,
                    columnManagerParameters.Parameters.Options.BandOptions);
            }
        }

        public void SetObjectList(IList<IHasDynamicProperties> listOfObjectsWithDynamicProperties)
        {
            foreach (var parameter in _columnManagers)
            {
                parameter.Value.ColumnManager.ListOfObjectsWithDynamicProperties = listOfObjectsWithDynamicProperties;
            }
        }

        public void CreateData()
        {
            foreach (var parameter in _columnManagers)
            {
                CreateData(parameter.Key);
            }
        }

        public void CreateData(string columnManagerKey)
        {
            _columnManagers[columnManagerKey].ColumnManager.CreateData();
        }

        public void SetHeader()
        {
            foreach (var parameter in _columnManagers)
            {
                SetHeader(parameter.Key);
            }
        }

        public void SetHeader(string columnManagerKey)
        {
            _columnManagers[columnManagerKey].SetHeader();
        }

        public ColumnManagerParameter Get(string columnManagerKey)
        {
            return _columnManagers[columnManagerKey];
        }

        public void ClearData()
        {
            foreach (var parameter in _columnManagers)
            {
                ClearData(parameter.Key);
            }
        }

        public void ClearData(string columnManagerKey)
        {
            _columnManagers[columnManagerKey].ColumnManager.ClearData();
        }
    }
}