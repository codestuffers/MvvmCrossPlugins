using System;
using Cirrious.MvvmCross.Plugins.Email;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using codestuffers.MvvmCross.Plugins.UserInteraction;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog
{
    /// <summary>
    /// Feedback dialog
    /// </summary>
    public class MvxFeedbackDialog : IMvxFeedbackDialog
    {
        private readonly IMvxUserInteraction _userInteraction;
        private readonly IFeedbackDataService _dataService;
        private readonly IMvxComposeEmailTask _composeEmailTask;
        private readonly IMvxWebBrowserTask _webBrowser;
        private FeedbackDialogConfiguration _configuration;

        /// <summary>
        /// Creates a new instance of the FeedbackDialog
        /// </summary>
        public MvxFeedbackDialog(IMvxUserInteraction userInteraction, IFeedbackDataService dataService,
            IMvxComposeEmailTask composeEmailTask, IMvxWebBrowserTask webBrowser)
        {
            _userInteraction = userInteraction;
            _dataService = dataService;
            _composeEmailTask = composeEmailTask;
            _webBrowser = webBrowser;
        }

        /// <summary>
        /// Record that the app has started
        /// </summary>
        /// <remarks>This should be the only method your app needs to interact with the dialog</remarks>
        public void RecordAppStart()
		{
            if (_dataService.AppWasOpened(_configuration.ShowFeedbackAfterApplicationOpenCount) == FeedbackAction.OpenDialog)
            {
                _dataService.DialogWasShown();
                _userInteraction.ShowDialog(_configuration.DialogBody, _configuration.DialogTitle,
                    _configuration.HateItButtonText, _configuration.LoveItButtonText, HandleHateIt, HandleLoveIt);
			}
		}

        /// <summary>
        /// Resets the app open count
        /// </summary>
        /// <remarks>This is primarily meant for testing and could annoy users if you use it in a real app</remarks>
        public void ResetOpenCount()
        {
            _dataService.ResetAppCount();
        }

        /// <summary>
        /// Handle a click of the Love it! button
        /// </summary>
        protected virtual void HandleLoveIt()
        {
            _webBrowser.ShowWebPage(_configuration.ApplicationReviewUrl);
        }

        /// <summary>
        /// Handle a click of the Hate it... button
        /// </summary>
        protected virtual void HandleHateIt()
        {
            _composeEmailTask.ComposeEmail(_configuration.FeedbackEmailAddress, null, 
                _configuration.FeedbackSubject, _configuration.FeedbackBody, false);
        }

        /// <summary>
        /// Sets the configuration data for the plugin
        /// </summary>
        /// <param name="configuration">Configuration that will be used by the plugin</param>
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