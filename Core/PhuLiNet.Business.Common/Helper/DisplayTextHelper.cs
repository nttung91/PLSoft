using System.Collections;
using System.Diagnostics;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.Helper
{
    /// <summary>
    /// Hilfsklasse für Anzeigetexte und Statustexte
    /// </summary>
    public static class DisplayTextHelper
    {
        private enum EDisplayTextType
        {
            Normal,
            Short
        }

        private const string defaultSeparator = ", ";

        public static string ConvertToDisplayText<T>(IList values, string separator)
        {
            return ToDisplayText<T>(values, separator, EDisplayTextType.Normal);
        }

        public static string ConvertToDisplayTextShort<T>(IList values, string separator)
        {
            return ToDisplayText<T>(values, separator, EDisplayTextType.Short);
        }

        private static string ToDisplayText<T>(IList values, string separator, EDisplayTextType displayTextType)
        {
            string toString = null;

            if (separator == null)
                separator = defaultSeparator;

            if (values != null)
            {
                foreach (T val in values)
                {
                    var displayText = val as IDisplayTexts;
                    if (displayText != null)
                    {
                        string newText = string.Empty;
                        switch (displayTextType)
                        {
                            case EDisplayTextType.Normal:
                                newText = displayText.ToDisplayText();
                                break;
                            case EDisplayTextType.Short:
                                newText = displayText.ToDisplayTextShort();
                                break;
                            default:
                                newText = displayText.ToString();
                                break;
                        }
                        toString += newText + separator;
                    }
                    else
                    {
                        Debug.Assert(false, "IDisplayTexts interface not implemented");
                        toString += val.ToString() + separator;
                    }
                }
                toString = toString.Remove(toString.Length - separator.Length);
            }
            return toString;
        }

        /// <summary>
        /// Ergänzt ein neues Element im Anzeigetext als Kurztext, ein Business-Objekt das IDisplayTexts implementiert muss vorhanden sein
        /// </summary>
        /// <param name="currentDisplayText">Aktueller Anzeigetext</param>
        /// <param name="description">Beschreibung des Elementes (z.B. Wgr, Katg)</param>
        /// <param name="displayTexts">Neuer Textbaustein</param>
        /// <returns></returns>
        public static string AddDisplayTextShort(string currentDisplayText, string description,
            IDisplayTexts displayTexts)
        {
            Debug.Assert(displayTexts != null, "IDisplayTexts interface not implemented");
            if (displayTexts != null)
                return AddDisplayText(currentDisplayText, description, displayTexts.ToDisplayTextShort());
            else
                return currentDisplayText;
        }

        /// <summary>
        /// Ergänzt ein neues Element im Anzeigetext, ein Business-Objekt das IDisplayTexts implementiert muss vorhanden sein
        /// </summary>
        /// <param name="currentDisplayText">Aktueller Anzeigetext</param>
        /// <param name="description">Beschreibung des Elementes (z.B. Wgr, Katg)</param>
        /// <param name="displayTexts">Neuer Textbaustein</param>
        /// <returns></returns>
        public static string AddDisplayText(string currentDisplayText, string description, IDisplayTexts displayTexts)
        {
            Debug.Assert(displayTexts != null, "IDisplayTexts interface not implemented");
            if (displayTexts != null)
                return AddDisplayText(currentDisplayText, description, displayTexts.ToDisplayText());
            else
                return currentDisplayText;
        }

        /// <summary>
        /// Ergänzt ein neues Element im Anzeigetext
        /// </summary>
        /// <param name="currentDisplayText">Aktueller Anzeigetext</param>
        /// <param name="description">Beschreibung des Elementes (z.B. Wgr, Katg)</param>
        /// <param name="displayTextElement">Neuer Textbaustein</param>
        /// <returns></returns>
        public static string AddDisplayText(string currentDisplayText, string description, string displayTextElement)
        {
            string displayText = string.Empty;

            if (displayTextElement != null && displayTextElement != string.Empty)
                displayText += (currentDisplayText != string.Empty ? "  " : string.Empty) +
                               description + ": " + displayTextElement;

            return displayText;
        }
    }
}