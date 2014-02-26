using Cirrious.MvvmCross.Plugins.Email;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using codestuffers.MvvmCrossPlugins.UserInteraction;

namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    public class MvxFeedbackDialog : IMvxFeedbackDialog
    {
        private readonly IMvxUserInteraction _userInteraction;
        private readonly IFeedbackDataService _dataService;
        private readonly IMvxComposeEmailTask _composeEmailTask;
        private readonly IMvxWebBrowserTask _webBrowser;

        public MvxFeedbackDialog(IMvxUserInteraction userInteraction, IFeedbackDataService dataService,
            IMvxComposeEmailTask composeEmailTask, IMvxWebBrowserTask webBrowser)
        {
            _userInteraction = userInteraction;
            _dataService = dataService;
            _composeEmailTask = composeEmailTask;
            _webBrowser = webBrowser;
        }

        public void RecordAppStart()
		{
            if (_dataService.AppWasOpened(3) == FeedbackAction.OpenDialog)
            {
                _userInteraction.ShowDialog("What do you think of the app so far?", "Feedback",
                    "Love it!", "Hate it...", HandleLoveIt, HandleHateIt);
			}
		}

        public void ResetOpenCount()
        {
            _dataService.ResetAppCount();
        }

        private void HandleLoveIt()
        {
            _dataService.DialogWasShown();

            _webBrowser.ShowWebPage("http://www.github.com");
        }

        private void HandleHateIt()
        {
            _dataService.DialogWasShown();

            _composeEmailTask.ComposeEmail("info@example.com", null, "Feedback for example", "Sorry to hear that, please tell us why...", false);
        }
    }
}