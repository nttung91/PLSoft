using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using PhuLiNet.Plugin.Menu;

namespace PhuLiNet.Window.MainApplication.Extenders
{
    internal class TileControlExtender : IMenuExtender
    {
        private readonly TileControl _tileControl;
        private readonly List<IMenuItem> _menuList;
        private readonly MenuItemImageHandler _menuItemImageHandler;

        public TileItemClickEventHandler TileClickEventHandler { get; set; }

        public TileControlExtender(TileControl tileControl, List<IMenuItem> menuList)
        {
            _tileControl = tileControl;
            _menuList = menuList;
            _menuItemImageHandler = new MenuItemImageHandler(MenuItemImageHandler.EImageSize.Middle);
        }

        public void Extend()
        {
            _tileControl.BeginUpdate();
            _tileControl.Groups.Clear();

            var tileGroup = new TileGroup {Name = "Favoriten"};
            _tileControl.Groups.Add(tileGroup);

            foreach (IMenuItem mi in _menuList)
            {
                if (mi.HasPlugin)
                {
                    var tile = CreateTile(mi);
                    tileGroup.Items.Add(tile);
                }
            }

            _tileControl.EndUpdate();
            _tileControl.ResumeAnimation();
        }

        public void Clear()
        {
            _tileControl.Groups.Clear();
        }

        private TileItem CreateTile(IMenuItem menuItem)
        {
            string caption = string.Format("{0} {1}", menuItem.Caption,
                menuItem.Plugin.Shortcut != null
                    ? string.Format("[{0}]", menuItem.Plugin.Shortcut)
                    : string.Empty);
            //Text Frame
            var textFrame = new TileItemFrame();
            var textElement = new TileItemElement
            {
                Text = string.Format("<Size=+1><Color=White><b>{0}</b></Color></Size>", caption),
                Image = _menuItemImageHandler.GetImage(menuItem),
                ImageAlignment = TileItemContentAlignment.TopLeft,
                TextAlignment = TileItemContentAlignment.BottomCenter
            };
            textFrame.Elements.Add(textElement);
            textFrame.Elements[0].AnimateTransition = DefaultBoolean.True;
            textFrame.UseImage = true;
            textFrame.UseBackgroundImage = true;
            textFrame.UseText = true;
            textFrame.AnimateBackgroundImage = false;
            textFrame.AnimateImage = false;
            textFrame.AnimateText = false;

            //Create new tile
            var tile = new TileItem {Name = menuItem.Caption, Tag = menuItem};
            tile.Frames.Add(textFrame);
            tile.Appearance.ForeColor = Color.Gray;
            tile.Appearance.BackColor = Color.White;
            tile.Appearance.BackColor2 = Color.Gray;
            tile.Appearance.GradientMode = LinearGradientMode.ForwardDiagonal;
            tile.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            tile.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            tile.AllowHtmlText = DefaultBoolean.True;
            tile.FrameAnimationInterval = 6000;

            if (TileClickEventHandler != null)
            {
                tile.ItemClick += TileClickEventHandler;
            }

            return tile;
        }
    }
}