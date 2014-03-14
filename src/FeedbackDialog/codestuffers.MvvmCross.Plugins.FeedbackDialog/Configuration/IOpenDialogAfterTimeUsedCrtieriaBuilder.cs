namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Configuration
{
    public interface IOpenDialogAfterTimeUsedCrtieriaBuilder : IFinishOpenDialogCriteriaBuilder
    {
        IFinishOpenDialogCriteriaBuilder AndAfterNumberOfOpens(int openCount);
    }
}