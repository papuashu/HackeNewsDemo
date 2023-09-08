using HackerNews.Data;

using System;
using System.Collections.Generic;
using System.Linq;
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
			using (var req = new ApiRequest(BaseUriStr))
			{
				return await req.GetListAsync<int>("beststories.json");
			}
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
