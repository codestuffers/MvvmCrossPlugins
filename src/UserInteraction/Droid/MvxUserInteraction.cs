using System;
using System.Threading;
using Android.App;
using Android.Widget;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.Droid.Platform;
using codestuffers.MvvmCrossPlugins.UserInteraction;

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
		}

		public void Alert (string message, string title)
        {
            DisplayDialogWithButtons(message, title, x => x.SetNeutralButton("Ok", (sender, e) => { }));
		}

		public void ShowDialog (string message, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
		{
            ShowDialog(message, null, leftButton, rightButton, leftButtonAction, rightButtonAction);
		}

		public void ShowDialog (string message, string title, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
        {
            DisplayDialogWithButtons(message, title, x => {
                x.SetNegativeButton(leftButton, (sender, e) => leftButtonAction());
                x.SetPositiveButton(rightButton, (sender, e) => rightButtonAction());
            });
		}

		public void WithProgressBar<T> (System.Threading.Tasks.Task<T> task, Action<System.Threading.Tasks.Task<T>> onCompletion)
		{
			throw new NotImplementedException ();
		}

        private void DisplayDialogWithButtons(string message, string title, Action<AlertDialog.Builder> buttonBuilder)
        {
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(_topActivity.Activity);
            alertDialogBuilder.SetMessage(message);

            if (title != null)
            {
                alertDialogBuilder.SetTitle(title);
            }

            buttonBuilder(alertDialogBuilder);

            AlertDialog alertDialog = alertDialogBuilder.Create();

            _dispatcher.RequestMainThreadAction(() => alertDialog.Show());
        }
	}
}

