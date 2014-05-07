using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using PhuLiNet.Business.Common.Navigator.Interfaces;

namespace Windows.Core.Forms.Navigator.Operations
{
    public class IconSetOperation : TreeListOperation
    {
        // Pro Type gibt es ein Bild, hier steht welcher Type welchen Index in der ImageCollection hat
        private Dictionary<Type, int> _typeInImageCollectionIndex;

        public IconSetOperation(TreeList tree, Dictionary<Type, Bitmap> iconsPerType)
        {
            _typeInImageCollectionIndex = new Dictionary<Type, int>();
            var images = tree.SelectImageList as ImageCollection;
            FillImageCollectionAndTypeIndex(images, iconsPerType);
        }

        private void FillImageCollectionAndTypeIndex(ImageCollection images, Dictionary<Type, Bitmap> iconsPerType)
        {
            if (images == null) return;
            if (iconsPerType == null) return;

            foreach (var item in iconsPerType)
            {
                _typeInImageCollectionIndex.Add(item.Key, images.Images.Count);
                images.AddImage(item.Value);
            }
        }

        public override void Execute(TreeListNode node)
        {
            if (node == null) return;

            node.TreeList.BeginUpdate();

            object treeNode = node.TreeList.GetDataRecordByNode(node);
            if (treeNode != null && treeNode is INodeLink)
            {
                var link = treeNode as INodeLink;
                if (link != null && _typeInImageCollectionIndex.ContainsKey(link.Link.GetType()))
                {
                    node.ImageIndex = _typeInImageCollectionIndex[link.Link.GetType()];
                    node.SelectImageIndex = node.ImageIndex;
                }
            }

            node.TreeList.EndUpdate();
        }

        public override bool NeedsFullIteration
        {
            get { return true; }
        }
    }
}