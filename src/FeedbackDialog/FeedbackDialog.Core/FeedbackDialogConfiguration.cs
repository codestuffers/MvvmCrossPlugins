using System.Runtime.Versioning;
using Cirrious.CrossCore.Plugins;

namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    public class FeedbackDialogConfiguration : IMvxPluginConfiguration
    {
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

        public string DialogBody { get; set; }

        public string DialogTitle { get; set; }

        public string LoveItButtonText { get; set; }

        public string HateItButtonText { get; set; }

        public string ApplicationReviewUrl { get; set; }

        public string FeedbackEmailAddress { get; set; }

        public string FeedbackSubject { get; set; }

        public string FeedbackBody { get; set; }

        public int ShowFeedbackAfterApplicationOpenCount { get; set; }
    }
}
