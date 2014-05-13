using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Core.Commands;
using Windows.Core.WindowsManager;
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
