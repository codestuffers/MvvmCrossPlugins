using MonoTouch.UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.CrossCore.Plugins;
using System;
using codestuffers.MvvmCross.Plugins.FeedbackDialog;

namespace FeedbackDialog.Examples.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(Type plugin)
        {
            if (plugin == typeof(PluginLoader))
            {
                // This is the minimum configuration needed to use the feedback dialog
                return new FeedbackDialogConfiguration
                {
                    ApplicationReviewUrl = "https://www.github.com",
                    FeedbackEmailAddress = "info@example.com"
                };
            }

            return null;
        }
	}
}