using Cirrious.CrossCore.Plugins;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog
{
    /// <summary>
    /// Configuration data for the Feedback Dialog plugin
    /// </summary>
    public class FeedbackDialogConfiguration : IMvxPluginConfiguration
    {
        /// <summary>
        /// Creates a new instance of FeedbackDialogConfiguration
        /// </summary>
        public FeedbackDialogConfiguration()
        {
            FeedbackBody = "Sorry to hear that, please tell us why...";
            FeedbackSubject = "Feedback for application";
            DialogTitle = "Feedback";
            DialogBody = "What do you think of the app so far?";
            LoveItButtonText = "Love it!";
            HateItButtonText = "Hate it...";
            ShowFeedbackAfterApplicationOpenCount = 3;
        }

        /// <summary>
        /// Specifies the message that will be shown in the body of the dialog
        /// </summary>
        public string DialogBody { get; set; }

        /// <summary>
        /// Specifies the title of the dialog
        /// </summary>
        public string DialogTitle { get; set; }

        /// <summary>
        /// Text that will be displayed for the Love it! button
        /// </summary>
        public string LoveItButtonText { get; set; }

        /// <summary>
        /// Text that will be displayed for the Hate it... button
        /// </summary>
        public string HateItButtonText { get; set; }

        /// <summary>
        /// Url for the app's review site
        /// </summary>
        public string ApplicationReviewUrl { get; set; }

        /// <summary>
        /// Email address that should receive feedback
        /// </summary>
        public string FeedbackEmailAddress { get; set; }

        /// <summary>
        /// Default subject for the feedback email
        /// </summary>
        public string FeedbackSubject { get; set; }

        /// <summary>
        /// Default body of the feedback email
        /// </summary>
        public string FeedbackBody { get; set; }

        /// <summary>
        /// Number of times the app should be opened before showing the feedback dialog
        /// </summary>
        public int ShowFeedbackAfterApplicationOpenCount { get; set; }
    }
}
