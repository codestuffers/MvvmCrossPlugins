using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using codestuffers.MvvmCross.UserInteraction.Core;
using codestuffers.MvvmCross.UserInteraction.WindowsPhone;
using Microsoft.Phone.Controls;

namespace codestuffers.MvvmCrossPlugins.UserInteraction.Examples.WindowsPhone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IMvxUserInteraction, MvxUserInteraction>();
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}