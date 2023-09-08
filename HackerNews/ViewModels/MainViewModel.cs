using Microsoft.Xaml.Behaviors.Core;

using PropertyChanged;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HackerNews.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class MainViewModel : Caliburn.Micro.PropertyChangedBase
	{
		public MainViewModel()
		{
			RefreshCommand = new ActionCommand(StoriesVM.OnRefresh);
			StoriesVM.CollectionChanged += StoriesVM_CollectionChanged;
		}

		public StoriesViewModel StoriesVM { get; private set; } = new StoriesViewModel();

		public int ItemsCount { get; private set; }

		public ICommand RefreshCommand { get; private set; }

		private void StoriesVM_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			ItemsCount = StoriesVM.Count;
		}
	}
}
