using Caliburn.Micro;

using HackerNews.ApiClient;
using HackerNews.Data;

using Microsoft.Xaml.Behaviors.Core;

using System.Linq;
using System.Windows.Input;

namespace HackerNews.ViewModels
{
	public class StoriesViewModel : BindableCollection<Story>
	{
		public bool IsBusy { get; set; } = false;

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
				using (var apiReq = new ApiRequest())
				{
					var ids = await storiesRepository.BestStoriesIDs();
					foreach (var id in ids)
					{
						var story = await apiReq.GetItemAsync<Story>($"item/{id}.json");
						this.Add(story);
					}
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
	}
}
