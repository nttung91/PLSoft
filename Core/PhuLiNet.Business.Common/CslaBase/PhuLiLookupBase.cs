using System;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Lookup;
using Techical.Dynamic.Property;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiLookupBase<T> : PhuLiReadOnlyBase<T>, ILookupObject, IComparable, IComparable<T>,
        ISelectable, IEquatable<T>, IDisplayTexts
        where T : PhuLiLookupBase<T>
    {
        public bool Selected { get; set; }
        public abstract object LookupKey { get; }
        public abstract string LookupName { get; }

        /// <summary>
        /// unique key of this instance, in most cases the artificial key of database table.
        /// </summary>
        protected abstract override object GetIdValue();

        public virtual int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is T))
            {
                throw new ArgumentException(string.Format("Compare {0} with {1} is not possible", obj.GetType(),
                    typeof (T)));
            }

            return CompareTo(obj as T);
        }

        public virtual int CompareTo(T other)
        {
            return String.Compare(ToString(), other.ToString(), StringComparison.CurrentCulture);
        }

        public abstract override string ToString();

        public virtual IDynamicPropertyList LookupAdditionalValues
        {
            get { return new DynamicPropertyList(); }
        }

        public override int GetHashCode()
        {
            return GetIdValue().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj is T) && Equals((T) obj);
        }

        public bool Equals(T other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return (GetIdValue().ToString().Equals(other.GetIdValue().ToString()));
        }

        public virtual string ToDisplayText()
        {
            var lookupKeyAsString = (LookupKey == null || LookupKey.ToString() == String.Empty)
                ? String.Empty
                : string.Format("{0} ", LookupKey);

            return string.Format("{0}{1}", lookupKeyAsString, LookupName);
        }

        public virtual string ToDisplayTextShort()
        {
            return LookupName;
        }

        public static bool operator ==(PhuLiLookupBase<T> first, PhuLiLookupBase<T> second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            return first.Equals(second);
        }

        public static bool operator !=(PhuLiLookupBase<T> first, PhuLiLookupBase<T> second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return false;
            if (ReferenceEquals(first, null))
                return true;
            return !first.Equals(second);
        }
    }
}