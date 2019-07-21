using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using WPFMusicProgram.Model;

namespace WPFMusicProgram.ViewModel
{
    public class PlaylistViewModel : BindableBase
    {
        public ObservableCollection<Playlist> Playlists{ get; set; }
        private Visibility _spinningModalVisibility;

        public Visibility SpinningModalVisibility
        {
            get { return _spinningModalVisibility; }
            set { _spinningModalVisibility = value; RaisePropertyChanged("SpinningModalVisibility"); }
        }
        

        public PlaylistViewModel()
        {
            LoadPlaylists();
        }

        public void LoadPlaylists()
        {
            Parse.ParseGoogle();

            Playlists = new ObservableCollection<Playlist>();
            foreach(var p in MainClassWithLists.Playlists)
            {
                Playlists.Add(p);
            }
        }
    }
}
