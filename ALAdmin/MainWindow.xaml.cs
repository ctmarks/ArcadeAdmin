using ALAdmin.Models;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.Win32;
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

namespace ALAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Game> GameList = new ObservableCollection<Game>();

        private string txtPath = @"C: \Users\cmarks\Desktop\SingleGame.txt";

        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists(txtPath))
            {
                SaveList();
            }
            else
            {
                LoadList();
            }

            GamesListBox.ItemsSource = GameList;
        }

        private void AddGame_Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Game Name Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);               
            }
            else if (String.IsNullOrEmpty(exeTextBlock.Text))
            {
                MessageBox.Show("Game .exe File Path Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(VideoTextBlock.Text))
            {
                MessageBox.Show("Game Video File Path Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //else if (String.IsNullOrEmpty(LogoTextBlock.Text))
            //{
            //    MessageBox.Show("Game Logo File Path Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            else
            {
                Game g = new Game
                {
                    Name = NameTextBox.Text,
                    ExePath = exeTextBlock.Text,
                    VideoPath = VideoTextBlock.Text,
                    //LogoPath = LogoTextBlock.Text
                    Blurb = BlurbTextBlock.Text
                };

                GameList.Add(g);

                NameTextBox.Clear();
                exeTextBlock.Text = string.Empty;
                VideoTextBlock.Text = string.Empty;
                //LogoTextBlock.Text = string.Empty;
                BlurbTextBlock.Clear();

                SaveList();
            }
        }

        private void RemoveGame_Button_Click(object sender, RoutedEventArgs e)
        {
            GameList.Remove((Game)GamesListBox.SelectedItem);
            SaveList();
        }

        private void SaveList()
        {
            StreamWriter streamWriter = File.CreateText(txtPath);

            foreach(Game g in GameList)
            {
                streamWriter.WriteLine(g.Name);
                streamWriter.WriteLine(g.ExePath);
                streamWriter.WriteLine(g.VideoPath);
                //streamWriter.WriteLine(g.LogoPath);
                streamWriter.WriteLine(g.Blurb);
            }
            streamWriter.Close();
        }

        private void LoadList()
        {
            StreamReader streamReader = File.OpenText(txtPath);

            GameList.Clear();

            while (!streamReader.EndOfStream)
            {
                Game g = new Game();
                g.Name = streamReader.ReadLine();
                g.ExePath = streamReader.ReadLine();
                g.VideoPath = streamReader.ReadLine();
                //g.LogoPath = streamReader.ReadLine();
                g.Blurb = streamReader.ReadLine();

                GameList.Add(g);
            }
            streamReader.Close();
        }

        private void exeFileBrowse_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "exe files (*.exe)|*.exe";
            if (ofd.ShowDialog() == true)
                exeTextBlock.Text = ofd.FileName;
        }

        private void VideoBrowseFile_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "video files (*.mp4)|*.mp4";
            if (ofd.ShowDialog() == true)
                VideoTextBlock.Text = ofd.FileName;
        }

        //private void LogoFileBrowse_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "image files (*.jpg)|*.jpg";
        //    if (ofd.ShowDialog() == true)
        //        LogoTextBlock.Text = ofd.FileName;
        //}
    }
}
