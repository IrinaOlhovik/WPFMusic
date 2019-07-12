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
    /// Interaction logic for SongUserControl.xaml
    /// </summary>
    public partial class SongUserControl : UserControl
    {
        private readonly SongViewModel model;
        public MainWindow.ChangeUSEvent changeUS = null;
        public SongUserControl()
        {
            model = new SongViewModel();
            this.DataContext = model;
            InitializeComponent();
        }
        public void UpdateSongs()
        {
            model.LoadSongs();
        }
        internal void SetChangeEvent(MainWindow.ChangeUSEvent changeUS)
        {
            this.changeUS = changeUS;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changeUS?.Invoke(false);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in model.Tracks)
            {
                item.IsSelected = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in model.Tracks)
            {
                item.IsSelected = false;
            }
        }
    }
}
