using System;
using System.IO;
using System.Collections.Generic;
using Un4seen.Bass;

namespace IndieBeats_WFA
{
    class MediaPlayer
    {
        // Private instance variables
        private int songIndex;
        private int stream;

        // Public instatnce variables
        public MusicLibrary library;

        // Properties
        private string currentSongPath;
        public string CurrentSongPath
        {
            get { return currentSongPath; }
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


        // Constructor
        public MediaPlayer(int initialVolume = 100)
        {
            // Create a new music library
            library = new MusicLibrary();

            // Create the library database
            library.createLibraryDatabase("Test.DB");

            // Load the libary
            library.loadLibrary("Test.DB");

            // Initialzie song index to fist song
            songIndex = 0;

            // Create the audio stream
            stream = createStream(library.getSongPath(songIndex));

            currentSongPath = library.getSongPath(songIndex);

            currentVolume = initialVolume;

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

            if (songIndex > 0)
                stream = createStream(library.getSongPath(--songIndex));     
            else
            {
                songIndex = 0;
                stream = createStream(library.getSongPath(songIndex));
            }


            if (!isPaused)
            {
                playStream(stream);
            }

            setVolume(currentVolume);
            currentSongPath = library.getSongPath(songIndex);
        }

        public void playNextSong()
        {
            freeStream(stream);

            if (songIndex < library.getNumOfSongs())
                stream = createStream(library.getSongPath(++songIndex));
            else
            {
                songIndex = 0;
                stream = createStream(library.getSongPath(songIndex));
            }


            if (!isPaused)
            {
                playStream(stream);
            }

            setVolume(currentVolume);
            currentSongPath = library.getSongPath(songIndex);
        }

        public void playSong(int songNumber)
        {
            freeStream(stream);

            stream = createStream(library.getSongPath(songNumber));
            setVolume(currentVolume);
            playStream(stream);
            currentSongPath = library.getSongPath(songNumber);
        }

        public void selectSong(int songNumber)
        {
            currentSongPath = library.getSongPath(songNumber);
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

    }
}
