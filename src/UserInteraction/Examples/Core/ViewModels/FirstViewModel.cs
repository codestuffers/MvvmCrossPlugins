using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using codestuffers.MvvmCross.UserInteraction.Core;

namespace codestuffers.MvvmCrossPlugins.UserInteraction.Examples.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxUserInteraction _userInteraction;
        private string _alertMessage = "Alert test";
        private int _progressDuration = 1000;
        private bool _isProgressCommandEnabled = true;

        public FirstViewModel(IMvxUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public ICommand ShowAlertCommand { get { return new MvxCommand(ShowAlert); } }
        public ICommand ShowProgressCommand { get { return new MvxCommand(ShowProgress); } }

        public string AlertMessage
        {
            get { return _alertMessage; }
            set { _alertMessage = value; RaisePropertyChanged(() => AlertMessage); }
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

        private void ShowProgress()
        {
            _userInteraction.WithProgressBar(Task.Factory.StartNew<int>(ActBusy), task => IsProgressCommandEnabled = true)
            ;
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
