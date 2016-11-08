using System;
using System.IO;
using Un4seen.Bass;

namespace IndieBeats_WFA
{
    class MediaPlayer
    {
        // Private instance variables
        private int stream;

        // Public instatnce variables
        public MusicLibraryDatabase library;
        public Song song = new Song();

        // Properties
        private string selectedSong;
        public string SelectedSong
        {
            get { return selectedSong; }
        }

        private int currentVolume;
        public int CurrentVolume
        {
            get { return currentVolume; }
            set { setVolume(value); }
        }

        private bool isPaused;
        public bool IsPaused
        {
            get { return isPaused; }
        }

        public double Time
        {
            get { return Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream)); }
            set { setTime(value); }
        }

        private bool shuffle;
        public bool Shuffle
        {
            get { return shuffle; }
            set { shuffle = value; }
        }

        // Constructor
        public MediaPlayer(int initialVolume = 100)
        {
            verifyDependicies();

            // Create a new music library
            library = new MusicLibraryDatabase();

            // Create the library database
            library.createLibraryDatabase("Test.DB");


            // Load the libary
            library.loadLibrary("Test.DB");

            // Add the table
            library.addLibraryTable("MainLibrary");
  

            // Set the music library table to use
            library.TableName = "MainLibrary";

            // Initialzie song index to fist song
            song.Index = 0;

            // Create the audio stream
            stream = createStream(library.getSongPath(song.Index));



            // Set song data only if we have a valid music database
            if (library.libraryIsValid())
            {
                setSongData();
            }

            // Set the volume
            currentVolume = initialVolume;

            // Start the application paused
            isPaused = true;
        }


        // Public Methods
        public void pausePlay()
        {
            if (!isPaused)
            {
                Bass.BASS_ChannelPause(stream);
            }
            else
            {
                Bass.BASS_ChannelPlay(stream, false);
            }

            isPaused = !isPaused;
        }

        public void playPreviousSong()
        {
            freeStream(stream);

            if (song.Index > 0)
            {
                stream = createStream(library.getSongPath(--song.Index));
            } 
            else
            {
                song.Index = 0;
                stream = createStream(library.getSongPath(song.Index));
            }


            if (!isPaused)
            {
                playStream(stream);
            }

            setVolume(currentVolume);
            setSongData();
        }

        public void playNextSong()
        {
            freeStream(stream);

            if (shuffle)
            {
                song.Index = new Random().Next(library.getNumOfSongs());

                playSong(song.Index);
            }

            else if (song.Index < library.getNumOfSongs())
            {
                stream = createStream(library.getSongPath(++song.Index));
                song.Index = song.Index;
            }
            else
            {
                song.Index = 0;
                stream = createStream(library.getSongPath(song.Index));
            }


            if (!isPaused)
            {
                playStream(stream);
            }

            setVolume(currentVolume);
            setSongData();
        }

        public void playSong(int songNumber)
        {
            freeStream(stream);

            stream = createStream(library.getSongPath(songNumber));
            song.Index = songNumber;
            setVolume(currentVolume);
            playStream(stream);
            setSongData();
        }

        public void selectSong(int songNumber)
        {
            selectedSong = library.getSongPath(songNumber);
        }


        // Private Methods
        private void setVolume(int initialVolume)
        {
            // Set the user friendly volume 1 - 100
            currentVolume = initialVolume;

            // The volume in float form between 0 - 1
            float actualVolume = currentVolume * (float)Math.Pow(10, -2);

            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, actualVolume);
        }

        private void setTime(double seconds)
        {
            Bass.BASS_ChannelSetPosition(stream, seconds);
        }


        private int createStream(string file)
        {
            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
            {
                // create a stream channel from a file
                return Bass.BASS_StreamCreateFile(file, 0L, 0L, BASSFlag.BASS_DEFAULT);
            }

            return 0;
        }

        private BASSError playStream(int stream)
        {
            if (stream != 0)
            {
                // play the channel
                Bass.BASS_ChannelPlay(stream, false);
                return BASSError.BASS_OK;
            }
            else
            {
                // return the error 
                return Bass.BASS_ErrorGetCode();
            }
        }

        private void freeStream(int stream)
        {
            // free the stream
            Bass.BASS_StreamFree(stream);
            // free BASS
            Bass.BASS_Free();
        }

        private void setSongData()
        {
            song.Path = library.getSongPath(song.Index);
            song.Name = MetadataHandler.getTitle(song.Path);
            song.Album = MetadataHandler.getAlbum(song.Path);
            song.AlbumArt = MetadataHandler.getAlbumArt(song.Path, 142, 142);
            song.Artist = MetadataHandler.getArtist(song.Path);
            song.TimeInSeconds = (int)Math.Floor(Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream)));
            song.Minutes = getMinutes();
            song.Seconds = getSeconds();
        }

        private int getMinutes()
        {
            double fullTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
            return (int)Math.Floor(fullTime / 60);           
        }

        private int getSeconds()
        {
            double fullTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
            return (int)Math.Floor(fullTime % 60);
        }

        // Verifies that all the needed dlls are in the program folder
        private void verifyDependicies()
        {
            if (!File.Exists("System.Data.SQLite.dll"))
                throw new DllNotFoundException("System.Data.SQLite.dll could not be found!");

            if (!File.Exists("SQLite.Interop.dll"))
                throw new DllNotFoundException("SQLite.Interop.dll could not be found!");

            if (!File.Exists("Bass.Net.dll"))
                throw new DllNotFoundException("Bass.Net.dll could not be found!");

            if (!File.Exists("bass.dll"))
                throw new DllNotFoundException("bass.dll could not be found!");

            if (!File.Exists("policy.2.0.taglib-sharp.dll"))
                throw new DllNotFoundException("policy.2.0.taglib-sharp.dll could not be found!");

            if (!File.Exists("taglib-sharp.dll"))
                throw new DllNotFoundException("taglib-sharp.dll could not be found!");
        }

    }
}
