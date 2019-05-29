using System;
using CardAlignment.Helpers;
using CardAlignment.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace CardAlignment
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();
            this.RequiresPointerMode = ApplicationRequiresPointerMode.WhenRequested;

            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (DeviceTypeHelper.GetDeviceFormFactorType() == DeviceFormFactorType.Xbox)
                SettingsForXbox();

            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        private void SettingsForXbox()
        {
            //https://docs.microsoft.com/zh-cn/windows/uwp/xbox-apps/tailoring-for-xbox

            //Full Screen Mode
            var view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();

            //Reveal focus gives users a better understanding of where focus is and where focus is going.
            this.FocusVisualKind = FocusVisualKind.Reveal;

            //Disable Xbox 200% scale
            var result = ApplicationViewScaling.TrySetDisableLayoutScaling(true);

            //Remove Xbox TV safe areas
            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);

            //Use TV colorsafe values
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("ms-appx:///Styles/TvSafeColors.xaml")
            });
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.MainPage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
