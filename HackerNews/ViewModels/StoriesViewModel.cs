using Caliburn.Micro;

using HackerNews.ApiClient;
using HackerNews.Data;

using Microsoft.Xaml.Behaviors.Core;

using PropertyChanged;

using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace HackerNews.ViewModels
{
	public class StoriesViewModel : BindableCollection<Story>
	{
		public StoriesViewModel()
		{
			RefreshCommand = new ActionCommand(OnRefresh);
		}

		public bool IsBusy { get; set; } = false;

		public int TotalToFetch { get; protected set; } = 0;

		[DependsOn(nameof(Count))]
		public int FetchCount => Count;

		[DependsOn(nameof(FetchCount))]
		public int ProgressRatio { get => TotalToFetch == 0 ? 0 : FetchCount * 100 / TotalToFetch; set { } }

		[DependsOn(nameof(ProgressRatio))]
		public string ProgressRatioStr => $"{ProgressRatio}%";

		public ICommand RefreshCommand { get; private set; }

		public ICommand OpenUrlCommand { get; set; } = new ActionCommand(OpenUrl);

		public async void OnRefresh()
		{
			IsBusy = true;
			this.Clear();

			try
			{
				var storiesRepository = new BestStoriesRepository();

				//variant: for short list, get all items and display when done
				//var stories = await storiesRepository.GetBestStories();
				//this.AddRange(stories.OrderBy(s => s.time));

				//variant: for long / slow connections, but no ordering by Date Time
				var ids = await storiesRepository.BestStoriesIDs();
				if (ids == null || ids.Count == 0)
				{
					return;
				}

				TotalToFetch = ids.Count;

				foreach (var id in ids)
				{
					var story = await storiesRepository.GetStory(id);
					this.Add(story);
				}
			}
			catch { //TODO
			}
			finally
			{
				IsBusy = false;
			}
		}

		public static void OpenUrl(object urlObj)
		{
			if (urlObj is string urlStr)
			{
				var sInfo = new System.Diagnostics.ProcessStartInfo(urlStr)
				{
					UseShellExecute = true,
				};
				System.Diagnostics.Process.Start(sInfo);
			}
		}

		protected override void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);

			if (e.PropertyName == nameof(Count))
			{
				NotifyOfPropertyChange(nameof(FetchCount));
				NotifyOfPropertyChange(nameof(ProgressRatio));
				NotifyOfPropertyChange(nameof(ProgressRatioStr));
			}
		}
	}
}
