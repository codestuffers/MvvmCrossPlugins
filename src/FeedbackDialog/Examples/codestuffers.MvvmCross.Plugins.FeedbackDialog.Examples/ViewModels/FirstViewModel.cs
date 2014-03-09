using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using codestuffers.MvvmCross.Plugins.FeedbackDialog;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Examples.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxFeedbackDialog _feedbackDialog;

        public FirstViewModel(IMvxFeedbackDialog feedbackDialog)
        {
            _feedbackDialog = feedbackDialog;
        }

        public ICommand SimulateOpeningCommand { get { return new MvxCommand(SumulatOpeningAction); } }
        public ICommand ResetDataCommand { get { return new MvxCommand(ResetDataAction); } }

        private void ResetDataAction()
        {
            _feedbackDialog.ResetOpenCount();
        }

        private void SumulatOpeningAction()
        {
            _feedbackDialog.RecordAppStart();
        }
    }
}
