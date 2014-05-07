namespace PhuLiNet.Business.Common.Calculation
{
    public class WeightedCalculator
    {
        private WeightedCalculatorParameters[] WeightParamList;

        public WeightedCalculator(params WeightedCalculatorParameters[] weightParamList)
        {
            WeightParamList = weightParamList;
        }

        private decimal? GetTotalDivisor()
        {
            decimal? result = null;
            if (WeightParamList != null)
            {
                foreach (WeightedCalculatorParameters weightParam in WeightParamList)
                {
                    if (weightParam.Divisor.HasValue)
                    {
                        if (!result.HasValue)
                            result = 0m;
                        result += weightParam.Divisor;
                    }
                }
            }
            return result;
        }


        public decimal? Calculate()
        {
            decimal? result = null;
            decimal? totalDivisor = GetTotalDivisor();
            if (totalDivisor > 0)
            {
                decimal? totalDividend = null;
                foreach (WeightedCalculatorParameters weightParam in WeightParamList)
                {
                    if (weightParam.Divisor.HasValue && weightParam.Dividend.HasValue)
                    {
                        if (!totalDividend.HasValue)
                        {
                            totalDividend = 0m;
                        }
                        totalDividend += weightParam.Dividend*weightParam.Divisor;
                    }
                }

                if (totalDividend.HasValue)
                {
                    result = totalDividend/totalDivisor;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}