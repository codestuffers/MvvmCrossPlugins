using System;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using codestuffers.MvvmCross.Plugins.FeedbackDialog;
using Microsoft.Phone.Controls;

namespace FeedbackDialog.Examples.WindowsPhone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new codestuffers.MvvmCross.Plugins.FeedbackDialog.Examples.App();
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