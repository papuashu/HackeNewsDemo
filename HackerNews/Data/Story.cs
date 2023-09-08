using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.Data
{
	public class Story
	{
		//[JsonProperty("id")]
		public int id { get; set; }
		//[JsonProperty("type")]
		public string type { get; set; } //= "story";
		public string title { get; set; }
		public long time { get; set; }
		public string url { get; set; }
		public string by { get; set; }
		public int score { get; set; }
	}
}
