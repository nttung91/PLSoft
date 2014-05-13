using System.Collections.Generic;

namespace PhuLiNet.Plugin.Menu.MainMenu
{
    internal interface IMenuRepository
    {
        List<IMenuItem> Load();
    }
}