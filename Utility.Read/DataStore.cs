using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DatabaseAPI.Models;
namespace Utility.Read
{
    public class DataStore
    {
        public virtual List<Artist> artists { get; set; }
        public List<Album> albums { get; set; }
        public List<Song> songs { get; set; }
        public List<Playlist> playlists { get; set; }
        public List<Radio> radios { get; set; }
        public List<Genre> genres { get; set; }


        
        public static DataStore dataStore;
        public static HttpClient client;


        DataStore()
        {

            artists = new List<Artist>();
            albums = new List<Album>();
            playlists = new List<Playlist>();
            radios = new List<Radio>();            
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5344/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            songs = GetSongs().GetAwaiter().GetResult();
            artists = GetArtists().GetAwaiter().GetResult();
            genres = GetGenres().GetAwaiter().GetResult();
            albums = GetAlbums().GetAwaiter().GetResult();
            radios = GetRadios().GetAwaiter().GetResult();
            SetAlbumSongs(albums, songs);
            SetArtistSongs(artists, songs);
            SetArtistAlbum();
            SetGenreSongs(genres, songs);
            SetSongsProperties(songs, genres, albums, artists);
            SetRadiosGenre();
            SetGenreProperties(genres, albums,radios,songs);
            //SetAlbumProperties();
            





        }




        async Task<List<Song>> GetSongs()
        {
            List<Song> songs = new List<Song>();
            HttpResponseMessage response = await client.GetAsync($"api/Database/GetSongs");
            if (response.IsSuccessStatusCode)
            {
                songs = await response.Content.ReadAsAsync<List<Song>>();
            }
            return songs;
        }
        async Task<List<Artist>> GetArtists()
        {
            List<Artist> artists = new List<Artist>();
            HttpResponseMessage response = await client.GetAsync($"api/Database/GetArtists");
            if (response.IsSuccessStatusCode)
            {
                artists = await response.Content.ReadAsAsync<List<Artist>>();
            }
            return artists;
        }
        async Task<List<Genre>> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            HttpResponseMessage response = await client.GetAsync($"api/Database/GetGenres");
            if (response.IsSuccessStatusCode)
            {
                genres = await response.Content.ReadAsAsync<List<Genre>>();
            }
            return genres;
        }
        async Task<List<Album>> GetAlbums()
        {
            List<Album> album = new List<Album>();
            HttpResponseMessage response = await client.GetAsync($"api/Database/GetAlbums");
            if (response.IsSuccessStatusCode)
            {
                album = await response.Content.ReadAsAsync<List<Album>>();
            }
            return album;
        }
        async Task<List<Radio>> GetRadios()
        {
            List<Radio> radios = new List<Radio>();
            HttpResponseMessage response = await client.GetAsync($"api/Database/GetRadios");
            if (response.IsSuccessStatusCode)
            {
                radios = await response.Content.ReadAsAsync<List<Radio>>();
            }
            return radios;
        }
        static void SetArtistSongs(List<Artist> artists, List<Song> songs)
        {
            foreach (var a in artists)
            {
                a.Songs.AddRange(songs.Where(x => x.ArtistId == a.Id));
            }
        }
        void SetArtistAlbum()
        {
            foreach (var artist in artists)
            {
                artist.Albums.AddRange(albums.Where(x => x.ArtistId == artist.Id));
            }
        }

        static void SetAlbumSongs(List<Album> albums, List<Song> songs)
        {
            foreach (var a in albums)
            {
                a.Songs.AddRange(songs.Where(x => x.AlbumId == a.Id));
            }
        }
        void SetAlbumProperties()
        {
            foreach (var album in albums)
            {
                //album.Songs.AddRange(songs.Where(x => x.AlbumId == album.Id));
                album.Artist = artists.Where(x => x.Id == album.ArtistId).First();
                //album.Genre = genres.Where(x => x.Id == album.GenreId).First();
            }
        }
        static void SetGenreSongs(List<Genre> genres, List<Song> songs)
        {
            foreach (var g in genres)
            {
                g.Songs.AddRange(songs.Where(x => x.GenreId == g.Id));
            }
        }
        static void SetSongsProperties(List<Song> songs, List<Genre> genres, List<Album> albums, List<Artist> artists)
        {
            foreach (var song in songs)
            {
                song.Artist = artists.Where(x => x.Id == song.ArtistId).FirstOrDefault();
                song.Album = albums.Where(x => x.Id == song.AlbumId).FirstOrDefault();
                song.Genre = genres.Where(x => x.Id == song.GenreId).FirstOrDefault();
            }
        }

        static void SetGenreProperties(List<Genre> genres, List<Album> albums, List<Radio> radios, List<Song> songs)
        {
            foreach(var genre in genres)
            {
                genre.Albums= albums.Where(x => x.GenreId == genre.Id).ToList();
                genre.Radios= radios.Where(x => x.GenreId == genre.Id).ToList();
                genre.Songs= songs.Where(x => x.GenreId == genre.Id).ToList();
            }
        }
        void SetRadiosGenre()
        {
            foreach (var radio in radios)
            {
                radio.Genre = genres.Where(x => x.Id == radio.GenreId).First();
            }
        }





        public void ShowPlaylist()
        {
            Console.WriteLine("Tutte le playlist: ");
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"Nome Playlist: {playlist.Title}  Autore: {playlist.Account.UserName}");
            }
        }
        public void ShowRadios()
        {
            Console.WriteLine("Tutte le radio: ");
            foreach (var radio in radios.OrderBy(x=>x.Genre))
            {
                Console.WriteLine($"Nome Radio: {radio.Title} Genere: {radio.Genre.Title}");
            }
        }

        public static DataStore GetInstance()
        {
            if(dataStore == null)
            {
                return dataStore = new DataStore(); 
            }
            else
            {
                return dataStore;
            }
            
        }
        
    }
}
