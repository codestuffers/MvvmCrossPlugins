using System;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria
{
    internal class TimeUsedCriteria : IOpenDialogCriteria
    {
        private readonly TimeSpan _fromDays;

        public TimeUsedCriteria(TimeSpan fromDays)
        {
            _fromDays = fromDays;
            CurrentTime = () => DateTime.UtcNow;
        }

        public Func<DateTime> CurrentTime { get; set; }

        public bool ShouldOpen(FeedbackData data)
        {
            return CurrentTime().Subtract(_fromDays) > data.AppInstallDate;
        }
    }
}
