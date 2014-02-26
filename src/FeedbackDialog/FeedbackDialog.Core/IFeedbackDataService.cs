namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    public interface IFeedbackDataService
    {
        FeedbackAction AppWasOpened(int maxNumberOfOpens);

        void DialogWasShown();

        void ResetAppCount();
    }
}
