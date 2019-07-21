using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMusicProgram.Model
{
    public class Album : ItemBase
    {
        public string AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string ArtistId { get; set; }
        public ObservableCollection<Track> Tracks{ get; set; }
        public HtmlNodeCollection htmlSongs { get; set; }
    }
}
