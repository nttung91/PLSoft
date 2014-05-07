using System;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using Windows.Core.BaseForms;

namespace Windows.Core.Helpers
{
    /// <summary>
    /// Hilfsklasse zum Suchen und Anzeigen von Sub-Formularen
    /// </summary>
    public static class OwnedFormsHelper
    {
        /// <summary>
        /// Zeigt ein Formular als Sub-Formular an
        /// </summary>
        public static T ShowOwnedForm<T>(object formIdValue,
            Form owner,
            FormWindowState state,
            bool checkExists,
            String statusText,
            bool showWaitForm,
            bool loadBusinessData)
            where T : FrmBase, new()
        {
            T newForm = null;

            using (new StatusBusy(statusText, showWaitForm))
            {
                if (checkExists)
                    newForm = FindInstance<T>(formIdValue, owner);

                if (newForm == null)
                {
                    newForm = new T();
                    newForm.Owner = owner;
                    newForm.WindowState = state;

                    if (newForm is ILoadableForm && loadBusinessData)
                    {
                        ((ILoadableForm) newForm).LoadBusiness();
                    }
                    newForm.Show();
                }
                else
                {
                    newForm.Show();
                }
            }

            return newForm;
        }

        /// <summary>
        /// Entfernt den Sub-Formulartyp vom Owner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="owner"></param>
        public static void RemoveOwnedForm<T>(Form owner)
            where T : Form
        {
            for (int index = owner.OwnedForms.Length - 1; index >= 0; index--)
            {
                if (owner.OwnedForms[index] is T)
                {
                    owner.OwnedForms[index].Dispose();
                }
            }
        }

        /// <summary>
        /// Sucht im Owner Formular nach einer Instanz des Formulartyps
        /// </summary>
        public static T FindInstance<T>(object formIdValue, Form owner)
            where T : Form
        {
            T formFound = null;

            foreach (Form form in owner.OwnedForms)
            {
                if (form is T)
                {
                    if (formIdValue != null)
                    {
                        var identify = form as IIdentifiableForm;

                        if (identify != null &&
                            identify.GetIdValue().ToString() ==
                            formIdValue.ToString())
                        {
                            formFound = form as T;
                            break;
                        }
                    }
                    else
                    {
                        formFound = form as T;
                        break;
                    }
                }
            }

            return formFound;
        }

        /// <summary>
        /// Versteckt alle angezeigten Sub-Formulare
        /// </summary>
        /// <param name="owner"></param>
        public static void HideOwnedForms(Form owner)
        {
            foreach (Form form in owner.OwnedForms)
            {
                form.Hide();
            }
        }

        /// <summary>
        /// Zeigt alle angezeigten Sub-Formulare an
        /// </summary>
        /// <param name="owner"></param>
        public static void ShowOwnedForms(Form owner)
        {
            foreach (Form form in owner.OwnedForms)
            {
                form.Show();
            }
        }
    }
}