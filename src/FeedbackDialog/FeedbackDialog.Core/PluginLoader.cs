using System;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.File;
using codestuffers.MvvmCrossPlugins.UserInteraction;

namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    /// <summary>
    /// Loads the UserInteraction plugin
    /// </summary>
    public class PluginLoader : IMvxConfigurablePluginLoader
    {
        public static readonly PluginLoader Instance = new PluginLoader();
        private FeedbackDialogConfiguration _configuration;

        /// <summary>
        /// Ensures the platform specific version is loaded
        /// </summary>
        public void EnsureLoaded()
        {
            Mvx.CallbackWhenRegistered<IMvxFileStore>(
                () => Mvx.CallbackWhenRegistered<IMvxUserInteraction>(() =>
                {
                    Mvx.ConstructAndRegisterSingleton<IFeedbackDataService, FeedbackDataService>();
                    Mvx.ConstructAndRegisterSingleton<IMvxFeedbackDialog, MvxFeedbackDialog>();
                    ((MvxFeedbackDialog) Mvx.GetSingleton<IMvxFeedbackDialog>()).SetConfiguration(_configuration);
                }));
        }

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration", "The Feedback Dialog needs at least the ApplicationReviewUrl and FeedbackEmailAddress configured");
            }

            _configuration = configuration as FeedbackDialogConfiguration;
        }
    }
}
