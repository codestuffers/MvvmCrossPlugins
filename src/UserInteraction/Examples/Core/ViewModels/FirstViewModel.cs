using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace codestuffers.MvvmCrossPlugins.UserInteraction.Examples.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxUserInteraction _userInteraction;
        private string _alertMessage = "Test dialog body";
        private int _progressDuration = 1000;
        private bool _isProgressCommandEnabled = true;
        private string _alertTitle = "Test Title";

        public FirstViewModel(IMvxUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public ICommand ShowAlertCommand { get { return new MvxCommand(ShowAlert); } }
        public ICommand ShowAlertWithTitleCommand { get { return new MvxCommand(ShowAlertWithTitle); } }
        public ICommand ShowProgressCommand { get { return new MvxCommand(ShowProgress); } }
        public ICommand ShowDialogCommand { get {  return new MvxCommand(ShowDialog);} }

        public string AlertMessage
        {
            get { return _alertMessage; }
            set { _alertMessage = value; RaisePropertyChanged(() => AlertMessage); }
        }

        public string AlertTitle
        {
            get { return _alertTitle; }
            set { _alertTitle = value; RaisePropertyChanged(() => AlertTitle); }
        }

        public int ProgressDuration
        {
            get { return _progressDuration; }
            set { _progressDuration = value; RaisePropertyChanged(() => ProgressDuration); }
        }

        public bool IsProgressCommandEnabled
        {
            get { return _isProgressCommandEnabled; }
            set { _isProgressCommandEnabled = value; RaisePropertyChanged(() => IsProgressCommandEnabled); }
        }

        private void ShowAlert()
        {
            _userInteraction.Alert(AlertMessage);
        }

        private void ShowAlertWithTitle()
        {
            _userInteraction.Alert(AlertMessage, AlertTitle);
        }

        private void ShowDialog()
        {
            _userInteraction.ShowDialog(AlertTitle, AlertMessage, "Left", "Right",
                () => _userInteraction.Alert("You chose left"), () => _userInteraction.Alert("You chose right"));
        }

        private void ShowProgress()
        {
            _userInteraction.WithProgressBar(Task.Factory.StartNew<int>(ActBusy), task => IsProgressCommandEnabled = true);
        }

        private int ActBusy()
        {
            IsProgressCommandEnabled = false;
            var endTime = DateTime.Now.AddMilliseconds(ProgressDuration);

            while (DateTime.Now < endTime)
            {
                // Do nothing...
            }

            return 0;
        }
    }
}
