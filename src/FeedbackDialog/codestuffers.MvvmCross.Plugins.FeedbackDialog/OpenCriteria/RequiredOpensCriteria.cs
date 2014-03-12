using System;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria
{
    internal class RequiredOpensCriteria : IOpenDialogCriteria
    {
        public RequiredOpensCriteria(int showDialogAfterOpens)
        {
            ShowDialogAfterOpens = showDialogAfterOpens;
        }

        public int ShowDialogAfterOpens { get; private set; }

        public bool ShouldOpen(FeedbackData data)
        {
            return data.TimesAppHasStarted >= ShowDialogAfterOpens;
        }
    }
}

