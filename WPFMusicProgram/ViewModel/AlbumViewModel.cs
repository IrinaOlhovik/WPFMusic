using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMusicProgram.Model;

namespace WPFMusicProgram.ViewModel
{
    class AlbumViewModel : BindableBase
    {
        private ObservableCollection<Album> _albums;

        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set { _albums = value; RaisePropertyChanged("Albums"); }
        }
        private Visibility _spinningModalVisibility;

        public Visibility SpinningModalVisibility
        {
            get { return _spinningModalVisibility; }
            set { _spinningModalVisibility = value; RaisePropertyChanged("SpinningModalVisibility"); }
        }
        public AlbumViewModel()
        {
            LoadAlbums();
        }

        public void LoadAlbums()
        {
            Albums = new ObservableCollection<Album>();
            foreach (var p in MainClassWithLists.SelectedPlaylistAlbums)
            {
                Albums.Add(p);
            }
        }
    }
}
