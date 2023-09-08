using HackerNews.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.ApiClient
{
	internal class BestStoriesRepository
	{
		//TODO: set it in app.config; not hardcoded
		//TODO: similarly for endpoints
		internal const string BaseUriStr = "https://hacker-news.firebaseio.com/v0/";


		internal async Task<List<int>> BestStoriesIDs()
		{
			var ids = await new ApiRequest(BaseUriStr).GetListAsync<int>("beststories.json");
			return ids;
		}

		internal async Task<List<Story>> GetBestStories()
		{
			var ids = await BestStoriesIDs();
			var bestStoriesList = new List<Story>();
			using (var apiReq = new ApiRequest(BaseUriStr))
			{
				foreach (var id in ids)
				{
					var story = await apiReq.GetItemAsync<Story>($"item/{id}.json");
					bestStoriesList.Add(story);
				}
			}
			return bestStoriesList;
		}
	}
}
