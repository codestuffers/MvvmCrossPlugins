using System;
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
        private FeedbackDialogConfiguration _configuration;

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
            if (_dataService.AppWasOpened(_configuration.ShowFeedbackAfterApplicationOpenCount) == FeedbackAction.OpenDialog)
            {
                _userInteraction.ShowDialog(_configuration.DialogTitle, _configuration.DialogBody,
                    _configuration.LoveItButtonText, _configuration.HateItButtonText, HandleLoveIt, HandleHateIt);
			}
		}

        public void ResetOpenCount()
        {
            _dataService.ResetAppCount();
        }

        private void HandleLoveIt()
        {
            _dataService.DialogWasShown();

            _webBrowser.ShowWebPage(_configuration.ApplicationReviewUrl);
        }

        private void HandleHateIt()
        {
            _dataService.DialogWasShown();

            _composeEmailTask.ComposeEmail(_configuration.FeedbackEmailAddress, null, 
                _configuration.FeedbackSubject, _configuration.FeedbackBody, false);
        }

        internal void SetConfiguration(FeedbackDialogConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            _configuration = configuration;
        }
    }
}