using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    public class MediaPlayer
    {
        public static MediaPlayer mediaPlayer;
        public Song currentSong { get; set; }
        public List<string> currentPages { get; set; }
        public Artist currentArtist { get; set; }
        public Album currentAlbum { get; set; } 
        public Playlist currentPlaylist { get; set; }
        public Radio currentRadio { get; set; }
        public bool isPlaying { get; set; }

        public static MediaPlayer GetInstance()
        {
            if (mediaPlayer == null)
            {
                mediaPlayer = new MediaPlayer();
            }
            return mediaPlayer;
            
        }
        protected MediaPlayer()
        {
            currentPages = new List<string>();
        }
        public void Play(Song song)
        {
            currentSong = song;

            isPlaying = true;
        }
        public void PlayRadio()
        {
            Random random = new Random();
            
            if(currentRadio == null)
            {
                currentRadio = DataStore.GetInstance().radios.Where(x => x.Genre == currentSong.Genre).FirstOrDefault();
            }
            var index = random.Next(0, currentRadio.GetList().Count);
            while (currentRadio.GetList()[index] == currentSong)
            {
                index = random.Next(0, currentRadio.GetList().Count);
            }
            Play(currentRadio.GetList()[index]);
            currentSong.SetStatus(Status.ALL);
        }
        public void Pause()
        {
            if (isPlaying) { isPlaying = false; }
            else { isPlaying = true; }
        }
        public void Stop()
        {
            if (currentSong != null)
            {
                currentSong = null;
                if (isPlaying) { isPlaying = false; }
                else { isPlaying = true; }
            }

        }
        public string Next()
        {
            if (currentSong != null)
            {
                if (currentSong.getStatus() == Status.TOP)
                {
                    var topsong = Utility.GetTopFiveSongs();
                    int index = topsong.IndexOf(currentSong);
                    if (index < topsong.Count - 1)
                    {
                        Play(topsong[index + 1]);
                        currentSong.SetStatus(Status.TOP);
                    }
                    else
                    {
                        Play(topsong[0]);
                        currentSong.SetStatus(Status.TOP);
                    }
                    return "artistMenu";
                }
                else if (currentSong.getStatus() == Status.ALL)
                {
                    PlayRadio();
                    return "s";
                }
                else if (currentSong.getStatus() == Status.ALBUM)
                {


                    var index = currentAlbum.Songs.IndexOf(currentSong);
                    if (index < currentAlbum.Songs.Count - 1)
                    {

                        Play(currentAlbum.Songs[index + 1]);
                        currentSong.SetStatus(Status.ALBUM);
                    }
                    else
                    {
                        Play(currentAlbum.Songs[0]);
                        currentSong.SetStatus(Status.ALBUM);
                    }
                    return "albumMenu";
                }
                else if (currentSong.getStatus() == Status.PLAYLIST)
                {
                    var index = currentPlaylist.getSongs().IndexOf(currentSong);
                    if (index < currentPlaylist.getSongs().Count - 1)
                    {

                        Play(currentPlaylist.getSongs()[index + 1]);
                        currentSong.SetStatus(Status.PLAYLIST);
                    }
                    else
                    {
                        Play(currentPlaylist.getSongs()[0]);
                        currentSong.SetStatus(Status.PLAYLIST);
                    }
                    return "playlistMenu";
                }
            }
            return "b";
        }
        public string Back()
        {
            if (currentSong != null)
            {
                if (currentSong.getStatus() == Status.TOP)
                {
                    var topsong = Utility.GetTopFiveSongs();
                    int index = topsong.IndexOf(currentSong);
                    if (index > 0)
                    {
                        Play(topsong[index - 1]);
                        currentSong.SetStatus(Status.TOP);
                    }
                    else
                    {
                        Play(topsong[0]);
                        currentSong.SetStatus(Status.TOP);
                    }
                    return "artistMenu";
                }
                else if (currentSong.getStatus() == Status.ALL)
                {
                    PlayRadio();
                    return "s";
                }
                else if (currentSong.getStatus() == Status.ALBUM)
                {

                    var index = currentAlbum.Songs.IndexOf(currentSong);
                    if (index > 0)
                    {
                        Play(currentAlbum.Songs[index - 1]);
                        currentSong.SetStatus(Status.ALBUM);
                    }
                    else
                    {
                        Play(currentAlbum.Songs[0]);
                        currentSong.SetStatus(Status.ALBUM);
                    }
                    return "albumMenu";
                }
                else if (currentSong.getStatus() == Status.PLAYLIST)
                {
                    var index = currentPlaylist.getSongs().IndexOf(currentSong);
                    if (index > 0)
                    {

                        Play(currentPlaylist.getSongs()[index - 1]);
                        currentSong.SetStatus(Status.PLAYLIST);
                    }
                    else
                    {
                        Play(currentPlaylist.getSongs()[0]);
                        currentSong.SetStatus(Status.PLAYLIST);
                    }
                    return "playlistMenu";
                }
            }
            return "b";
        }




    }
}
