using Cirrious.CrossCore;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.Plugins;

namespace codestuffers.MvvmCrossPlugins.UserInteraction.Touch
{
    /// <summary>
    /// Defines the platform specific version of the plugin
    /// </summary>
    public class Plugin : IMvxPlugin
    {
        /// <summary>
        /// Loads the plugin
        /// </summary>
        public void Load()
        {
            Mvx.CallbackWhenRegistered<IMvxMainThreadDispatcher>(Mvx.ConstructAndRegisterSingleton<IMvxUserInteraction, MvxUserInteraction>);
        }
    } 
}
