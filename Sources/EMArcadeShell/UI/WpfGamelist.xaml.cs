using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Input;
using minifmod4net;

namespace EMArcadeShell.UI
{ 
	public partial class WpfGamelist : Window
	{
		readonly Thread _thread = new Thread(PlayMusic); //знаю, палкой бить.
		public WpfGamelist()
		{ 
			InitializeComponent();
			GameListBox.SelectedIndex = 0;
			GameListBox.Focus(); 
		}

		private static void PlayMusic()
		{
			try
			{
				var xmpath = Directory.GetCurrentDirectory() + "\\CONTENT\\XM\\";
                var registry = new MiniFmodModuleRegistry();

				#region RandomTrack
				//получить список файлов из xmpath (там их будет от 1 до 10).
				//выбрать случайный.
				//воспроизвести ниже.
				#endregion

				var bytes = File.ReadAllBytes(xmpath + "\\test.xm");
				var module = registry.LoadFromMemory(1, bytes);
				module.Play();
				while (true) ;


			}
			catch (Exception exex)
			{
				Console.WriteLine(exex);
			}
		}

		private  void StopMusic()
		{
			_thread.Abort();//прерываем поток
			_thread.Join(500);//таймаут на завершение

		}
		 
		private void WpfGameList(object sender, KeyEventArgs e)
		{ 
			if (e.Key == Key.Escape)
			{
				Close();
			}
			if (e.Key == Key.LeftCtrl)
			{
				StopMusic();
				WindowState = WindowState.Minimized; //эмуляция события сворачивания по запуску игры.
				
			}
			
			//	AdjustWindowSize(); //эмуляция развертывания после закрытия эмуля
			
		}

		private void GameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void WpfGamelist_Loaded(object sender, RoutedEventArgs e)
		{
			_thread.Start();

		}

		private void AdjustWindowSize()
		{

			if (WindowState == WindowState.Minimized)
			{
				WindowState = WindowState.Normal;
				_thread.Start();
			}
			else
			{
				WindowState = WindowState.Minimized;
				StopMusic();
			}
		}


		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			StopMusic();
		}
	}
}
