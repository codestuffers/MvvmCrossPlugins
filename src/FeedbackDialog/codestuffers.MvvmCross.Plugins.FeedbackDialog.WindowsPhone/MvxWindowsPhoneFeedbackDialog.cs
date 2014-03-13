using Cirrious.MvvmCross.Plugins.Email;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using codestuffers.MvvmCross.Plugins.UserInteraction;
using Microsoft.Phone.Tasks;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.WindowsPhone
{
    public class MvxWindowsPhoneFeedbackDialog : MvxFeedbackDialog
    {
        public MvxWindowsPhoneFeedbackDialog(IMvxUserInteraction userInteraction, 
            IFeedbackDataService dataService, IMvxComposeEmailTask composeEmailTask, 
            IMvxWebBrowserTask webBrowser) : 
            base(userInteraction, dataService, composeEmailTask, webBrowser)
        {
        }

        protected override void HandleLoveIt()
        {
            var marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
    }
}
