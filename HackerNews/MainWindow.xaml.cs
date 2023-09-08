﻿using HackerNews.ApiClient;
using HackerNews.Data;
using HackerNews.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HackerNews
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			DataContext = new MainViewModel();

			InitializeComponent();
		}

		//public List<Story> Stories { get; private set; }

		//private void Button_Click(object sender, RoutedEventArgs e)
		//{
		//	var storiesRepository = new BestStoriesRepository();
		//	var stories = storiesRepository.GetBestStories().GetAwaiter().GetResult();
		//}
	}
}