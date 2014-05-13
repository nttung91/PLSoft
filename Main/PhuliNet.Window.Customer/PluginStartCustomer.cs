using Windows.Core.Commands;
using PhuLiNet.Plugin.Contracts;
using PhuliNet.Window.Customer.Commands;

namespace PhuliNet.Window.Customer
{
    public class PluginStartCustomer : PluginBase
    {
        public override void Configure()
        {
            Shortcut = "NTG_TEST";
            Description = "TUng";
        }

        public override void Start(IStartParameter parameter)
        {
            CommandExecutor.Execute(new StartCustomerForm());

        }
    }
}
