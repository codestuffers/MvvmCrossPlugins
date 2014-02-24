using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using codestuffers.MvvmCrossPlugins.UserInteraction.Examples.Core.ViewModels;

namespace Examples.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;
			   
            //var label = new UILabel(new RectangleF(10, 10, 300, 40));
            //Add(label);
            var alertMessage = new UITextField(new RectangleF(10, 10, 300, 40));
            Add(alertMessage);

            var alertTitle = new UITextField(LocationBelowView(10, 300, 40, alertMessage));
            Add(alertTitle);

            var progressDuration = new UITextField(LocationBelowView(10, 300, 40, alertTitle));
            Add(progressDuration);

            var showAlert = new UIButton(UIButtonType.RoundedRect);
            showAlert.Frame = LocationBelowView(10, 300, 40, progressDuration);
            showAlert.SetTitle("Show Alert", UIControlState.Normal);
            Add(showAlert);

            var showAlertWithTitle = new UIButton(UIButtonType.RoundedRect);
            showAlertWithTitle.Frame = LocationBelowView(10, 300, 40, showAlert);
            showAlertWithTitle.SetTitle("Show Alert With Title", UIControlState.Normal);
            Add(showAlertWithTitle);

            var showProgress = new UIButton(UIButtonType.RoundedRect);
            showProgress.Frame = LocationBelowView(10, 300, 40, showAlertWithTitle);
            showProgress.SetTitle("Show Progress", UIControlState.Normal);
            Add(showProgress);

            var showDialog = new UIButton(UIButtonType.RoundedRect);
            showDialog.Frame = LocationBelowView(10, 300, 40, showProgress);
            showDialog.SetTitle("Show Dialog", UIControlState.Normal);
            Add(showDialog);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(alertMessage).To(vm => vm.AlertMessage).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.TwoWay);
            set.Bind(alertTitle).To(vm => vm.AlertTitle).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.TwoWay);
            set.Bind(progressDuration).To(vm => vm.ProgressDuration).Mode(Cirrious.MvvmCross.Binding.MvxBindingMode.TwoWay);
            set.Bind(showAlert).To(vm => vm.ShowAlertCommand);
            set.Bind(showAlertWithTitle).To(vm => vm.ShowAlertWithTitleCommand);
            set.Bind(showProgress).To(vm => vm.ShowProgressCommand);
            set.Bind(showProgress).For(x => x.Enabled).To(vm => vm.IsProgressCommandEnabled);
            set.Bind(showDialog).To(vm => vm.ShowDialogCommand);
            set.Apply();
        }

        private RectangleF LocationBelowView(int x, int width, int height, UIView viewAbove)
        {
            return new RectangleF(x, viewAbove.Frame.Bottom + 4, width, height);
        }
    }
}