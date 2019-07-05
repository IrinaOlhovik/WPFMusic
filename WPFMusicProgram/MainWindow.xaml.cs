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
using WPFMusicProgram.Model;
using WPFMusicProgram.View;
using WPFMusicProgram.ViewModel;

namespace WPFMusicProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Parse.ParseGoogle();
           // List.ItemsSource = MainClassWithLists.Playlists.Select(p => string.Format("{0},{1},{2}",p.Id, p.PlaylistName,p.Tracks.Count));
        }

        //private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
     
        //}
        //public void ListItemSource(string id)
        //{
        //    var playlist = MainClassWithLists.Playlists.SingleOrDefault(p => p.Id == id);
        //    if(playlist!=null)
        //    List.ItemsSource = playlist.Tracks
        //        .Select(t => string.Format("{0},{1},{2}", t.Id, t.TrackName, t.Duration));
        //}

        //private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    ListItemSource(List.SelectedItem.ToString().Split(',')[0]);
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    List.ItemsSource = MainClassWithLists.Playlists.Select(p => string.Format("{0},{1},{2}", p.Id, p.PlaylistName, p.Tracks.Count));
        //}
        private void PlaylistView_Loaded(object sender, RoutedEventArgs e)
        {
            PlaylistViewModel playlistViewModel =
               new PlaylistViewModel();
            playlistViewModel.LoadPlaylists();

            PlaylistUserControl.DataContext = playlistViewModel;
        }

    }
}
