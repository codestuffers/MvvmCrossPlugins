using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace codestuffers.MvvmCross.Plugins.UserInteraction
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
            var manager = Mvx.Resolve<IMvxPluginManager>();
            manager.EnsurePlatformAdaptionLoaded<PluginLoader>();
        }
    }
}
