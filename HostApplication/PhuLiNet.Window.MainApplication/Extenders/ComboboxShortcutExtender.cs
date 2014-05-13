using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using PhuLiNet.Plugin.Contracts;

namespace PhuLiNet.Window.MainApplication.Extenders
{
    internal class ComboboxShortcutExtender : IMenuExtender
    {
        private readonly RepositoryItemComboBox _comboBox;
        private readonly List<IPlugin> _pluginList;

        public ComboboxShortcutExtender(RepositoryItemComboBox comboBox, List<IPlugin> pluginList)
        {
            _comboBox = comboBox;
            _pluginList = pluginList;
        }

        #region IMenuExtender Members

        public void Extend()
        {
            foreach (IPlugin plugin in _pluginList)
            {
                if (!string.IsNullOrEmpty(plugin.Shortcut))
                {
                    _comboBox.Items.Add(plugin.Shortcut);
                }
            }
        }

        public void Clear()
        {
            _comboBox.Items.Clear();
        }

        #endregion
    }
}