using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MQTTnet.App.Common;
using MQTTnet.App.Main;
using MQTTnet.App.Services.Client;
using SimpleInjector;

namespace MQTTnet.App
{
    public sealed class App : Application
    {
        readonly Container _container;

        static Window _mainWindow;

        public App()
        {
            _container = new Container();
            _container.Options.ResolveUnregisteredConcreteTypes = true;
            _container.RegisterSingleton<MqttClientService>();

            var viewLocator = new ViewLocator(_container);
            DataTemplates.Add(viewLocator);
        }

        public static void ShowDialog(BaseViewModel content)
        {
            var host = new Window
            {
                Title = "Message",
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                SizeToContent = SizeToContent.WidthAndHeight,
                ShowInTaskbar = false,
                ShowActivated = true,
                Content = content
            };

            host.ShowDialog(_mainWindow);
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                _mainWindow = new MainWindowView
                {
                    DataContext = _container.GetInstance<MainWindowViewModel>()
                };

                desktop.MainWindow = _mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
