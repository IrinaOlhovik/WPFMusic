using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMusicProgram.Model
{
    public class Track : ItemBase
    {
        public string Id { get; set; }
        public string ArtistId { get; set; }
        public string TrackName { get; set; }
        public string AlbumId { get; set; }
        public string Duration { get; set; }
    }
}
