using System.Collections;
using System.Collections.Generic;
using Cirrious.CrossCore.Plugins;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.Configuration;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog
{
    /// <summary>
    /// Configuration data for the Feedback Dialog plugin
    /// </summary>
    public class FeedbackDialogConfiguration : IMvxPluginConfiguration
    {
        private IFinishOpenDialogCriteriaBuilder _openDialogCriteria;

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
            OpenDialogCriteria = OpenDialog.After.NumberOfOpens(3);
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

        public IFinishOpenDialogCriteriaBuilder OpenDialogCriteria
        {
            get { return _openDialogCriteria; }
            set
            {
                _openDialogCriteria = value;
                OpenCriteria = (value as OpenDialogCriteriaBuilder).OpenDialogCriteria;
            }
        }

        internal IEnumerable<IOpenDialogCriteria> OpenCriteria { get; set; }
    }
}
