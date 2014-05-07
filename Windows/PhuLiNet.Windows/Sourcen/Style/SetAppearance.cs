using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace Windows.Core.Style
{
    internal class SetAppearance
    {
        private UserLookAndFeel _defaultLF = UserLookAndFeel.Default;

        /// <summary>
        /// Setzt den Default Look and Feel
        /// </summary>
        /// <param name="style"></param>
        /// <param name="skinName">Name des Skins</param>
        public void SetLookAndFeel(EStyles style, string skinName)
        {
            //Setzen der Appearance
            BonusSkins.Register();

            SkinManager.EnableFormSkins();
            SkinManager.EnableFormSkinsIfNotVista();

            switch (style)
            {
                case EStyles.Default:
                    _defaultLF.SetDefaultStyle();
                    break;
                case EStyles.Flat:
                    _defaultLF.SetFlatStyle();
                    break;
                case EStyles.Ultraflat:
                    _defaultLF.SetUltraFlatStyle();
                    break;
                case EStyles.Style3D:
                    _defaultLF.SetStyle3D();
                    break;
                case EStyles.Office2003:
                    _defaultLF.SetOffice2003Style();
                    break;
                case EStyles.XP:
                    _defaultLF.SetWindowsXPStyle();
                    break;
                case EStyles.Skin:
                    _defaultLF.SetSkinStyle(skinName);
                    break;
                default:
                    break;
            }
        }
    }
}