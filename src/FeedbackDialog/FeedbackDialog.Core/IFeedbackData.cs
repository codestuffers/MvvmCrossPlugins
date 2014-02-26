namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    public interface IFeedbackData
    {
        void AppHasOpened();

        bool ShouldOpenDialog(int requiredOpens);

        bool DialogWasShown { get; set; }
    }
}