using System;
using System.IO;
using System.Collections.Generic;
using Un4seen.Bass;

namespace IndieBeats_WFA
{
    class MediaPlayer
    { 
        // Private instance variables
        private int songIndex = 0;
        private int stream;
        private string[] files;

        // Properties
        private string currentSongName;
        public string CurrentSongName
        {
            get { return currentSongName; }
        }

        private int currentVolume;
        public int CurrentVolume
        {
            get { return currentVolume; }
            set { setVolume(value); }
        }

        private string musicLibaryPath;
        public string MusicLibraryPath
        {
            get { return MusicLibraryPath; }
        }


        // Constructor
        public MediaPlayer(string libraryPath, int initialVolume = 100)
        {
            // Load the users music library
            files = Directory.GetFiles(libraryPath);
            
            // Set the song index to the end of the files array
            // So it plays in order instead of reverse order
            songIndex = files.Length - 1;

            // Create the audio stream
            stream = createStream(files[songIndex]);

            currentSongName = Path.GetFileName(files[songIndex]);
            currentVolume = initialVolume;
            musicLibaryPath = libraryPath;
        }


        // Public Methods
        public void pausePlay()
        {
            if (Bass.BASS_ChannelPause(stream))
            {
                Bass.BASS_ChannelPause(stream);
            }
            else
            {
                Bass.BASS_ChannelPlay(stream, false);
            }
        }

        public void playPreviousSong()
        {
            freeStream(stream);

            try
            {
                // We add 1 to songIndex becaue we are treating 
                // the last array index as the first song.
                stream = createStream(files[++songIndex]);
            }
            catch (IndexOutOfRangeException)
            {
                songIndex = files.Length - 1;
                stream = createStream(files[songIndex]);
            }


            setVolume(currentVolume);
            playStream(stream);
            currentSongName = Path.GetFileName(files[songIndex]);
        }

        public void playNextSong()
        {
            freeStream(stream);

            try
            {
                stream = createStream(files[--songIndex]);
            }
            catch (IndexOutOfRangeException)
            {
                songIndex = files.Length - 1;
                stream = createStream(files[songIndex]);
            }

            setVolume(currentVolume);
            playStream(stream);
            currentSongName = Path.GetFileName(files[songIndex]);
        }

        public void changeMusicLibrary()
        {

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
