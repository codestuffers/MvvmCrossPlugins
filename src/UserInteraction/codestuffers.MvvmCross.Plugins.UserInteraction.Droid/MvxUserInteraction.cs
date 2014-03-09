using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.Droid.Platform;
using codestuffers.MvvmCross.Plugins.UserInteraction;

namespace codestuffers.MvvmCross.Plugins.UserInteraction.Droid
{
    /// <summary>
    /// Provides user interaction functionality in a cross platform way
    /// </summary>
	public class MvxUserInteraction : IMvxUserInteraction
	{
        IMvxMainThreadDispatcher _dispatcher;
        IMvxAndroidCurrentTopActivity _topActivity;
        ProgressHelper _progressHelper;

        public MvxUserInteraction(IMvxMainThreadDispatcher dispatcher, IMvxAndroidCurrentTopActivity topActivity)
		{
            _topActivity = topActivity;
            _dispatcher = dispatcher;
            _progressHelper = new ProgressHelper(_dispatcher);
		}

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
		public void Alert (string message)
		{
            Alert(message, null);
		}

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        /// <param name="title">Title of the message box</param>
		public void Alert (string message, string title)
        {
            DisplayDialogWithButtons(message, title, x => x.SetNeutralButton("Ok", (sender, e) => { }));
		}

        /// <summary>
        /// Show a dialog box
        /// </summary>
        /// <param name="message">Detailed message that will be displayed</param>
        /// <param name="leftButton">Text for the left button</param>
        /// <param name="rightButton">Text for the right button</param>
        /// <param name="leftButtonAction">Action that will be executed if the left button is pressed</param>
        /// <param name="rightButtonAction">Action that will be executed if the right button is pressed</param>
		public void ShowDialog (string message, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
		{
            ShowDialog(message, null, leftButton, rightButton, leftButtonAction, rightButtonAction);
		}

        /// <summary>
        /// Show a dialog box
        /// </summary>
        /// <param name="message">Detailed message that will be displayed</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="leftButton">Text for the left button</param>
        /// <param name="rightButton">Text for the right button</param>
        /// <param name="leftButtonAction">Action that will be executed if the left button is pressed</param>
        /// <param name="rightButtonAction">Action that will be executed if the right button is pressed</param>
		public void ShowDialog (string message, string title, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
        {
            DisplayDialogWithButtons(message, title, x => {
                x.SetNegativeButton(leftButton, (sender, e) => ExecuteAction(leftButtonAction));
                x.SetPositiveButton(rightButton, (sender, e) => ExecuteAction(rightButtonAction));
            });
		}

        /// <summary>
        /// Displays a progress indicator while the specified task is executing
        /// </summary>
        /// <typeparam name="T">Type of data associated with the task</typeparam>
        /// <param name="task">Task that is executing</param>
        /// <param name="onCompletion">Action that is executed when the task is complete</param>
        public void WithActivityIndicator<T> (Task<T> task, Action<Task<T>> onCompletion)
		{
            if (!_topActivity.Activity.Window.HasFeature(Android.Views.WindowFeatures.IndeterminateProgress))
            {
                throw new InvalidOperationException("You must call \"RequestWindowFeature(Android.Views.WindowFeatures.IndeterminateProgress);\" in the View's OnViewModelSet() method in order to use the WithProgressBar method");
            }

            _progressHelper.SetupTask(task, onCompletion, 
                () => _topActivity.Activity.SetProgressBarIndeterminateVisibility(true),
                () => _topActivity.Activity.SetProgressBarIndeterminateVisibility(false));
		}

        /// <summary>
        /// Executes the action if it is not null
        /// </summary>
        /// <param name="action">Action that will be executed</param>
        private static void ExecuteAction(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        /// <summary>
        /// Displaies a dialog with buttons
        /// </summary>
        /// <param name="message">Message that will be displayed</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="buttonBuilder">Button builder.</param>
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

