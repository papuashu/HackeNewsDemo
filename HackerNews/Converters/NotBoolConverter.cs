using System;
using System.Globalization;
using System.Windows.Data;

namespace HackerNews.Converters
{
	public class NotBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool boolvalue)
			{
				return !boolvalue;
			}
			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Convert(value, targetType, parameter, culture);
		}
	}
}
