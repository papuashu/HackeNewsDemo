using Caliburn.Micro;

using HackerNews.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HackerNews
{
	public class AppBootstrapper : BootstrapperBase
	{
		public AppBootstrapper()
		{
			Initialize();
		}

		private SimpleContainer container;

		protected override void Configure()
		{
			container = new SimpleContainer();

			container.Singleton<IWindowManager, WindowManager>();
			container.Singleton<IEventAggregator, EventAggregator>();

			container.PerRequest<ShellViewModel>();
		}

		protected override object GetInstance(Type service, string key)
		{
			return container.GetInstance(service, key);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			container.BuildUp(instance);
		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewForAsync<ShellViewModel>();
		}

		protected override IEnumerable<Assembly> SelectAssemblies()
		{
			return new[] { Assembly.GetExecutingAssembly() };
		}
	}
}
