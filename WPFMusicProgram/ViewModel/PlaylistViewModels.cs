using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using WPFMusicProgram.Model;

namespace WPFMusicProgram.ViewModel
{
   public class PlaylistViewModel
    {
        public ObservableCollection<Playlist> Playlists{ get; set; }
        public void LoadPlaylists()
        {
            Parse.ParseGoogle();
            Playlists = MainClassWithLists.Playlists;
        }
    }
}
