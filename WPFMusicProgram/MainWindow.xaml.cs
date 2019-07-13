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
        public delegate void ChangeUSEvent(bool Show);
        public delegate void ChangeUSEventAlbum(bool Show);
        public MainWindow()
        {
            InitializeComponent();
            playlistUserControl.SetChangeEvent(ChangeUS);
            songUserControl.SetChangeEvent(ChangeUS);
            albumUserControl.SetChangeEvent(ChangeUS, ChangeUSAlbum);

        }
        public void ChangeUS(bool Show)
        {
            songUserControl.UpdateSongs();
            if (songUserControl.CountOfSongs() > 0)
            {
                songUserControl.Visibility = Show ? Visibility.Visible : Visibility.Hidden;
                playlistUserControl.Visibility = Show ? Visibility.Hidden : Visibility.Visible;
            }
            else
            {
                albumUserControl.UpdateAlbums();
                albumUserControl.Visibility = Show ? Visibility.Visible : Visibility.Hidden;
                playlistUserControl.Visibility = Show ? Visibility.Hidden : Visibility.Visible;
            }
        }
        public void ChangeUSAlbum(bool Show)
        {
            songUserControl.UpdateSongs();
            songUserControl.Visibility = Show ? Visibility.Visible : Visibility.Hidden;
            albumUserControl.Visibility = Show ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
