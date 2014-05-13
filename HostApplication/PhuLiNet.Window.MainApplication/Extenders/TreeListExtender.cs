using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PhuLiNet.Plugin.Menu;
using Techical.Icons;

namespace PhuLiNet.Window.MainApplication.Extenders
{
    internal class TreeListExtender : IMenuExtender
    {
        private readonly TreeList _treeList;
        private readonly List<IMenuItem> _menuList;
        private ImageCollection _selectImageCollection;

        public TreeListExtender(TreeList treeList, List<IMenuItem> menuList)
        {
            _treeList = treeList;
            _menuList = menuList;
        }

        #region IMenuExtender Members

        public void Extend()
        {
            CreateImageCollection();

            _treeList.BeginUnboundLoad();

            foreach (IMenuItem mi in _menuList)
            {
               CreateNode(mi, null);
            }

            if (_menuList.Count == 1)
            {
                _treeList.ExpandAll();
            }

            _treeList.EndUnboundLoad();
        }

        public void Clear()
        {
            _treeList.Nodes.Clear();
        }

        #endregion

        private void CreateImageCollection()
        {
            _selectImageCollection = new ImageCollection();
            _selectImageCollection.AddImage(IconManager.GetBitmap(EIcons.folder_16));
            _selectImageCollection.AddImage(IconManager.GetBitmap(EIcons.window_info_16));
            _selectImageCollection.AddImage(IconManager.GetBitmap(EIcons.oracleforms_16));
            _treeList.SelectImageList = _selectImageCollection;
        }

        private TreeListNode CreateNode(IMenuItem menuItem, TreeListNode parentNode)
        {
            return CreateApplicationNode(menuItem, parentNode);
        }

        private TreeListNode CreateApplicationNode(IMenuItem menuItem, TreeListNode parentNode)
        {
            string caption = menuItem.Caption;
            var newNode = _treeList.AppendNode(new object[] { caption }, parentNode);
            newNode.Tag = menuItem;

            if (menuItem.Image != null)
            {
                _selectImageCollection.AddImage(menuItem.Image);
                newNode.ImageIndex = _selectImageCollection.Images.Count - 1;
                newNode.SelectImageIndex = _selectImageCollection.Images.Count - 1;
            }
            else
            {
                newNode.ImageIndex = 1;
                newNode.SelectImageIndex = 1;
            }

            return newNode;
        }

        private TreeListNode CreateMenuNode(IMenuItem menuItem, TreeListNode parentNode)
        {
            var newNode = _treeList.AppendNode(new object[] { menuItem.Caption }, parentNode);
            newNode.Tag = menuItem;

            if (menuItem.Image != null)
            {
                _selectImageCollection.AddImage(menuItem.Image);
                newNode.ImageIndex = _selectImageCollection.Images.Count - 1;
                newNode.SelectImageIndex = _selectImageCollection.Images.Count - 1;
            }
            else
            {
                newNode.ImageIndex = 0;
            }
            return newNode;
        }
    }
}