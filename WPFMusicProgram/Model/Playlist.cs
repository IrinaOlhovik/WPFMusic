using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMusicProgram.Model
{
    public class Playlist : ItemBase
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("Id"); }
        }
        private string _href;

        public string Href
        {
            get { return _href; }
            set { _href = value; RaisePropertyChanged("Href"); }
        }
        private string _playlistName;

        public string PlaylistName
        {
            get { return _playlistName; }
            set { _playlistName = value; RaisePropertyChanged("PlaylistName"); }
        }
        private ObservableCollection<Track> _tracks;


        public ObservableCollection<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; RaisePropertyChanged("Tracks"); }
        }
        public int Count
        {
            get
            {
                return (Tracks.Count > 0) ? Tracks.Count : Albums.Count;
            }
        }
        private ObservableCollection<Album> _albums;
        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set { _albums = value; RaisePropertyChanged("Albums"); }
        }


    }
}
