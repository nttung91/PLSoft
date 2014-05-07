using System;
using System.Diagnostics.Contracts;

namespace Technical.Utilities.Exceptions
{
    public class ContractsHandlingTester
    {
        public void Test()
        {
            Contract.Requires<ArgumentOutOfRangeException>(0 == 1);
        }
    }
}