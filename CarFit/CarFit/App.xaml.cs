using CarFit.Services;
using Prism;
using Prism.Ioc;
using CarFit.ViewModels;
using CarFit.Views;
using DryIoc;
using Prism.DryIoc;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CarFit
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        private static IContainer ioCContainer;
        public static IContainer IoCContainer
        {
            get => ioCContainer;
            private set => ioCContainer = value;
        }

        private static IContainerRegistry iocRegistry;
        public static IContainerRegistry IoCRegistry
        {
            get => iocRegistry;
            private set => iocRegistry = value;
        }

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            App.IoCContainer = containerRegistry.GetContainer();
            App.IoCRegistry = containerRegistry;

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            RegisterAllServiceType(containerRegistry);

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        private void RegisterAllServiceType(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Services.ICarWashService, Services.CarWashService>();
            containerRegistry.Register<Services.ICommonService, Services.CommonService>();

            containerRegistry.Register<ViewModels.ICleaningListViewModel, ViewModels.CleaningListViewModel>();

            containerRegistry.Register<Views.ICleaningList,Views.CleaningList>();
        }


    }
}
