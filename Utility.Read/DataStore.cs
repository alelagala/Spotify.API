using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class DataStore
    {
        public List<Artist> artists { get; set; }
        public List<Album> albums { get; set; }
        public List<Song> songs { get; set; }
        public List<Playlist> playlists { get; set; }
        public List<Radio> radios { get; set; }
        
        public User user { get; set; }
        public static DataStore dataStore;

        
        DataStore()
        {
            artists = new List<Artist>();
            albums = new List<Album>();
            playlists = new List<Playlist>();
            radios = new List<Radio>();
            user = new User();
            songs = Utility.CreateObject<Song>(Utility.ReadfromFile(Settings.musicpath));
            try
            {
                radios = Utility.CreateObject<Radio>(Utility.ReadfromFile(Settings.radiospath));
                
            }
            catch
            {
                Console.WriteLine("No radio found");
            }
            foreach (Song s in songs)
            {
                s.CreateAlbum(albums);
            }
            foreach (Album album in albums)
            {
                album.CreateArtist(artists);
            }
            foreach (Radio radio in radios)
            {
                radio.SetList(artists);
            }
            try
            {
                playlists = Utility.CreateObject<Playlist>(Utility.ReadfromFile(Settings.playlistpath));
                foreach (Playlist playlist in playlists)
                {
                    playlist.GeneratefromFile(artists);
                }
            }
            catch
            {
                Console.WriteLine("No playlist found");
            }
        }
        public void ShowPlaylist()
        {
            Console.WriteLine("Tutte le playlist: ");
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"Nome Playlist: {playlist.Name}  Autore: {playlist.Author}");
            }
        }
        public void ShowRadios()
        {
            Console.WriteLine("Tutte le radio: ");
            foreach (var radio in radios.OrderBy(x=>x.Genre))
            {
                Console.WriteLine($"Nome Radio: {radio.Name} Genere: {radio.Genre}");
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
        public static async Task<DataStore> prova() 
        {
            return await Task.Factory.StartNew<DataStore>(GetInstance);
        }
    }
}
