namespace HackerNews.Data
{
	public class Story
	{
		public int id { get; set; }
		public string type { get; set; }
		public string title { get; set; }
		public long time { get; set; }
		public string url { get; set; }
		public string by { get; set; }
		public int score { get; set; }
	}
}
