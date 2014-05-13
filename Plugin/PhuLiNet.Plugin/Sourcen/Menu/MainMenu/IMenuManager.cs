using System.Collections.Generic;

namespace PhuLiNet.Plugin.Menu.MainMenu
{
    internal interface IMenuManager
    {
        List<IMenuItem> GetMenu();
        IMenuRepository MenuRepository { get; set; }
    }
}