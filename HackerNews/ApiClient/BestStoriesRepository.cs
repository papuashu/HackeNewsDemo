using HackerNews.Data;

using Api.Client.Wpf;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HackerNews.ApiClient
{
	internal class BestStoriesRepository : IDisposable
	{
		//TODO: set it in app.config; not hardcoded
		//TODO: similarly for endpoints
		internal const string BaseUriStr = "https://hacker-news.firebaseio.com/v0/";
		protected ApiRequest ApiClient {  get; set; } = new ApiRequest(BaseUriStr);

		private bool disposedValue;

		internal async Task<List<int>> BestStoriesIDs()
			=> await ApiClient.GetListAsync<int>("beststories.json");

		internal async Task<List<Story>> GetBestStories()
		{
			var ids = await BestStoriesIDs();
			var bestStoriesList = new List<Story>();

			foreach (var id in ids)
			{
				var story = await GetStory(id);
				bestStoriesList.Add(story);
			}

			return bestStoriesList;
		}

		internal async Task<Story> GetStory(int id)
			=> await ApiClient.GetItemAsync<Story>($"item/{id}.json");

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
					var x = ApiClient;
					ApiClient = null;
					x.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~BestStoriesRepository()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
