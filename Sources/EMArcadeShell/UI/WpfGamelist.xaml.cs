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
using System.Windows.Shapes;

namespace EMArcadeShell.UI
{
	/// <summary>
	/// Interaction logic for WpfGamelist.xaml
	/// </summary>
	public partial class WpfGamelist : Window
	{
		public WpfGamelist()
		{
			InitializeComponent();
			GameListBox.SelectedIndex = 0;
			GameListBox.Focus();
		}

		private void WpfGameList(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				Close();
			}
		}

		private void GameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
				// Добавлять к имени стрелки > и <
		}

	
	}
}
