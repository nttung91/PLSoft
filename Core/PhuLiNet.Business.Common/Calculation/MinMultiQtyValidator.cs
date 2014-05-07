using System.Diagnostics;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Calculation
{
    public class MinMultiQtyValidator
    {
        private decimal? _minOrderQuantity;
        private decimal? _orderMulti;

        public MinMultiQtyValidator(decimal? minOrderQty, decimal? orderMulti)
        {
            _minOrderQuantity = minOrderQty;
            _orderMulti = orderMulti;

            SetStandardValues();
        }

        private void SetStandardValues()
        {
            if (_minOrderQuantity == null)
            {
                _minOrderQuantity = 1;
            }

            if (_orderMulti == null)
            {
                _orderMulti = 1;
            }

            if (_minOrderQuantity.HasValue &&
                _minOrderQuantity <= 0)
            {
                Debug.Assert(false, "minOrderQuantity is less or equal to 0, set to 1");
                _minOrderQuantity = 1;
            }

            if (_orderMulti.HasValue &&
                _orderMulti <= 0)
            {
                Debug.Assert(false, "orderMulti is less or equal to 0, set to 1");
                _orderMulti = 1;
            }
        }

        public bool IsMinimumValid(decimal qty)
        {
            bool isQtyValid = false;

            if (qty >= _minOrderQuantity.Value)
            {
                isQtyValid = true;
            }

            return isQtyValid;
        }

        public bool IsMinimumValid(Quantity qty)
        {
            bool isQtyValid = false;

            if (qty != null)
                isQtyValid = IsMinimumValid(qty.Value);

            return isQtyValid;
        }

        public bool IsMultiValid(decimal qty)
        {
            bool isMultiValid = false;

            decimal multiQty = qty;

            if (multiQty >= 0)
            {
                decimal remains = multiQty%_orderMulti.Value;

                if (remains == 0)
                {
                    isMultiValid = true;
                }
            }

            return isMultiValid;
        }

        public bool IsMultiValid(Quantity qty)
        {
            bool isMultiValid = false;

            if (qty != null)
                isMultiValid = IsMultiValid(qty.Value);

            return isMultiValid;
        }

        public bool IsMinimumAndMultiValid(decimal qty)
        {
            bool isValid = false;

            isValid = (IsMinimumValid(qty) && IsMultiValid(qty));

            return isValid;
        }

        public bool IsMinimumAndMultiValid(Quantity qty)
        {
            bool isValid = false;

            if (qty != null)
                isValid = IsMinimumAndMultiValid(qty.Value);

            return isValid;
        }
    }
}