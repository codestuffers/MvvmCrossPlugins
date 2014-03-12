using System;
using Newtonsoft.Json;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog
{
    /// <summary>
    /// Holds the data needed by the feedback dialog to operate
    /// </summary>
    internal class FeedbackData
    {
        /// <summary>
        /// Numer of times the app has been opened
        /// </summary>
        [JsonProperty]
        internal int TimesAppHasStarted { get; set; }

        /// <summary>
        /// Date of the first time the application was opened
        /// </summary>
        [JsonProperty]
        internal DateTime AppInstallDate { get; set; }

        /// <summary>
        /// Has the dialog been opened yet?
        /// </summary>
        public bool DialogWasShown { get; set; }

        /// <summary>
        /// Track that the application was opened
        /// </summary>
        public void AppHasOpened()
        {
            if (TimesAppHasStarted == 0)
            {
                AppInstallDate = DateTime.UtcNow;
            }

            TimesAppHasStarted++;
        }

        /// <summary>
        /// Gets whether the dialog should be opened
        /// </summary>
        /// <param name="requiredOpens">Number of times the app is required to open before showing the dialog</param>
        /// <returns>True if the dialog should be opened or false if not.</returns>
        public bool ShouldOpenDialog(int requiredOpens)
        {
            return !DialogWasShown &&  TimesAppHasStarted >= requiredOpens;
        }
    }
}