using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.File;
using codestuffers.MvvmCrossPlugins.UserInteraction;

namespace codestuffers.MvvmCrossPlugins.FeedbackDialog
{
    /// <summary>
    /// Loads the UserInteraction plugin
    /// </summary>
    public class PluginLoader : IMvxPluginLoader
    {
        public static readonly PluginLoader Instance = new PluginLoader();

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
                }));
        }
    }
}
