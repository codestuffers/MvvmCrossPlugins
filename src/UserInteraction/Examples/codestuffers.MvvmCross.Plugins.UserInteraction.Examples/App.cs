using Cirrious.CrossCore.IoC;
using codestuffers.MvvmCross.Plugins.UserInteraction.Examples.ViewModels;

namespace codestuffers.MvvmCross.Plugins.UserInteraction.Examples
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