using Cirrious.CrossCore.IoC;
using codestuffers.MvvmCross.Plugins.FeedbackDialog.Examples.ViewModels;

namespace codestuffers.MvvmCross.Plugins.FeedbackDialog.Examples
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<FirstViewModel>();
        }
    }
}