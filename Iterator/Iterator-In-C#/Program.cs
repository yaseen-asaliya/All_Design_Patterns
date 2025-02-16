using System;
using System.Collections.Generic;

namespace IteratorDemo
{
    // Iterator Interface
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    // Concrete Iterator for Playlist
    public class PlaylistIterator : IIterator<Song>
    {
        private List<Song> _songs;
        private int _position = 0;

        public PlaylistIterator(List<Song> songs)
        {
            _songs = songs;
        }

        public bool HasNext()
        {
            return _position < _songs.Count;
        }

        public Song Next()
        {
            return HasNext() ? _songs[_position++] : null;
        }
    }

    // Aggregate Interface
    public interface IPlaylist
    {
        IIterator<Song> CreateIterator();
    }

    // Concrete Aggregate: Playlist
    public class Playlist : IPlaylist
    {
        private List<Song> _songs = new List<Song>();

        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        public IIterator<Song> CreateIterator()
        {
            return new PlaylistIterator(_songs);
        }
    }

    // Song Class
    public class Song
    {
        public string Title { get; }
        public string Artist { get; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} by {Artist}";
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            // Create a playlist and add songs
            Playlist playlist = new Playlist();
            playlist.AddSong(new Song("Shape of You", "Ed Sheeran"));
            playlist.AddSong(new Song("Blinding Lights", "The Weeknd"));
            playlist.AddSong(new Song("Bohemian Rhapsody", "Queen"));

            // Get iterator
            IIterator<Song> iterator = playlist.CreateIterator();

            // Iterate through the playlist
            Console.WriteLine("Playing songs in the playlist:");
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
