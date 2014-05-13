using Manor.MsExcel.Contracts;
using Techical.MsExcel.EpPlus;

namespace Techical.MsExcel
{
    public class MsExcelWrapperFactory
    {
        public static IExcel GetDefaultInstance()
        {
            return new EpPlusExcelWrapper();
        }

        public static IExcel GetInstance(EExcelImplementation implementation)
        {
            IExcel excelWrapper;

            switch (implementation)
            {
                case EExcelImplementation.EPPlus:
                    excelWrapper = new EpPlusExcelWrapper();
                    break;
                default:
                    excelWrapper = null;
                    break;
            }

            return excelWrapper;
        }
    }
}