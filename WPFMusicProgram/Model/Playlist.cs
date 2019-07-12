using System;
using System.Collections.Generic;
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
        private string _playlistName;

        public string PlaylistName
        {
            get { return _playlistName; }
            set { _playlistName = value; RaisePropertyChanged("PlaylistName"); }
        }
        private List<Track> _tracks;


        public List<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; RaisePropertyChanged("Tracks"); }
        }

    }
}
