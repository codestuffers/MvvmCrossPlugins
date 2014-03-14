using System;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria
{
    internal class TimeUsedCriteria : IOpenDialogCriteria
    {
        private readonly TimeSpan _timeUsed;

        public TimeUsedCriteria(TimeSpan timeUsed)
        {
            _timeUsed = timeUsed;
            CurrentTime = () => DateTime.UtcNow;
        }

        internal TimeSpan TimesOpen { get { return _timeUsed; } }

        public Func<DateTime> CurrentTime { get; set; }

        public bool ShouldOpen(FeedbackData data)
        {
            return CurrentTime().Subtract(_timeUsed) > data.AppInstallDate;
        }
    }
}
