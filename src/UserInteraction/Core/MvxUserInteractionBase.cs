using System;
using System.Threading.Tasks;
using Cirrious.CrossCore.Core;

namespace codestuffers.MvvmCross.UserInteraction.Core
{
    public abstract class MvxUserInteractionBase : IMvxUserInteraction
    {
        protected IMvxMainThreadDispatcher Dispatcher { get; private set; }

        protected MvxUserInteractionBase(IMvxMainThreadDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        public abstract void Alert(string message);

        public abstract void WithProgressBar<T>(Task<T> task, Action<Task<T>> onCompletion);
    }
}
