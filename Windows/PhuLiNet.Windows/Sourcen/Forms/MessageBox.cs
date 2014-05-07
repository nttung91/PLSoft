using System;
using System.Windows.Forms;

namespace Windows.Core.Forms
{
    public static class MessageBox
    {
        /// <summary>
        /// Anzeige Fehlerform mit Labelcontrol (Message) und darunter mehrzeiliges MemoEdit (errorText), Buttons: OK, Abbrechen
        /// </summary>
        /// <param name="message">Text im Labelcontrol (Oben, eine Zeile)</param>
        /// <param name="errortext">Mehrzeiliger Fehlertext der als Memoedit dargestellt wird</param>
        /// <returns></returns>
        public static DialogResult ShowError(string message, string errortext)
        {
            return ShowError(message, errortext, " ");
        }

        /// <summary>
        /// Anzeige Fehlerform mit Labelcontrol (Message) und darunter mehrzeiliges MemoEdit (errorText), Buttons: OK, Abbrechen, Formtitel= caption
        /// </summary>
        /// <param name="message">Text im Labelcontrol (Oben, eine Zeile)</param>
        /// <param name="errortext">Mehrzeiliger Fehlertext der als Memoedit dargestellt wird</param>
        /// <param name="caption">Titel des Forms</param>
        public static DialogResult ShowError(string message, string errortext, string caption)
        {
            using (var mb = new FrmErrorMessageBox(message, errortext, caption))
            {
                return mb.ShowDialog();
            }
        }

        /// <summary>
        /// Anzeige Fehlerform mit Labelcontrol (Message) und darunter mehrzeiliges MemoEdit (exception.ToString()), Buttons: OK, Abbrechen, Formtitel= caption
        /// </summary>
        /// <param name="message">Text im Labelcontrol (Oben, eine Zeile)</param>
        /// <param name="exception">exception.ToString() wird angezeigt</param>
        /// <param name="caption">Titel des Forms</param>
        /// <returns></returns>
        public static DialogResult ShowError(string message, Exception exception, string caption)
        {
            using (var mb = new FrmErrorMessageBox(message, exception.ToString(), caption))
            {
                return mb.ShowDialog();
            }
        }

        /// <summary>
        /// Anzeige Fehlerform mit Labelcontrol (exception.Message) und darunter mehrzeiliges MemoEdit (exception.ToString()), Buttons: OK, Abbrechen, Formtitel= caption
        /// </summary>
        /// <param name="exception">exception.ToString() wird angezeigt</param>
        /// <param name="caption">Titel des Forms</param>
        /// <returns></returns>
        public static DialogResult ShowError(Exception exception, string caption)
        {
            using (var mb = new FrmErrorMessageBox(exception.Message, exception.ToString(), caption))
            {
                DialogResult dr = mb.ShowDialog();
                return dr;
            }
        }

        /// <summary>
        /// Anzeige Infoform mit mehrzeiligem Infotext (message), Buttons: OK, Cancel
        /// </summary>
        /// <param name="message">Mehrzeiliger Infotext</param>
        /// <returns></returns>
        public static DialogResult ShowInfo(string message)
        {
            return ShowInfo(message, null);
        }

        /// <summary>
        /// Anzeige Infoform mit mehrzeiligem Infotext (message), Buttons: OK, Formtitel= caption
        /// </summary>
        /// <param name="message">Mehrzeiliger Infotext</param>
        /// <param name="caption">Titel des Forms</param>
        /// <returns></returns>
        public static DialogResult ShowInfo(string message, string caption)
        {
            using (var mb = new FrmInfoMessageBox(message, caption))
            {
                return mb.ShowDialog();
            }
        }

        /// <summary>
        /// Anzeige Infoform mit mehrzeiligem Infotext (message), Buttons: OK
        /// </summary>
        /// <param name="message">Mehrzeiliger Infotext</param>
        /// <returns></returns>
        public static DialogResult ShowInfoWithCancel(string message)
        {
            return ShowInfoWithCancel(message, null);
        }

        /// <summary>
        /// Anzeige Infoform mit mehrzeiligem Infotext (message), Buttons: OK, Cancel, Formtitel= caption
        /// </summary>
        /// <param name="message">Mehrzeiliger Infotext</param>
        /// <param name="caption">Titel des Forms</param>
        /// <returns></returns>
        public static DialogResult ShowInfoWithCancel(string message, string caption)
        {
            using (var mb = new FrmInfoMessageBox(message, caption, true))
            {
                return mb.ShowDialog();
            }
        }

        public static DialogResult ShowDisappearingInfo(int showforMilliseconds, string message)
        {
            return ShowDisappearingInfo(showforMilliseconds, message, null);
        }

        public static DialogResult ShowDisappearingInfo(int showforMilliseconds, string message, string caption)
        {
            using (var mb = new FrmDisappearInfoMessageBox(showforMilliseconds, message, caption))
            {
                mb.EnableTimer();
                return mb.ShowDialog();
            }
        }

        /// <summary>
        /// Anzeige Warnform mit mehrzeiligem Text (message), Button: OK
        /// </summary>
        /// <param name="message">mehrzeiliger Text </param>
        /// <returns></returns>
        public static DialogResult ShowWarning(string message)
        {
            return ShowWarning(message, null);
        }

        /// <summary>
        /// Anzeige Warnform mit mehrzeiligem Text (message), Button: OK, Formtitel= Caption
        /// </summary>
        /// <param name="message">mehrzeiliger Text </param>
        /// <param name="caption">Titel des Forms</param>
        /// <returns></returns>
        public static DialogResult ShowWarning(string message, string caption)
        {
            using (var mb = new FrmWarningMessageBox(message, caption))
            {
                return mb.ShowDialog();
            }
        }

        /// <summary>
        /// Anzeige Frageform mit mehrzeiligem Text (message), Buttons: Ja  Nein  Abbrechen
        /// </summary>
        /// <param name="message">mehrzeiliger Text</param>
        /// <returns></returns>
        public static DialogResult ShowYesNo(string message)
        {
            return ShowYesNo(message, null);
        }

        /// <summary>
        /// Anzeige Frageform mit mehrzeiligem Text (message), Buttons: Ja  Nein  Abbrechen, Formtitel= Caption
        /// </summary>
        /// <param name="message">mehrzeiliger Text</param>
        /// <param name="caption">Titel des Forms</param>
        /// <returns></returns>
        public static DialogResult ShowYesNo(string message, string caption)
        {
            using (var mb = new FrmYesNoMessageBox(message, caption, false))
            {
                return mb.ShowDialog();
            }
        }

        public static DialogResult ShowYesNo(string message, bool showDisplayAgainFlag, out bool displayAgainValue)
        {
            return ShowYesNo(message, null, showDisplayAgainFlag, out displayAgainValue);
        }

        public static DialogResult ShowYesNo(string message, string caption, bool showDisplayAgainFlag,
            out bool displayAgainValue)
        {
            using (var mb = new FrmYesNoMessageBox(message, caption, showDisplayAgainFlag))
            {
                var dr = mb.ShowDialog();
                displayAgainValue = mb.DisplayAgainValue;
                return dr;
            }
        }

        public static DialogResult ShowException(Exception exception)
        {
            using (var mb = new FrmExceptionMessageBox(exception))
            {
                DialogResult dr = mb.ShowDialog();
                return dr;
            }
        }
    }
}