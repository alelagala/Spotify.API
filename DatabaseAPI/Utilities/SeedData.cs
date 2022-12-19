using DatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Utilities
{
    public static class SeedData
    {
        public static async Task SeedDatabase(SpotifyContext context)
        {
            Clear(context.Albums);
            Clear(context.Artists);
            Clear(context.Genres);
            Clear(context.Playlists);
            Clear(context.PlaylistSongs);
            Clear(context.Radios);
            Clear(context.Songs);

            List<Artist> artists = new List<Artist>()
            {
                new Artist {  Title="Cannibal Corpse",         Albums= new List<Album>(), Songs= new List<Song>()  },
                new Artist {  Title="In flames",               Albums= new List<Album>(), Songs= new List<Song>()  },
                new Artist {  Title="Suicide Silence",         Albums= new List<Album>(), Songs= new List<Song>()  },
                new Artist {  Title="Slayer",                  Albums= new List<Album>(), Songs= new List<Song>()  },
                new Artist {  Title="Amon Amarth",             Albums= new List<Album>(), Songs= new List<Song>()  },
                new Artist {  Title="Megadeth",                Albums= new List<Album>(), Songs= new List<Song>()  }
            };

            List<Album> albums = new List<Album>()
            {
                new Album { Title="Kill",                      Songs= new()   },
                new Album { Title="Come Clarity",              Songs= new()   },
                new Album { Title="Black Crown",               Songs= new()   },
                new Album { Title="Show no mercy",             Songs= new()   },
                new Album { Title="Twilight of thunder god",   Songs= new()   },
                new Album { Title="Rust in peace",             Songs= new()   },
            };

            List<Song> songs = new List<Song>
            {
                new Song(){Title="The Time to Kill Is Now",    Popularity= 10   },
                new Song(){Title="Make Them Suffer",           Popularity= 10   },
                new Song(){Title="Murder Worship",             Popularity= 10   },
                new Song(){Title="Maniacal ",                  Popularity= 10   },
                new Song(){Title="Death Walking Terror",       Popularity= 1000 },
                new Song(){Title="Barbaric",                   Popularity= 10   },

                new Song(){Title="Take This Life",             Popularity= 10   },
                new Song(){Title="Leeches",                    Popularity= 10   },
                new Song(){Title="Reflect The Storm",          Popularity= 10   },
                new Song(){Title="Dead End ",                 Popularity= 10    },
                new Song(){Title="Come Clarity",              Popularity= 1000  },
                new Song(){Title="Crawl Through Knives",      Popularity= 10    },

                new Song(){Title="Slaves to Substance ",      Popularity= 10   },
                new Song(){Title="O.C.D.",                    Popularity= 10   },
                new Song(){Title="You Only Live Once",        Popularity= 10   },
                new Song(){Title="March to the Black Crown",  Popularity= 10   },
                new Song(){Title="Witness the Addiction",     Popularity= 2000 },
                new Song(){Title="Smashed",                   Popularity= 10   },

                new Song(){Title="Die by the Sword",          Popularity= 10   },
                new Song(){Title="Crionics",                  Popularity= 10   },
                new Song(){Title="Fight Till Death",          Popularity= 700  },
                new Song(){Title="Chemical Warfare",          Popularity= 10   },
                new Song(){Title="Haunting the Chapel",       Popularity= 10   },
                new Song(){Title="Black Magic",               Popularity= 10   },

                new Song(){Title="Twilight of Thunder God",   Popularity= 10   },
                new Song(){Title="Free Will Sacrifice",       Popularity= 10   },
                new Song(){Title="Guardians of Asgaard ",     Popularity= 10   },
                new Song(){Title="Where Is Your God?",        Popularity= 10   },
                new Song(){Title="The Hero",                  Popularity= 500  },
                new Song(){Title="Live for the Kill",         Popularity= 10   },

                new Song(){Title="Holy Wars",                 Popularity= 10   },
                new Song(){Title="Hangar 18",                 Popularity= 10   },
                new Song(){Title="Take No Prisoners",         Popularity= 300  },
                new Song(){Title="Tornado of Souls",          Popularity= 10   },
                new Song(){Title="Rust in Peace",             Popularity= 200  },
                new Song(){Title="Dawn Patrol",               Popularity= 10   }
            };

            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist { Title="Playlist Default Spotify" },
                new Playlist { Title="Playlist SUPER METAL"},
            };

            Account account = new() {UserName = "admin", Playlists=new(),  Email="ale@gmail.com", Pw="129874", SubscriptionName="Premium" };

            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Title="Progressive Metal",  Albums=new(), Radios= new(), Songs= new()},
                new Genre() { Title="Trash Metal",        Albums=new(), Radios= new(), Songs= new()},
                new Genre() { Title="Grindcore",          Albums=new(), Radios= new(), Songs= new()},
                new Genre() { Title="Metalcore",          Albums=new(), Radios= new(), Songs= new()},
            };

            List<Radio> radios = new List<Radio>()
            {
                new Radio() { Title="PROGRADIO 120.5"   },
                new Radio() { Title="VintageRadio 101.7"},
                new Radio() { Title="GrindCORE 99.6"    },
                new Radio() { Title="Metalcore 2025"    },
            };

            //List<PlaylistSong> pivotTable = new List<PlaylistSong>()
            //{
            //    new PlaylistSong() { Id=1, PlaylistId=1, SongId=2},
            //    new PlaylistSong() { Id=2, PlaylistId=1, SongId=3},
            //    new PlaylistSong() { Id=3, PlaylistId=1, SongId=4},
            //    new PlaylistSong() { Id=4, PlaylistId=2, SongId=6},
            //    new PlaylistSong() { Id=5, PlaylistId=2, SongId=7},
            //    new PlaylistSong() { Id=6, PlaylistId=2, SongId=8}
            //};

            //foreach( var a in artists)
            //{
            //    a.Albums = albums.Where(x => x.ArtistId== a.Id).ToList();
            //    a.Songs = songs.Where(x => x.ArtistId== a.Id).ToList();
            //} 
            //foreach( var a in albums)
            //{
            //    a.Songs= songs.Where(x => x.AlbumId== a.Id).ToList();
            //    a.Artist = artists.Where(x => x.Id == a.ArtistId).First();
            //    a.Genre = genres.Where(x => x.Id == a.GenreId).First();
            //}
            //foreach( var s in songs)
            //{
            //    s.Artist= artists.Where(x => x.Id == s.ArtistId).First();
            //    s.Album = albums.Where(x => x.Id == s.AlbumId).First();
            //    s.Genre = genres.Where(x => x.Id == s.GenreId).First();
            //}
            //foreach( var p in playlists)
            //{
            //    p.Account = account;
            //}            
            //foreach( var g in genres)
            //{
            //    g.Albums=albums.Where(x => x.GenreId== g.Id).ToList();
            //    g.Radios = radios.Where(x => x.GenreId == g.Id).ToList();
            //    g.Songs= songs.Where(x => x.GenreId == g.Id).ToList();
            //}
            //foreach( var r in radios)
            //{
            //    r.Genre= genres.Where(x => x.Id == r.GenreId).First();
            //}
            //account.Playlists = playlists;
            
            for ( int i = 0; i < artists.Count; i++)
            {
                artists[i].Albums.Add(albums[i]);
            }

            int j = 0;
            //foreach (var art in artists)
            //{

            //    art.Songs.Add(songs[j]);
            //    j++;
            //    art.Songs.Add(songs[j]);
            //    j++;
            //    art.Songs.Add(songs[j]);
            //    j++;
            //    art.Songs.Add(songs[j]);
            //    j++;
            //    art.Songs.Add(songs[j]);
            //    j++;
            //    art.Songs.Add(songs[j]);
            //    j++;
            //}
           
            for(int i=0;i<artists.Count;i++)
            {
                artists[i].Songs.AddRange(GetPage<Song>(songs, i, 6));
            }
            for (int i = 0; i < albums.Count; i++)
            {
                albums[i].Songs.AddRange(GetPage<Song>(songs, i, 6));
            }
            var temp= new List<Song>();


            for (int i = 0; i < genres.Count; i++)
            {
                temp= new List<Song>() { songs[i*6], songs[i*6 + 1], songs[i*6 + 2], songs[i*6 + 3], songs[i*6 + 4], songs[i*6+5] };
                genres[i].Songs.AddRange(temp);
            }

            temp = new List<Song>() { songs[24], songs[25], songs[26], songs[27], songs[28], songs[29] };
            genres[0].Songs.AddRange(temp);
            temp= new List<Song>() { songs[30], songs[31], songs[32], songs[33], songs[34], songs[35] };
            genres[1].Songs.AddRange(temp);

            for(int i=0; i < radios.Count; i++)
            {
                radios[i].Genre= genres[i];
            }


            context.Artists.AddRange(artists);
            context.Albums.AddRange(albums);
            context.Songs.AddRange(songs);
            context.Playlists.AddRange(playlists);
            context.Genres.AddRange(genres);
            context.Radios.AddRange(radios);
            //context.PlaylistSongs.AddRange(pivotTable);
            context.Accounts.Add(account);
            try
            {                
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }




        }


        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            if (dbSet.Any()){dbSet.RemoveRange(dbSet.ToList());}
        }



        public static IList<T> GetPage<T>(IList<T> list, int page, int pageSize)
        {
            return list.Skip(page * pageSize).Take(pageSize).ToList();
        }

    }
}
