using System;
using codestuffers.MvvmCrossPlugins.UserInteraction;
using Android.Widget;
using Android.App;
using Cirrious.CrossCore.Core;
using System.Threading;
using Cirrious.CrossCore.Droid.Platform;

namespace codestuffers.MvvmCrossPlugins.UserInteraction.Droid
{
	public class MvxUserInteraction : IMvxUserInteraction
	{
        IMvxMainThreadDispatcher _dispatcher;
        IMvxAndroidCurrentTopActivity _topActivity;

        public MvxUserInteraction(IMvxMainThreadDispatcher dispatcher, IMvxAndroidCurrentTopActivity topActivity)
		{
            _topActivity = topActivity;
            _dispatcher = dispatcher;
		}

		public void Alert (string message)
		{
            Alert(message, null);
//            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(Application.Context);
//            alertDialogBuilder.SetMessage(message);
//
//            // create alert dialog
//            AlertDialog alertDialog = alertDialogBuilder.Create();
//
//            _dispatcher.RequestMainThreadAction(() => alertDialog.Show());
		}

		public void Alert (string message, string title)
        {
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(_topActivity.Activity);
            alertDialogBuilder.SetMessage(message);

            if (title != null)
            {
                alertDialogBuilder.SetTitle(title);
            }

            // create alert dialog
            AlertDialog alertDialog = alertDialogBuilder.Create();

            _dispatcher.RequestMainThreadAction(() => alertDialog.Show());
		}

		public void ShowDialog (string message, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
		{
			throw new NotImplementedException ();
		}

		public void ShowDialog (string message, string title, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
		{
			throw new NotImplementedException ();
		}

		public void WithProgressBar<T> (System.Threading.Tasks.Task<T> task, Action<System.Threading.Tasks.Task<T>> onCompletion)
		{
			throw new NotImplementedException ();
		}
	}
}

