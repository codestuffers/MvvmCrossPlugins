namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.OpenCriteria
{
    /// <summary>
    /// Dialog display criteria that depends only on the amount of times the app has been opened
    /// </summary>
    internal class RequiredOpensCriteria : IOpenDialogCriteria
    {
        /// <summary>
        /// Instantiates a RequiredOpensCriteria object
        /// </summary>
        /// <param name="showDialogAfterOpens">Number of times after which the dialog should be opened</param>
        public RequiredOpensCriteria(int showDialogAfterOpens)
        {
            ShowDialogAfterOpens = showDialogAfterOpens;
        }

        /// <summary>
        /// Number of times after which the dialog should be opened
        /// </summary>
        public int ShowDialogAfterOpens { get; private set; }

        /// <summary>
        /// Checks whether the dialog should be opened based on the feedback data
        /// </summary>
        /// <param name="data">Data that should be used to check</param>
        /// <returns></returns>
        public bool ShouldOpen(FeedbackData data)
        {
            return data.TimesAppHasStarted >= ShowDialogAfterOpens;
        }
    }
}

