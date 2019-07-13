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
    /// Interaction logic for AlbumUserControl.xaml
    /// </summary>
    public partial class AlbumUserControl : UserControl
    {
        private readonly AlbumViewModel model;
        public MainWindow.ChangeUSEvent changeUS = null;
        public MainWindow.ChangeUSEventAlbum changeUSAlbum = null;
        public AlbumUserControl()
        {
            model = new AlbumViewModel();
            this.DataContext = model;
            InitializeComponent();
        }
        public void UpdateAlbums()
        {
            model.LoadAlbums();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Parse.UpdateSelectedAlbum((Album)ListBoxAlbums.SelectedItem);
            changeUSAlbum?.Invoke(true);
        }
        internal void SetChangeEvent(MainWindow.ChangeUSEvent changeUS, MainWindow.ChangeUSEventAlbum changeUSAlbum)
        {
            this.changeUS = changeUS;
            this.changeUSAlbum = changeUSAlbum;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changeUS?.Invoke(false);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in model.Albums)
            {
                item.IsSelected = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in model.Albums)
            {
                item.IsSelected = false;
            }
        }
    }
}
