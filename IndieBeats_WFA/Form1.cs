using System;
using System.Windows.Forms;

namespace IndieBeats_WFA
{
    public partial class Form1 : Form
    {
        private MediaPlayer player;

        #region Form1 Constructor
        public Form1()
        {
            InitializeComponent();
            
            // Try to create a new music player. If any of the required dlls are missing
            // we will show an error and exit the application.
            try
            {
                player = new MediaPlayer();
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            // Load all the song data into a table and display it to the user
            createSongTable();

            // Display the current song properties to screen
            displayData();

            // Sets the music time bar to it's inital state depending on the current song
            resetTimeBarData();
        }
        #endregion

        // Event Handlers
        #region Event Handlers

        /* Plays or Pauses the current track. */
        private void pausePlay_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Pause or play the audio file
                player.pausePlay();

                displayData();

                // Update the text on the pause/play button depending on the player state
                if (player.IsPaused)
                {
                    pausePlay.Text = "Play";
                    SongTimer.Stop();
                }

                else
                {
                    SongTimer.Start();
                    pausePlay.Text = "Pause";
                }
            }
        }

        /* Plays the previous song in the music library and update the display to show it's info. */
        private void previousSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play the previous audio file
                player.playPreviousSong();
                updateDisplay();
            }

        }

        /* Plays the next song in the music library and update the display to show it's info. */
        private void nextSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play next audio file
                player.playNextSong();
                updateDisplay();
            }
        }

        /* Changes the volume of the music and displays the changed volume to screen. */
        private void volumeSlider_Scroll(object sender, EventArgs e)
        {
            player.CurrentVolume = VolumeSlider.Value;
            this.CurrentVolume.Text = player.CurrentVolume.ToString();
        }

        /* Prompts the user to select a folder and adds all the music in the folder to the music libraray. 
         * If the library does not have music in it yet, it will also set the song to play to the first in the library. */
        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (!player.library.libraryIsValid())
                {
                    player.library.addMusicFolder(FolderBrowser.SelectedPath);
                    updateSongTable();
                    player.selectSong(0);
                }
                else
                {
                    player.library.addMusicFolder(FolderBrowser.SelectedPath);
                    updateSongTable();
                }
            }
        }

        /* Prompts the user to select a music file and adds it to the music libraray if  it is a valid music file. 
         * If the library does not have music in it yet, it will also set the song to play to the first in the library. */
        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FileBrowser.ShowDialog() == DialogResult.OK)
            {
                if (!player.library.libraryIsValid())
                {
                    player.library.addMusicFile(FileBrowser.FileName);
                    updateSongTable();
                    player.selectSong(0);
                }
                else
                {
                    player.library.addMusicFile(FileBrowser.FileName);
                    updateSongTable();
                }
            }
        }

        /* Changes the current track time that is being displayed as the user scrolls the time bar. */
        private void TimeBar_Scroll(object sender, EventArgs e)
        {
            displayTime(TimeBar.Value, CurrentTime);
        }

        /* Runs every second that SongTimer is enabled. Updates the time bar slider by 1 every time it runs to emulate the idea of 
         * it ticking up every second. If the slider passes the total song time it plays the next song and updates all 
         * neccessary information. */
        private void SongTimer_Tick(object sender, EventArgs e)
        {
            // Only move the scroll bar if the player is not pasued
            if (!player.IsPaused)
            {
                TimeBar.Value += 1;
            }

            // Move to the next song if the slider is at the end of the song otherwise we just update 
            // the currently displayed time.
            if (TimeBar.Value >= player.song.TimeInSeconds)
            {
                player.playNextSong();
                updateDisplay();
            }
            else
            {
                displayTime(TimeBar.Value, CurrentTime);
            }
        }

        /* Changes the posistion of the currently playing song to the spot the user moves the slider. If the user lets
         * go of the slider at the end of the song the player will move to the next song and update all necessary data.
         * Only runs when the user lets go of click to stop errors like moving through multiple songs on accident.  */
        private void TimeBar_MouseUp(object sender, EventArgs e)
        {
            // Restart the timer so the tick event runs to update the time for the next song
            SongTimer.Start();

            // Changes the posistion of the song to the slider location value
            player.Time = TimeBar.Value;

            // Changes to the next song if the slider is at the end of the track bar
            if (TimeBar.Value >= player.song.TimeInSeconds)
            {
                player.playNextSong();
                updateDisplay();
            }
        }

        /* Stops the timer while moving the slider around the track bar so we don't accidentaly tick to a new song. */
        private void TimeBar_MouseDown(object sender, EventArgs e)
        {
            SongTimer.Stop();
        }

        /* Sets the music player to shuffle mode. This does not work well with music loaded from a database. I will be working on it
         * more when I add the ability to load music to memory. */
        private void Shuffle_Click(object sender, EventArgs e)
        {
            player.Shuffle = !player.Shuffle;

            if (player.Shuffle)
                Shuffle.Text = "Shuffle: on";
            else
                Shuffle.Text = "Shuffle: off";
        }
        #endregion

        // Private Methods
        #region Private Methods
        
        /* Creates the table that will hold all of the song data and fills it with the data. */
        private void createSongTable()
        {
            // Columns
            songTable.Columns.Add("SongName", "Song");
            songTable.Columns.Add("ArtistName", "Artist");
            songTable.Columns.Add("AlbumName", "Album");

            // Rows
            songTable.Columns["SongName"].Width = songTable.Width / songTable.Columns.Count;
            songTable.Columns["ArtistName"].Width = songTable.Width / songTable.Columns.Count;
            songTable.Columns["AlbumName"].Width = songTable.Width / songTable.Columns.Count;

            // Add the music data
            updateSongTable();
        }

        /* Fills the table with all the music data from the music library. */
        private void updateSongTable()
        {
            for (int i = 0; i <= player.library.getNumOfSongs(); i++)
            {
                // Create a new row
                songTable.Rows.Add();

                // Add data to each column of the new row
                songTable.Rows[i].Cells["SongName"].Value = MetadataHandler.getTitle(player.library.getSongPath(i));
                songTable.Rows[i].Cells["ArtistName"].Value = MetadataHandler.getArtist(player.library.getSongPath(i));
                songTable.Rows[i].Cells["AlbumName"].Value = MetadataHandler.getAlbum(player.library.getSongPath(i));
            }
        }

        /* Displays the song info for the currently playing song and sets the data to the values needed to work properly */
        private void updateDisplay()
        {
            displayData();
            resetTimeBarData();

            // Set the currently selected cell
            songTable.CurrentCell = songTable.Rows[player.song.Index].Cells["SongName"];
        }

        /* Updates all the UI elements */
        private void displayData()
        {
            // Display the name of the current playing song to screen
            SongName.Text = player.song.Name;

            // Display artist's name
            ArtistName.Text = player.song.Artist;

            // Display album art
            albumArt.Image = player.song.AlbumArt;

            // Display song length
            displayTime(player.song.TimeInSeconds, Time);

            // Set timebar slider to the songs current time
            TimeBar.Value = (int)player.Time;

            // Display the current time
            displayTime((int)player.Time, CurrentTime);
        }

        /* Resets the timerbar data to a useable state/ */
        private void resetTimeBarData()
        {
            // Sets the maximum time to the current song's total timer=
            TimeBar.Maximum = player.song.TimeInSeconds;

            // Sets the time bar to 0
            TimeBar.Value = 0;

            // Displays the normalized current time
            displayTime(TimeBar.Value, CurrentTime);
        }

        /* Splits timeInSeconds to minutes and seconds and sets label to the the result with a colon
         * seperating minutes and seconds. If seconds is less than 9 we add a 0 to front of the seconds
         * so we always print a "normal" looking time. */
        private void displayTime(int timeInSeconds, Label label)
        {
            // Convert to minutes and seconds
            int minutes = timeInSeconds / 60;
            int seconds = timeInSeconds % 60;

            // Display normalized time
            if (seconds < 10)
                label.Text = minutes.ToString() + ":0" + seconds.ToString();
            else
                label.Text = minutes.ToString() + ":" + seconds.ToString();
        }
        #endregion
    }
}
