using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMusicProgram.Model;

namespace WPFMusicProgram.ViewModel
{
    class SongViewModel : BindableBase
    {
        private ObservableCollection<Track> _tracks;
                
        public ObservableCollection<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; RaisePropertyChanged("Tracks"); }
        }
        
        public SongViewModel()
        {
            LoadSongs();
        }

        public void LoadSongs()
        {
            Tracks = new ObservableCollection<Track>();
            foreach (var p in MainClassWithLists.SelectedPlaylistTracks)
            {
                Tracks.Add(p);
            }
        }
    }
}
