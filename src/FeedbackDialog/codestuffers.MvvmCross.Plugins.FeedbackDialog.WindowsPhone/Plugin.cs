using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.WindowsPhone
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.ConstructAndRegisterSingleton<IMvxFeedbackDialog, MvxWindowsPhoneFeedbackDialog>();
        }
    }
}
