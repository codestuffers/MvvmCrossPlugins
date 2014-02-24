using System;
using codestuffers.MvvmCrossPlugins.UserInteraction;
using Cirrious.CrossCore.Core;
using MonoTouch.UIKit;

namespace codestuffers.MvvmCrossPlugins.UserInteraction.Touch
{
    /// <summary>
    /// Provides user interaction functionality in a cross platform way
    /// </summary>
    public class MvxUserInteraction : IMvxUserInteraction
    {
        IMvxMainThreadDispatcher _dispatcher;

        public MvxUserInteraction(IMvxMainThreadDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        public void Alert(string message)
        {
            Alert(message, null);
        }

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        /// <param name="title">Title of the message box</param>
        public void Alert(string message, string title)
        {
            var alert = new UIAlertView(title ?? string.Empty, message, null, "Ok", null);

            _dispatcher.RequestMainThreadAction(() => alert.Show());
        }

        /// <summary>
        /// Show a dialog box
        /// </summary>
        /// <param name="message">Detailed message that will be displayed</param>
        /// <param name="leftButton">Text for the left button</param>
        /// <param name="rightButton">Text for the right button</param>
        /// <param name="leftButtonAction">Action that will be executed if the left button is pressed</param>
        /// <param name="rightButtonAction">Action that will be executed if the right button is pressed</param>
        public void ShowDialog(string message, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
        {
            throw new NotImplementedException();
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
        public void ShowDialog(string message, string title, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Displays a progress indicator while the specified task is executing
        /// </summary>
        /// <typeparam name="T">Type of data associated with the task</typeparam>
        /// <param name="task">Task that is executing</param>
        /// <param name="onCompletion">Action that is executed when the task is complete</param>
        public void WithProgressBar<T>(System.Threading.Tasks.Task<T> task, Action<System.Threading.Tasks.Task<T>> onCompletion)
        {
            throw new NotImplementedException();
        }
    }
}

