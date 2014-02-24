using System;
using System.Threading.Tasks;

namespace codestuffers.MvvmCrossPlugins.UserInteraction
{
    /// <summary>
    /// Provides user interaction functionality in a cross platform way
    /// </summary>
    public interface IMvxUserInteraction
    {
        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        void Alert(string message);

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        /// <param name="title">Title of the message box</param>
        void Alert(string message, string title);

        /// <summary>
        /// Show a dialog box
        /// </summary>
        /// <param name="message">Detailed message that will be displayed</param>
        /// <param name="leftButton">Text for the left button</param>
        /// <param name="rightButton">Text for the right button</param>
        /// <param name="leftButtonAction">Action that will be executed if the left button is pressed</param>
        /// <param name="rightButtonAction">Action that will be executed if the right button is pressed</param>
        void ShowDialog(string message, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction);

        /// <summary>
        /// Show a dialog box
        /// </summary>
        /// <param name="message">Detailed message that will be displayed</param>
        /// <param name="title">Title of the dialog box</param>
        /// <param name="leftButton">Text for the left button</param>
        /// <param name="rightButton">Text for the right button</param>
        /// <param name="leftButtonAction">Action that will be executed if the left button is pressed</param>
        /// <param name="rightButtonAction">Action that will be executed if the right button is pressed</param>
        void ShowDialog(string message, string title, string leftButton, string rightButton, Action leftButtonAction, Action rightButtonAction);

        /// <summary>
        /// Displays a progress indicator while the specified task is executing
        /// </summary>
        /// <typeparam name="T">Type of data associated with the task</typeparam>
        /// <param name="task">Task that is executing</param>
        /// <param name="onCompletion">Action that is executed when the task is complete</param>
        void WithActivityIndicator<T>(Task<T> task, Action<Task<T>> onCompletion);
    }
}
