using System;
using System.Threading.Tasks;
using System.Windows;
using Cirrious.CrossCore.Core;
using codestuffers.MvvmCross.UserInteraction.Core;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace codestuffers.MvvmCross.UserInteraction.WindowsPhone
{
    /// <summary>
    /// Provides user interaction functionality in a cross platform way
    /// </summary>
    public class MvxUserInteraction : MvxUserInteractionBase
    {
        public MvxUserInteraction(IMvxMainThreadDispatcher dispatcher) : base(dispatcher)
        {
        }

        /// <summary>
        /// Shows a message box with the specified message
        /// </summary>
        /// <param name="message">Message that should be displayed</param>
        public override void Alert(string message)
        {
            Dispatcher.RequestMainThreadAction(() => MessageBox.Show(message));
        }

        /// <summary>
        /// Displays a progress indicator while the specified task is executing
        /// </summary>
        /// <typeparam name="T">Type of data associated with the task</typeparam>
        /// <param name="task">Task that is executing</param>
        /// <param name="onCompletion">Action that is executed when the task is complete</param>
        public override void WithProgressBar<T>(Task<T> task, Action<Task<T>> onCompletion)
        {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;
            var currentPage = (frame != null) ? frame.Content as PhoneApplicationPage : null;

            Dispatcher.RequestMainThreadAction(() =>
            {
                if (currentPage == null) return;

                var prog = new ProgressIndicator { IsVisible = true, IsIndeterminate = true };
                SystemTray.SetProgressIndicator(currentPage, prog);
            });

            task.ContinueWith(x =>
            {
                onCompletion(task);

                Dispatcher.RequestMainThreadAction(() =>
                {
                    if (currentPage == null) return;
                    SystemTray.SetProgressIndicator(currentPage, null);
                });
            });
        }
    }
}
