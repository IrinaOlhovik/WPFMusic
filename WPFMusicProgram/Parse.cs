using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMusicProgram.Model;
using System.Net;
using HtmlAgilityPack;
using System.Collections;

namespace WPFMusicProgram
{
    public class Parse
    {
        private static string rootUrl = @"https://play.google.com/";
        private static string url = @"store/music/collection/cluster?clp=YhgKCHBsYXlsaXN0EAMaCgoIcGxheWxpc3Q%3D:S:ANO1ljJG2Xc&gsr=ChpiGAoIcGxheWxpc3QQAxoKCghwbGF5bGlzdA%3D%3D:S:ANO1ljLEfEM";
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
                result = GetUrl(rootUrl + url);
                htmlSnippet.LoadHtml(result);

                foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes(@"//div[@class='WHE7ib mpg5gc']"))
                {
                    Playlist playlist = new Playlist()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Tracks = new List<Track>()
                    };
                    playlist.PlaylistName = link.SelectSingleNode(@".//div[@class='vU6FJ zC8lR']").InnerText;
                    HtmlNode htmlNode = link.SelectSingleNode(@".//a[@class='poRVub']");
                    string href = htmlNode.GetAttributeValue("href", "");
                    ParseSongsGoogle(ref playlist, href);
                    MainClassWithLists.Playlists.Add(playlist);
                }
                break;
            }
        }

        public static void ParseSongsGoogle(ref Playlist list, string href)
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
    }
}