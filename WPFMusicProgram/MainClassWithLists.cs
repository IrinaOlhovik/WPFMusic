using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMusicProgram.Model;

namespace WPFMusicProgram
{
    public static class MainClassWithLists
    {
        public static List<Album> Albums = new List<Album>();
        public static List<Artist> Artists = new List<Artist>();
        public static List<Track> Tracks = new List<Track>();
        public static ObservableCollection<Playlist> Playlists = new ObservableCollection<Playlist>();
    }
}
