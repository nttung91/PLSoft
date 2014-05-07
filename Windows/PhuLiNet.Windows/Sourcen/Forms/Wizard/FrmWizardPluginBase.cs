using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Csla.Core;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms.Wizard
{
    public partial class FrmWizardPluginBase : FrmReadOnlyBase, IEditableForm, IDataModelBind
    {
        protected IDataModel _dataModel;
        protected bool _isLoaded = false;
        protected Dictionary<BindingSource, object> _bindingSourcesDataSource = new Dictionary<BindingSource, object>();

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; }
        }

        public FrmWizardPluginBase()
        {
            InitializeComponent();
        }

        #region IEditableForm Members

        [Browsable(false)]
        public virtual bool IsDirty
        {
            get { return _dataModel.IsDirty; }
        }

        [Browsable(false)]
        public virtual bool IsValid
        {
            get { return _dataModel.IsValid; }
        }

        [Browsable(false)]
        public virtual bool IsReadOnly { get; set; }

        #endregion

        #region IDataModelBind Members

        public virtual void BindDataModel(IDataModel dataModel)
        {
            _dataModel = dataModel;
            InitBindings();
        }

        protected void BindAllBO()
        {
            foreach (BindingSource bs in _bindingSourcesDataSource.Keys)
            {
                _objectBindingManager.BindBO(_bindingSourcesDataSource[bs], bs);
            }
        }

        protected void BindAllBO(ComponentCollection components)
        {
            foreach (object cmpt in components)
            {
                if (cmpt is BindingSource)
                {
                    var bs = (BindingSource) cmpt;
                    Debug.Assert(_bindingSourcesDataSource.ContainsKey(bs), "Bindingsource not in List " + bs.ToString());

                    if (_bindingSourcesDataSource.ContainsKey(bs))
                        _objectBindingManager.BindBO(_bindingSourcesDataSource[bs], bs);
                }
            }
        }

        protected void UnbindAllBO(ComponentCollection components)
        {
            foreach (object cmpt in components)
            {
                if (cmpt is BindingSource)
                {
                    var bs = (BindingSource) cmpt;
                    bool apply = bs.DataSource is BusinessBase;
                    _objectBindingManager.ClearBindings(bs, apply);
                }
            }
        }

        protected void UnbindAllBO()
        {
            foreach (BindingSource bs in _bindingSourcesDataSource.Keys)
            {
                bool apply = bs.DataSource is BusinessBase;
                _objectBindingManager.ClearBindings(bs, apply);
            }
        }

        public virtual void PluginLoaded()
        {
        }

        public virtual void UnbindDataModel()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}