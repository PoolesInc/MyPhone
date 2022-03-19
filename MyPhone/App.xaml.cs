﻿using CommunityToolkit.Mvvm.DependencyInjection;
using GoodTimeStudio.MyPhone.RootPages.OOBE;
using GoodTimeStudio.MyPhone.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GoodTimeStudio.MyPhone
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Window m_window;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // Register services
            Ioc.Default.ConfigureServices(new ServiceCollection()
                .AddSingleton<ISettingsService, SettingsService>()
                .AddSingleton<IDeviceService, DeviceService>()
                .AddSingleton<IAppDispatcherService, AppDispatcherService>()
                .AddTransient<IDevicePairDialogService, DevicePairDialogService>()
                .AddTransient<OobePageViewModel>()
                .BuildServiceProvider());

            m_window = new MainWindow();
            m_window.Activate();
        }

        

        

    }
}
