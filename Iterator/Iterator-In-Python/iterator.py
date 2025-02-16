# Iterator Interface
class IIterator:
    def has_next(self):
        pass

    def next(self):
        pass


# Concrete Iterator for Playlist
class PlaylistIterator(IIterator):
    def __init__(self, songs):
        self._songs = songs
        self._position = 0

    def has_next(self):
        return self._position < len(self._songs)

    def next(self):
        if self.has_next():
            song = self._songs[self._position]
            self._position += 1
            return song
        return None


# Aggregate Interface
class IPlaylist:
    def create_iterator(self):
        pass


# Concrete Aggregate: Playlist
class Playlist(IPlaylist):
    def __init__(self):
        self._songs = []

    def add_song(self, song):
        self._songs.append(song)

    def create_iterator(self):
        return PlaylistIterator(self._songs)


# Song Class
class Song:
    def __init__(self, title, artist):
        self.title = title
        self.artist = artist

    def __str__(self):
        return f"{self.title} by {self.artist}"


# Main Program
if __name__ == "__main__":
    # Create a playlist and add songs
    playlist = Playlist()
    playlist.add_song(Song("Shape of You", "Ed Sheeran"))
    playlist.add_song(Song("Blinding Lights", "The Weeknd"))
    playlist.add_song(Song("Bohemian Rhapsody", "Queen"))

    # Get iterator
    iterator = playlist.create_iterator()

    # Iterate through the playlist
    print("Playing songs in the playlist:")
    while iterator.has_next():
        print(iterator.next())
