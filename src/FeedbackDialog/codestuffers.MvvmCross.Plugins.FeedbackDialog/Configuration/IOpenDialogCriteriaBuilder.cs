using System;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Configuration
{
    public interface IOpenDialogCriteriaBuilder : IFinishOpenDialogCriteriaBuilder
    {
        IOpenDialogAfterNumberOfOpensCriteriaBuilder NumberOfOpens(int openCount);
        IOpenDialogAfterTimeUsedCrtieriaBuilder TimeUsed(TimeSpan timeUsed);
    }
}
