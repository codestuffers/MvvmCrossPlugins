using Cirrious.CrossCore.Core;
using System;
using System.Threading.Tasks;

namespace codestuffers.MvvmCross.Plugins.UserInteraction
{
    /// <summary>
    /// Helper class that executes a task with a progress bar
    /// </summary>
    public class ProgressHelper
    {
        private readonly IMvxMainThreadDispatcher _dispatcher;
        private int _progressIndicatorCount;

        public ProgressHelper(IMvxMainThreadDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// Setup the execution of the task with a progress indicator
        /// </summary>
        /// <typeparam name="T">Type of task return value</typeparam>
        /// <param name="task">Task that is executing</param>
        /// <param name="onCompletion">Action that will be executed when the task is complete</param>
        /// <param name="startProgressAction">Action that will show the progress indicator</param>
        /// <param name="stopProgressAction">Action that will hide the progress indicator</param>
        public void SetupTask<T>(Task<T> task, Action<Task<T>> onCompletion, Action startProgressAction, Action stopProgressAction)
        {
            _progressIndicatorCount++;
            _dispatcher.RequestMainThreadAction(startProgressAction);

            task.ContinueWith(x =>
            {
                onCompletion(task);

                if (--_progressIndicatorCount == 0)
                {
                    _dispatcher.RequestMainThreadAction(stopProgressAction);
                }
            });
        }
    }
}
