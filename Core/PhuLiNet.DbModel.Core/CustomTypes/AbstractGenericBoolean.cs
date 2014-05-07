using System;
using System.Data;
using NHibernate;

namespace DbModel.Core.CustomTypes
{
    public abstract class AbstractGenericBoolean<T> : BaseImmutableUserType<bool>
    {
        private readonly T _trueValue;
        private readonly T _falseValue;

        /// <summary>
        /// Constructor used to specify the <c>true</c> value and the <c>false</c> value
        /// </summary>
        /// <param name="trueValue">the <c>true</c> value</param>
        /// <param name="falseValue">the <c>false</c> value</param>
        protected AbstractGenericBoolean(T trueValue, T falseValue)
        {
            _trueValue = trueValue;
            _falseValue = falseValue;
        }

        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var obj = NHibernateUtil.String.NullSafeGet(rs, names[0]);

            if (obj == null) return null;

            if (obj.GetType() != typeof (T))
                throw new ApplicationException(string.Format("Unexpteted type '{0}'. Should be {1}.", obj.GetType(),
                    typeof (T)));

            var trueFalse = (T) obj;
            if (!trueFalse.Equals(_trueValue) && !trueFalse.Equals(_falseValue))
                throw new ApplicationException(
                    string.Format("Expected data to be '{0}' (true-Value) or '{1}' (false-Value) but was '{2}'.",
                        _trueValue, _falseValue, trueFalse));

            return trueFalse.Equals(_trueValue);
        }

        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDataParameter) cmd.Parameters[index]).Value = DBNull.Value;
                return;
            }

            if (value is bool)
                ((IDataParameter) cmd.Parameters[index]).Value = (bool) value ? _trueValue : _falseValue;
            else
                throw new ApplicationException(string.Format("Type of value '{0}' should be bool, but is '{1}'", value,
                    value.GetType()));
        }
    }
}