using System.Windows.Controls;

namespace EMArcadeShell.UI.Pages
{
	/// <summary>
	/// Interaction logic for SelectGame.xaml
	/// </summary>
	public partial class SelectGame : Page
	{
		public SelectGame()
		{
			InitializeComponent();
			GameListBox.SelectedIndex = 0;
			GameListBox.Focus();
		}
	}
}
