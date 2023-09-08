using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HackerNews.Converters
{
	public class Bool2VisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool boolvalue)
			{
				return boolvalue ? Visibility.Visible : Visibility.Hidden;
			}
			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
