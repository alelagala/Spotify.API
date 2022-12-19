using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class Radio
    {
        public string Genre { get; set; }
        public string Name { get; set; }
        List<Song> list = new List<Song>();
        public Radio() { }
        public Radio(string genre, string name)
        {
            Genre= genre;
            Name= name;
            addTolist();
        }

        public void SetList(List<Artist> artists)
        {
            
            foreach (Artist artist in artists)
            {
                foreach (Album album in artist.Albums)
                {
                    foreach (Song song in album.Songs)
                    {
                        if(song.Genre == Genre)
                        {
                            list.Add(song);
                            
                        }
                    }
                }
            }
        }
        public List<Song> GetList()
        {
            return list;
        }
        public void addTolist()
        {
            DataStore.dataStore.radios.Add(this);
            Utility.WriteonFile(Settings.radiospath, DataStore.dataStore.radios);
        }
    }
}
