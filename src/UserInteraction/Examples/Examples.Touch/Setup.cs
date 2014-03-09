using MonoTouch.UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using codestuffers.MvvmCross.Plugins.UserInteraction.Examples.Core;

namespace Examples.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
	}
}