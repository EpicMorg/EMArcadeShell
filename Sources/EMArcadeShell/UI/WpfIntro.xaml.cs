using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EMArcadeShell.UI
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class WpfIntro : Window
	{
		public WpfIntro()
		{
			InitializeComponent();
		}

		private void WpfIntro_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				WpfMediaElement.Source = new Uri(Directory.GetCurrentDirectory()+ "\\MEDIA\\epicmorg_logo.mp4");
				WpfMediaElement.Play();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				NextStep();
			}
		}

		private void MediaElement_Ended(object sender, RoutedEventArgs e)
		{
			NextStep();
		}

		private void NextStep()
		{

			WpfMediaElement.Source = null;
			var gamelist = new WpfGamelist();
			gamelist.Show();
			Close();
		}

		private void WpfIntro_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				Close(); 
			}
		}
	}
}
