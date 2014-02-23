using Cirrious.CrossCore.Core;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace codestuffers.MvvmCrossPlugins.UserInteraction.WindowsPhone
{
    /// <summary>
    /// Provides user interaction functionality in a cross platform way
    /// </summary>
    public class MvxUserInteraction : IMvxUserInteraction
    {
        private readonly IMvxMainThreadDispatcher _dispatcher;
        private readonly ProgressHelper _progressHelper;

        public MvxUserInteraction(IMvxMainThreadDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _progressHelper = new ProgressHelper(_dispatcher);
        }

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        public void Alert(string message)
        {
            _dispatcher.RequestMainThreadAction(() => MessageBox.Show(message));
        }

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        /// <param name="title">Title of the message box</param>
        public void Alert(string message, string title)
        {
            _dispatcher.RequestMainThreadAction(() => MessageBox.Show(message, title ?? string.Empty, MessageBoxButton.OK));
        }

        /// <summary>
        /// Show a dialog box
        /// </summary>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="message">Detailed message that will be displayed</param>
        /// <param name="leftButton">Text for the left button</param>
        /// <param name="rightButton">Text for the right button</param>
        /// <param name="leftButtonAction">Action that will be executed if the left button is pressed</param>
        /// <param name="rightButtonAction">Action that will be executed if the right button is pressed</param>
        public void ShowDialog(string title, string message, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
        {
            var messageBox = new CustomMessageBox
            {
                IsLeftButtonEnabled = true,
                IsRightButtonEnabled = true,
                LeftButtonContent = leftButton,
                RightButtonContent = rightButton,
                Message = message,
                Title = title
            };

            messageBox.Dismissed += (sender, args) =>
            {
                if (args.Result == CustomMessageBoxResult.LeftButton)
                {
                    leftButtonAction();
                }
                else if (args.Result == CustomMessageBoxResult.RightButton)
                {
                    rightButtonAction();
                }
            };

            messageBox.Show();
        }

        /// <summary>
        /// Displays a progress indicator while the specified task is executing
        /// </summary>
        /// <typeparam name="T">Type of data associated with the task</typeparam>
        /// <param name="task">Task that is executing</param>
        /// <param name="onCompletion">Action that is executed when the task is complete</param>
        public void WithProgressBar<T>(Task<T> task, Action<Task<T>> onCompletion)
        {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;
            var currentPage = (frame != null) ? frame.Content as PhoneApplicationPage : null;

            _progressHelper.SetupTask(task, onCompletion, 
                StartProgressAction(currentPage),
                StopProgressAction(currentPage));
        }

        private static Action StartProgressAction(DependencyObject currentPage)
        {
            return () =>
            {
                if (currentPage == null) return;
                var prog = new ProgressIndicator { IsVisible = true, IsIndeterminate = true };
                SystemTray.SetProgressIndicator(currentPage, prog);
            };
        }

        private static Action StopProgressAction(DependencyObject currentPage)
        {
            return () =>
            {
                if (currentPage == null) return;
                SystemTray.SetProgressIndicator(currentPage, null);
            };
        }
    }
}
