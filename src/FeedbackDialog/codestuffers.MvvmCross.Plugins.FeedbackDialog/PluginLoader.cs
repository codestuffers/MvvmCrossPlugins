using System;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.File;
using codestuffers.MvvmCross.Plugins.UserInteraction;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog
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
                    var manager = Mvx.Resolve<IMvxPluginManager>();
                    manager.EnsurePlatformAdaptionLoaded<PluginLoader>();

                    ((MvxFeedbackDialog) Mvx.GetSingleton<IMvxFeedbackDialog>()).SetConfiguration(_configuration);
                }));
        }

        /// <summary>
        /// Configure the plugin
        /// </summary>
        /// <param name="configuration">Plugin configuration data</param>
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
