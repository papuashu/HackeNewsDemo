using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.ApiClient
{
	internal class ApiRequest : IDisposable
	{
		private bool disposedValue;

		internal ApiRequest(string baseUri)
		{
			if (string.IsNullOrEmpty(baseUri))
				throw new ArgumentNullException(nameof(baseUri));

			BaseUri = new Uri(baseUri);

			ApiClient = new HttpClient() { BaseAddress = BaseUri };
			ApiClient.DefaultRequestHeaders.Accept.Clear();
			ApiClient.DefaultRequestHeaders.Accept.Add(
				 new MediaTypeWithQualityHeaderValue("application/json"));

		}

		internal Uri BaseUri { get; set; }
		internal HttpClient ApiClient { get; set; }

		internal async Task<List<TItem>> GetListAsync<TItem>(string path)
		{
			List<TItem> items = null;
			HttpResponseMessage response = await ApiClient.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				items = await response.Content.ReadAsAsync<List<TItem>>();
			}
			return items;
		}

		internal async Task<TItem> GetItemAsync<TItem>(string path)
			where TItem : class
		{
			TItem item = null;
			HttpResponseMessage response = await ApiClient.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				item = await response.Content.ReadAsAsync<TItem>();
			}
			return item;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					var x = ApiClient;
					ApiClient = null;
					x?.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~ApiRequest()
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
