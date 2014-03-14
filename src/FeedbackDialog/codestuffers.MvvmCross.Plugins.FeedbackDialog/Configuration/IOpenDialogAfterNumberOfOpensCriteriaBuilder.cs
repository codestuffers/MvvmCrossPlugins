using System;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Configuration
{
    public interface IOpenDialogAfterNumberOfOpensCriteriaBuilder : IFinishOpenDialogCriteriaBuilder
    {
        IFinishOpenDialogCriteriaBuilder AndAfterTimeUsed(TimeSpan timeUsed);
    }
}