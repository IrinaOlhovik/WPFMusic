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
using WPFMusicProgram.ViewModel;

namespace WPFMusicProgram.View
{
    /// <summary>   
    /// Interaction logic for PlaylistUserControl.xaml
    /// </summary>
    public partial class PlaylistUserControl : UserControl
    {
        private readonly PlaylistViewModel model = new PlaylistViewModel();
        public MainWindow.ChangeUSEvent changeUS = null;
        public PlaylistUserControl()
        {
            Parse.ParseGoogle();
            this.DataContext = model;
            
            InitializeComponent();
        }

        internal void SetChangeEvent(MainWindow.ChangeUSEvent changeUS)
        {
            this.changeUS = changeUS;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Parse.UpdateSelectedPlaylist((Playlist)ListBoxPlaylist.SelectedItem);
            changeUS?.Invoke(true);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in model.Playlists)
            {
                item.IsSelected = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in model.Playlists)
            {
                item.IsSelected = false;
            }
        }
    }
}
