using System;

namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    internal class FeedbackData : IFeedbackData
    {
        public int TimesAppHasStarted { get; set; }

        public DateTime AppInstallDate { get; set; }

        public void AppHasOpened()
        {
            if (TimesAppHasStarted == 0)
            {
                AppInstallDate = DateTime.UtcNow;
            }

            TimesAppHasStarted++;
        }

        public bool ShouldOpenDialog(int requiredOpens)
        {
            return TimesAppHasStarted >= requiredOpens;
        }

        public bool DialogWasShown { get; set; }
    }
}