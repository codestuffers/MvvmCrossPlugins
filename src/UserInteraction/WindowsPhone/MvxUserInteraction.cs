using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cirrious.CrossCore.Core;
using codestuffers.MvvmCross.UserInteraction.Core;

namespace codestuffers.MvvmCross.UserInteraction.WindowsPhone
{
    public class MvxUserInteraction : MvxUserInteractionBase
    {
        public MvxUserInteraction(IMvxMainThreadDispatcher dispatcher) : base(dispatcher)
        {
        }

        public override void Alert(string message)
        {
            Dispatcher.RequestMainThreadAction(() => MessageBox.Show(message));
        }
    }
}
