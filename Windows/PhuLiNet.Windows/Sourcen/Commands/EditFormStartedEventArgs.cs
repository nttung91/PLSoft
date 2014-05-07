using System;
using PhuLiNet.Business.Common.CslaBase;

namespace Windows.Core.Commands
{
    public class EditFormStartedEventArgs : EventArgs
    {
        public IPhuLiBusinessBase BusinessObject { get; private set; }

        public EditFormStartedEventArgs(IPhuLiBusinessBase businessObject)
        {
            BusinessObject = businessObject;
        }
    }
}