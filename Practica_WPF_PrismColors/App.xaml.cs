using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace Practica_WPF_PrismColors
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        IUnityContainer _container;
        protected override Window CreateShell()
        {
            return _container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _container = containerRegistry.GetContainer();
        }

    }
}
