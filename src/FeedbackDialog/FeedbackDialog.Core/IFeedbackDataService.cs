namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    /// <summary>
    /// Handles loading and saving of feedback dialog data
    /// </summary>
    public interface IFeedbackDataService
    {
        /// <summary>
        /// Register an opening of the app
        /// </summary>
        /// <param name="maxNumberOfOpens">Number of times the app is required to open before the dialog is shown</param>
        /// <returns>Returns the action that should be taken by the dialog</returns>
        FeedbackAction AppWasOpened(int maxNumberOfOpens);

        /// <summary>
        /// Tracks that the dialog was shown
        /// </summary>
        void DialogWasShown();

        /// <summary>
        /// Resets the number of times the app has been opened
        /// </summary>
        void ResetAppCount();
    }
}
