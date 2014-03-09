using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.Examples.ViewModels;

namespace FeedbackDialog.Examples.Touch.Views
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
			   
            var simulateOpenButton = new UIButton(UIButtonType.RoundedRect) 
            { 
                Frame = new RectangleF(10, 10, 300, 40) 
            };
            simulateOpenButton.SetTitle("Simulate app start", UIControlState.Normal);
            Add(simulateOpenButton);

            var resetButton = new UIButton(UIButtonType.RoundedRect) 
            { 
                Frame = LocationBelowView(10, 300, 40, simulateOpenButton)
            };
            resetButton.SetTitle("Reset open count", UIControlState.Normal);
            Add(resetButton);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(simulateOpenButton).To(vm => vm.SimulateOpeningCommand);
            set.Bind(resetButton).To(vm => vm.ResetDataCommand);
            set.Apply();
        }

        private RectangleF LocationBelowView(int x, int width, int height, UIView viewAbove)
        {
            return new RectangleF(x, viewAbove.Frame.Bottom + 4, width, height);
        }
    }
}