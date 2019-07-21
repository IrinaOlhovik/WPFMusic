using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMusicProgram.Model;
using System.Net;
using HtmlAgilityPack;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.IO;

namespace WPFMusicProgram
{
    public class Parse
    {
        private static string rootUrl = @"https://play.google.com";
        private static string url = @"/store/music";
        //collection/cluster?clp=YhgKCHBsYXlsaXN0EAMaCgoIcGxheWxpc3Q%3D:S:ANO1ljJG2Xc&gsr=ChpiGAoIcGxheWxpc3QQAxoKCghwbGF5bGlzdA%3D%3D:S:ANO1ljLEfEM";
        public static string GetUrl(string address)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.Accept] = "text/html, */*";
            webClient.Headers[HttpRequestHeader.AcceptLanguage] = "ru-RU";
            webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded,  charset=utf-8";
            return webClient.DownloadString(address);
        }
        public static void ParseGoogle()
        {
            HtmlDocument htmlSnippet = new HtmlDocument();
            string result;
            while (true)
            {
                htmlSnippet = GetHtmlDocument(rootUrl + url);
                foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes(@"//div[@class='Ktdaqe  ']"))
                {
                    Playlist playlist = new Playlist()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Tracks = new ObservableCollection<Track>(),
                        Albums = new ObservableCollection<Album>()
                    };
                    playlist.PlaylistName = link.SelectSingleNode(@".//h2[@class='sv0AUd bs3Xnd']").InnerText;
                    HtmlNode htmlNode = link.SelectSingleNode(@".//div[@class='xwY9Zc']").FirstChild;
                    string href = htmlNode.GetAttributeValue("href", "");
                    playlist.Href = rootUrl + href;
                    //ParseGoogleAlbums(ref playlist, href);
                    MainClassWithLists.Playlists.Add(playlist);
                }
                break;
            }
        }

        public static void ParseGoogleSongs(ref Playlist list, string href)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            string result = GetUrl(href);
            htmlDocument.LoadHtml(result);
            Artist artist;
            Track track;
            foreach (HtmlNode song in htmlDocument.DocumentNode.SelectNodes(@"//div[@class='Vpfmgd']"))
            {
                string name = song.SelectSingleNode(@".//div[@class='WsMG1c nnK0zc']").InnerText;
                string artistName = song.SelectSingleNode(@".//a[@class='mnKHRc']").FirstChild.InnerText;
                string songPageHref = song.SelectSingleNode(@".//div[@class='b8cIId ReQCgd Q9MA7b']").FirstChild.GetAttributeValue("href", "");
                HtmlDocument htmlDocumentSong = new HtmlDocument();
                string resultSong = GetUrl(rootUrl + songPageHref);
                htmlDocumentSong.LoadHtml(resultSong);
                string duration = htmlDocumentSong.DocumentNode.SelectSingleNode(@"td[@class='KYddxf WAjGKd']").InnerText;
                artist = new Artist()
                {
                    ArtistId = Guid.NewGuid().ToString(),
                    ArtistName = artistName
                };
                track = new Track()
                {
                    Id = Guid.NewGuid().ToString(),
                    TrackName = name,
                    ArtistId = artist.ArtistId,
                    Duration = duration
                };
                MainClassWithLists.Artists.Add(artist);
                MainClassWithLists.Tracks.Add(track);
                list.Tracks.Add(track);
            }
        }
        public static void ParseGoogleAlbums(ref Playlist playlist, string href)
        {
            HtmlDocument htmlDocument = GetHtmlDocument(href);
            Artist artist; Album album; Track track;
            foreach (HtmlNode link in htmlDocument.DocumentNode.SelectNodes(@"//div[@class='card-content id-track-click id-track-impression']"))
            {
                string hrefAlbum = link.SelectSingleNode(@".//a[@class='card-click-target']").GetAttributeValue("href", "");
                HtmlDocument htmlSnippset = GetHtmlDocument(rootUrl + hrefAlbum);
                var htmlSongs = htmlSnippset.DocumentNode.SelectNodes(@"//tr[@class='KaLrad yZhPwb']");

                string artistName = htmlSnippset.DocumentNode.SelectSingleNode(@".//a[@class='hrTbp R8zArc']").InnerText;
                artist = new Artist
                {
                    ArtistId = Guid.NewGuid().ToString(),
                    ArtistName = artistName
                };
                MainClassWithLists.Artists.Add(artist);


                if (htmlSongs.Count > 1)
                {
                    string albummName = htmlSnippset.DocumentNode.SelectSingleNode(@".//h1[@class='AHFaub krcQId']").FirstChild.InnerText;
                    album = new Album
                    {
                        AlbumId = Guid.NewGuid().ToString(),
                        ArtistId = artist.ArtistId,
                        AlbumName = albummName,
                        Tracks = new ObservableCollection<Track>(),
                        htmlSongs = htmlSongs
                    };
                    //foreach (var item in tempTracks)
                    //{
                    //    item.AlbumId = album.AlbumId;
                    //}

                    //album.Tracks.AddRange(tempTracks);
                    playlist.Albums.Add(album);
                    MainClassWithLists.Albums.Add(album);
                }
                else
                {
                    var tempTracks = ParseTracksGoogle(htmlSongs);
                    playlist.Tracks.AddRange(tempTracks);
                }
            }
        }
        public static ObservableCollection<Track> ParseTracksGoogle(HtmlNodeCollection htmlSongs)
        {
            ObservableCollection<Track> tempTracks = new ObservableCollection<Track>();
            Track track;
            foreach (HtmlNode song in htmlSongs)
            {
                string trackName = song.SelectSingleNode(".//td[@class='sKniue WAjGKd']").InnerText;
                string trackDuration = song.SelectSingleNode(".//td[@class='KYddxf WAjGKd']").InnerText;
                track = new Track
                {
                    Id = Guid.NewGuid().ToString(),
                    Duration = trackDuration,
                    TrackName = trackName
                };
                tempTracks.Add(track);
                MainClassWithLists.Tracks.Add(track);
            }
            return tempTracks;
        }
        public static void ParseTracksGoogleForAlbum(ref Album album)
        {
            album.Tracks = ParseTracksGoogle(album.htmlSongs);
        }
        public static void ParseGoogleSomePlaylists()
        {
            HtmlDocument htmlSnippet = new HtmlDocument();
            string result;
            while (true)
            {
                result = GetUrl(rootUrl + url);
                htmlSnippet.LoadHtml(result);

                foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes(@"//div[@class='WHE7ib mpg5gc']"))
                {
                    Playlist playlist = new Playlist()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Tracks = new ObservableCollection<Track>()
                    };
                    playlist.PlaylistName = link.SelectSingleNode(@".//div[@class='vU6FJ zC8lR']").InnerText;
                    HtmlNode htmlNode = link.SelectSingleNode(@".//a[@class='poRVub']");
                    string href = htmlNode.GetAttributeValue("href", "");
                    ParseGoogleSongs(ref playlist, href);
                    MainClassWithLists.Playlists.Add(playlist);
                }
                break;
            }
        }

        public static void ParseSomeSongsGoogle(ref Playlist list, string href)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            string result = GetUrl(rootUrl + href);
            htmlDocument.LoadHtml(result);
            Album album;
            Track track;
            foreach (HtmlNode song in htmlDocument.DocumentNode.SelectNodes(@"//tr[@class='KaLrad yZhPwb']"))
            {
                string name = song.SelectSingleNode(@".//td[@class='sKniue WAjGKd']").InnerText;
                string albumName = song.SelectSingleNode(@".//a[@class='hrTbp R8zArc']").InnerText;
                string duration = song.SelectSingleNode(@".//td[@class='KYddxf WAjGKd']").InnerText;
                album = new Album()
                {
                    AlbumId = Guid.NewGuid().ToString(),
                    AlbumName = albumName
                };
                track = new Track()
                {
                    Id = Guid.NewGuid().ToString(),
                    TrackName = name,
                    AlbumId = album.AlbumId,
                    Duration = duration
                };
                MainClassWithLists.Albums.Add(album);
                MainClassWithLists.Tracks.Add(track);
                list.Tracks.Add(track);
            }
        }
        public static void UpdateSelectedPlaylist(ref Playlist playlist)
        {
            if (playlist.Albums.Count == 0 && playlist.Tracks.Count == 0)
                ParseGoogleAlbums(ref playlist, playlist.Href);
            MainClassWithLists.SelectedPlaylistTracks = new ObservableCollection<Track>();
            MainClassWithLists.SelectedPlaylistAlbums = new ObservableCollection<Album>();
            try
            {
                if (playlist.Tracks.Count != 0)
                {
                    MainClassWithLists.SelectedPlaylistTracks = playlist.Tracks;
                }
                if (playlist.Albums.Count != 0)
                {
                    MainClassWithLists.SelectedPlaylistAlbums = playlist.Albums;
                }
            }
            catch { }
        }
        public static void UpdateSelectedAlbum(ref Album album)
        {
            if (album.Tracks.Count == 0)
                ParseTracksGoogleForAlbum(ref album);
            MainClassWithLists.SelectedPlaylistTracks = new ObservableCollection<Track>();
            try
            {
                MainClassWithLists.SelectedPlaylistTracks = album.Tracks;
            }
            catch { }
        }
        public static HtmlDocument GetHtmlDocument(string href)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            string result = GetUrl(href);
            htmlDocument.LoadHtml(result);
            return htmlDocument;
        }
    }
}