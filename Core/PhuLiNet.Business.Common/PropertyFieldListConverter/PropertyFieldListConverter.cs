using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Csla;
using Technical.Reflection;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Unit;
using MethodInfo = System.Reflection.MethodInfo;

namespace PhuLiNet.Business.Common.PropertyFieldListConverter
{
    /// <summary>
    /// Properties of a BusinessBase can be decorated with a PropertyDescriptionAttribute.
    /// The PropertyDescriptionAttribute name will be the link between the property and the field in the list.
    /// In the list object there is a field named the same as the parameter "fieldName".
    /// The property with the PropertyDescriptionAttribute corresponds to the object in the list with the same Description in the "fieldName" field 
    /// In the list, the Value is always a string type and the name of the Value field must be as described in IStringValueProperty
    /// </summary>
    public class PropertyFieldListConverter
    {
        public static void ConvertPropertyValuesToFields<T, C>(object instance, IFindFirstWithFilter list,
            string fieldName)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>
        {
            Debug.Assert(instance != null, "instance is null");
            Debug.Assert(list != null, "list is null");
            Debug.Assert(fieldName != null, "fieldName is null");

            string[] propertyNames = PropertyReflectionHelper.GetPropertyNames(instance);

            foreach (string propertyName in propertyNames)
            {
                ConvertPropertyValueToField<T, C>(instance, list, fieldName, propertyName);
            }
        }

        public static void ConvertPropertyValueToField<T, C>(object instance, IFindFirstWithFilter list,
            string fieldName, string propertyName)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>
        {
            Debug.Assert(instance != null, "instance is null");
            Debug.Assert(list != null, "list is null");
            Debug.Assert(fieldName != null, "fieldName is null");

            Attribute attribute = PropertyReflectionHelper.GetAttributeFromProperty(instance, propertyName,
                typeof (PropertyDescriptionAttribute));
            if (attribute != null && attribute is PropertyDescriptionAttribute)
            {
                var fieldTypeAttribute = (PropertyDescriptionAttribute) attribute;
                string fieldType = fieldTypeAttribute.Description;

                var filter = new Dictionary<string, object>();
                filter.Add(fieldName, fieldType);

                C fieldObj = list.FindFirstWithFilter<T, C>(filter);
                if (fieldObj != null && fieldObj is IStringValueProperty)
                {
                    var fieldValue = fieldObj as IStringValueProperty;
                    object valObj = GetPropertyValue(instance, propertyName);
                    if (valObj != null)
                    {
                        if (valObj is Money)
                        {
                            var money = (Money) valObj;
                            fieldValue.Value = money.Amount.ToString();
                        }
                        else
                        {
                            fieldValue.Value = valObj.ToString();
                        }
                    }
                    else
                    {
                        fieldValue.Value = null;
                    }
                }
            }
        }

        public static void ConvertFieldValuesToProperties<T, C>(object instance, IFindFirstWithFilter list,
            string fieldName)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>
        {
            Debug.Assert(instance != null, "instance is null");
            Debug.Assert(list != null, "list is null");
            Debug.Assert(fieldName != null, "fieldName is null");

            string[] propertyNames = PropertyReflectionHelper.GetPropertyNames(instance);

            foreach (string propertyName in propertyNames)
            {
                ConvertFieldValueToProperty<T, C>(instance, list, fieldName, propertyName);
            }
        }

        public static void ConvertFieldValueToProperty<T, C>(object instance, IFindFirstWithFilter list,
            string fieldName, string propertyName)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>
        {
            Attribute attribute = PropertyReflectionHelper.GetAttributeFromProperty(instance, propertyName,
                typeof (PropertyDescriptionAttribute));
            if (attribute != null && attribute is PropertyDescriptionAttribute)
            {
                var fieldTypeAttribute = (PropertyDescriptionAttribute) attribute;
                string fieldType = fieldTypeAttribute.Description;

                var filter = new Dictionary<string, object>();
                filter.Add(fieldName, fieldType);
                C fieldObj = list.FindFirstWithFilter<T, C>(filter);
                if (fieldObj != null && fieldObj is IStringValueProperty)
                {
                    var fieldValue = fieldObj as IStringValueProperty;
                    SetPropertyValue(instance, fieldValue.Value, propertyName);
                }
            }
        }

        /// <summary>
        /// Schreibt den Wert value in ein Property der instance mit dem propertyName, der Propertytype wird zur Laufzeit ermittelt
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void SetPropertyValue(object instance, string value, string propertyName)
        {
            PropertyInfo propertyInfo = PropertyReflectionHelper.GetPropertyInfo(instance, propertyName);
            MethodInfo setPropertyValue = typeof (PropertyReflectionHelper).GetMethod("SetPropertyValue");
            MethodInfo setGenericSetPropertyValue = setPropertyValue.MakeGenericMethod(propertyInfo.PropertyType);

            if (string.IsNullOrEmpty(value))
            {
                object[] args = {instance, propertyInfo.Name, null};
                setGenericSetPropertyValue.Invoke(null, args);
            }
            else if (propertyInfo.PropertyType == typeof (Money))
            {
                object[] args = {instance, propertyInfo.Name, Money.TryConvert(value)};
                setGenericSetPropertyValue.Invoke(null, args);
            }
            else
            {
                Type conversionType = propertyInfo.PropertyType;
                if (TypeHelper.IsNullableType(conversionType))
                {
                    conversionType = TypeHelper.GetUnderlyingTypeOfNullable(conversionType);
                }

                object[] args = {instance, propertyInfo.Name, Convert.ChangeType(value, conversionType)};
                setGenericSetPropertyValue.Invoke(null, args);
            }
        }

        /// <summary>
        /// Gibt den Propertywert zurück, der Typ wird in ein Object gecasted, der PropertyTyp wird zur Laufzeit ermittelt
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetPropertyValue(object instance, string propertyName)
        {
            PropertyInfo propertyInfo = PropertyReflectionHelper.GetPropertyInfo(instance, propertyName);
            MethodInfo getPropertyValue = typeof (PropertyReflectionHelper).GetMethod("GetPropertyValue");
            MethodInfo genericGetPropertyValue = getPropertyValue.MakeGenericMethod(propertyInfo.PropertyType);

            object[] args = {instance, propertyInfo.Name};
            return genericGetPropertyValue.Invoke(null, args);
        }
    }
}