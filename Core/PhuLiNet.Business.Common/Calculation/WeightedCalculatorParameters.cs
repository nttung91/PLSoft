namespace PhuLiNet.Business.Common.Calculation
{
    public class WeightedCalculatorParameters
    {
        public decimal? Dividend { get; private set; }
        public decimal? Divisor { get; private set; }

        public WeightedCalculatorParameters(decimal? dividend, decimal? divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }
    }
}