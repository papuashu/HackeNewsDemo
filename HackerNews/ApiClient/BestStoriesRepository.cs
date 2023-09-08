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
		internal async Task<List<int>> BestStoriesIDs()
		{
			var ids = await new ApiRequest().GetListAsync<int>("beststories.json");
			return ids;
		}

		internal async Task<List<Story>> GetBestStories()
		{
			var ids = await BestStoriesIDs();
			var bestStoriesList = new List<Story>();
			var apiReq = new ApiRequest();
			foreach (var id in ids)
			{
				var story = await apiReq.GetItemAsync<Story>($"item/{id}.json");
				bestStoriesList.Add(story);
			}
			return bestStoriesList;
		}
	}
}
