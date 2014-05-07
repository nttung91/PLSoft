using System.Diagnostics;
using Csla.Core;
using Csla.Rules;

namespace PhuLiNet.Business.Common.Rules
{
    public class BusinessPropertyValidator<C> where C : BusinessBase
    {
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public static BusinessPropertyValidator<C> GetValidator()
        {
            return new BusinessPropertyValidator<C>();
        }

        /// <summary>
        /// Gibt true wenn das Property keine Businessrule verletzt, falls false, dann werden in der errormessage alle verletzten Regeln aufgelistet
        /// </summary>
        /// <typeparam name="C">Typ des Businessobjekts welches geprüft werden soll</typeparam>
        /// <param name="businessObject">Businessobjekt welches geprüft werden soll</param>
        /// <param name="property">Zu prüfendes Property</param>
        /// <returns></returns>
        public bool IsValid(C businessObject, string property)

        {
            Debug.Assert(!string.IsNullOrEmpty(property), "Propertyname fehlt");
            Debug.Assert(businessObject != null, "Businessobjekt fehlt");

            bool res = true;
            _errorMessage = string.Empty;
            bool first = true;
            foreach (BrokenRule br in businessObject.BrokenRulesCollection)
            {
                if (first)
                {
                    first = !first;
                }
                else
                {
                    _errorMessage += ", ";
                }

                if (br.Property != null && br.Property.Equals(property))
                {
                    res = false;
                    _errorMessage += br.Description;
                }
            }

            return res;
        }
    }
}