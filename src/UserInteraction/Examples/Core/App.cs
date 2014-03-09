using Cirrious.CrossCore.IoC;
using codestuffers.MvvmCross.Plugins.UserInteraction.Examples.Core.ViewModels;

namespace codestuffers.MvvmCross.Plugins.UserInteraction.Examples.Core
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