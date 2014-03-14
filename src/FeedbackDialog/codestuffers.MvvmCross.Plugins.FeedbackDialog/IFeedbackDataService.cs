namespace codestuffers.MvvmCross.Plugins.FeedbackDialog
{
    /// <summary>
    /// Handles loading and saving of feedback dialog data
    /// </summary>
    public interface IFeedbackDataService
    {
        FeedbackData GetData();

        void SaveData(FeedbackData feedbackData);
    }
}
