using System;
using System.Windows;
using TabStudents.Repository;
using TabStudents.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace TabStudents
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App) Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<StudentsRepository, StudentsRepository>();
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }

        public MainViewModel MainVM => Services.GetService<MainViewModel>();
    }
}