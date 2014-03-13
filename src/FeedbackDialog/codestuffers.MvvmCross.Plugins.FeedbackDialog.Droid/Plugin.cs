using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Droid
{
	public class Plugin : IMvxPlugin
	{
		public void Load ()
		{
			Mvx.ConstructAndRegisterSingleton<IMvxFeedbackDialog, MvxFeedbackDialog>();
		}
	}
}
