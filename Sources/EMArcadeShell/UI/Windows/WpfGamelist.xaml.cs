using System;
using System.ComponentModel; 
using System.IO;
using System.Windows; 
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace EMArcadeShell.UI
{
	public partial class WpfGamelist : Window
	{
		public NotifyIcon Ni = new NotifyIcon();

		public WpfGamelist()
		{
			InitializeComponent();
			PlayBanner();

			try
			{
				Ni.Icon = (Properties.Resources.fav);
				//Ni.Icon = new Icon(Directory.GetCurrentDirectory() + "\\CONTENT\\IMG\\" + "fav.ico");
			}
			catch (Exception exxs)
			{
				Console.WriteLine(exxs.ToString());
			}
			Ni.Visible = true;
			Ni.DoubleClick +=
				delegate
				{
					if (WindowState == WindowState.Normal) return;
					Topmost = true;
					Show(); //Показываем
					WindowState = WindowState.Normal; //Вместо триггера.
					PlayMusic();
				};
		}

		private void PlayMusic()
		{
			try
			{
				var mp3Path = Directory.GetCurrentDirectory() + "\\CONTENT\\MP3\\";
				WpfMediaMp3Player.Source = new Uri(mp3Path + "NeverGonnaGiveYouUp.mp3");
				WpfMediaMp3Player.Play();

				#region RandomTrack

				//получить список файлов из xmpath (там их будет от 1 до 10).
				//выбрать случайный.
				//воспроизвести ниже.

				#endregion
			}
			catch (Exception exex)
			{
				Console.WriteLine(exex.ToString());
			}
		}

		private void StopMusic()
		{
			WpfMediaMp3Player.Stop();
		}

		private void PlayBanner()
		{
			WpfMediaElement.Source = new Uri((Directory.GetCurrentDirectory() + "\\CONTENT\\MEDIA\\promo_banner.mp4"));
			WpfMediaElement.Play();
		}

		private void WpfGameList(object sender, KeyEventArgs e)
		{
			#region DEBUG

			if (e.Key == Key.Escape)
			{
				Close();
			}
			if (e.Key == Key.LeftCtrl) //эмуляция события сворачивания по запуску игры.
			{
				StopMusic();
				Hide(); //Прячем с глаз долой.
				WindowState = WindowState.Minimized; //Вместо триггера.
				Topmost = false;
			
            }

			#endregion
		}

 
		private void WpfGamelist_Loaded(object sender, RoutedEventArgs e)
		{
			PlayMusic();
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			Ni.Icon = null; //иконок на таскбаре нема
			StopMusic(); //Останавливаем музыку. На всякий
		}

		private void WpfMediaElement_Ended(object sender, RoutedEventArgs e)
		{
			PlayBanner();
		}
	}
}