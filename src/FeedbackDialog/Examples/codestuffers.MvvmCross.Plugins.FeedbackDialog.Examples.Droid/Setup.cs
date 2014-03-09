using Android.Content;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.Plugins;
using System;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Examples.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
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