namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    /// <summary>
    /// Feedback Dialog plugin interface
    /// </summary>
    public interface IMvxFeedbackDialog
    {
        /// <summary>
        /// Record that the app has started
        /// </summary>
        /// <remarks>This should be the only method your app needs to interact with the dialog</remarks>
        void RecordAppStart();

        /// <summary>
        /// Resets the app open count
        /// </summary>
        /// <remarks>This is primarily meant for testing and could annoy users if you use it in a real app</remarks>
        void ResetOpenCount();
    }
}
