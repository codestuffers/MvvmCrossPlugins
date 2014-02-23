using System;
using System.Threading.Tasks;

namespace codestuffers.MvvmCross.UserInteraction.Core
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
        /// Displays a progress indicator while the specified task is executing
        /// </summary>
        /// <typeparam name="T">Type of data associated with the task</typeparam>
        /// <param name="task">Task that is executing</param>
        /// <param name="onCompletion">Action that is executed when the task is complete</param>
        void WithProgressBar<T>(Task<T> task, Action<Task<T>> onCompletion);
    }
}
