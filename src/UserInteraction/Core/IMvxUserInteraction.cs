using System;
using System.Threading.Tasks;

namespace codestuffers.MvvmCross.UserInteraction.Core
{
    public interface IMvxUserInteraction
    {
        void Alert(string message);

        void WithProgressBar<T>(Task<T> task, Action<Task<T>> onCompletion);
    }
}
