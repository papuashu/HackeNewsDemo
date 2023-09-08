using System;
using System.Globalization;
using System.Windows.Data;

namespace HackerNews.Converters
{
	public class Long2DateTimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is long longvalue)
			{
				return DateTimeOffset.FromUnixTimeSeconds(longvalue).DateTime.ToLocalTime().ToString("MM/dd/yyyy HH:mm");
			}
			return Binding.DoNothing;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
