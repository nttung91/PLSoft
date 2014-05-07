using System.Diagnostics;

namespace PhuLiNet.Business.Common.Calculation
{
    public class MinMultiQtyRounder
    {
        private readonly decimal _minOrderQuantity;
        private readonly decimal _orderMulti;
        private readonly decimal _orderQuantity;

        public MinMultiQtyRounder(decimal? minOrderQty, decimal? orderMulti, decimal orderQuantity)
        {
            _minOrderQuantity = minOrderQty ?? 1;
            _orderMulti = orderMulti ?? 1;
            _orderQuantity = orderQuantity;

            if (_minOrderQuantity <= 0)
            {
                _minOrderQuantity = 1;
                Debug.Assert(false, "minOrderQuantity is less or equal to 0, set to 1");
            }

            if (_orderMulti <= 0)
            {
                _orderMulti = 1;
                Debug.Assert(false, "orderMulti is less or equal to 0, set to 1");
            }
        }

        // ReSharper disable UnusedMember.Local
        private MinMultiQtyRounder()
        {
        }

        // ReSharper restore UnusedMember.Local

        public bool MoreThanMinimum
        {
            get { return _orderQuantity > _minOrderQuantity; }
        }

        public decimal DiffToMinimum
        {
            get { return MoreThanMinimum ? 0m : _minOrderQuantity - _orderQuantity; }
        }

        public decimal DiffToMultiple
        {
            get
            {
                decimal result;

                if (!MoreThanMinimum)
                    result = 0m;
                else
                {
                    var rest = (_orderQuantity - _minOrderQuantity)%_orderMulti;
                    if (rest == 0)
                        result = 0m;
                    else
                        result = _orderMulti - rest;
                }

                return result;
            }
        }
    }
}