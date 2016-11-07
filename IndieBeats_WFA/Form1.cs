using System;
using System.IO;
using System.Windows.Forms;

namespace IndieBeats_WFA
{
    public partial class Form1 : Form
    {
        private MediaPlayer player;

        public Form1()
        {
            InitializeComponent();
            
            try
            {
                player = new MediaPlayer();
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }


            createSongTable();

            displayData();
            resetTimeBarData();
        }

        private void pausePlay_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Pause or play the audio file
                player.pausePlay();

                // Display the song properties to screen
                displayData();

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

        private void previousSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play the previous audio file
                player.playPreviousSong();
                displayData();
                resetTimeBarData();
                songTable.CurrentCell = songTable.Rows[player.song.Index].Cells["SongName"];
            }

        }

        private void nextSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play next audio file
                player.playNextSong();
                displayData();
                resetTimeBarData();
                songTable.CurrentCell = songTable.Rows[player.song.Index].Cells["SongName"];
            }
        }

        private void volumeSlider_Scroll(object sender, EventArgs e)
        {
            player.CurrentVolume = VolumeSlider.Value;
            this.CurrentVolume.Text = player.CurrentVolume.ToString();
        }

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

        private void createSongTable()
        {
            songTable.Columns.Add("SongName", "Song");
            songTable.Columns.Add("ArtistName", "Artist");
            songTable.Columns.Add("AlbumName", "Album");

            songTable.Columns["SongName"].Width = songTable.Width / songTable.Columns.Count;
            songTable.Columns["ArtistName"].Width = songTable.Width / songTable.Columns.Count;
            songTable.Columns["AlbumName"].Width = songTable.Width / songTable.Columns.Count;

            updateSongTable();
        }

        private void updateSongTable()
        {
            for (int i = 0; i <= player.library.getNumOfSongs(); i++)
            {
                songTable.Rows.Add();
                songTable.Rows[i].Cells["SongName"].Value = MetadataHandler.getTitle(player.library.getSongPath(i));
                songTable.Rows[i].Cells["ArtistName"].Value = MetadataHandler.getArtist(player.library.getSongPath(i));
                songTable.Rows[i].Cells["AlbumName"].Value = MetadataHandler.getAlbum(player.library.getSongPath(i));
            }
        }

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

            // Set timebar to the songs current time
            TimeBar.Value = (int)player.Time;

            // Display thee current time
            displayTime((int)player.Time, CurrentTime);
        }

        private void resetTimeBarData()
        {
            TimeBar.Maximum = player.song.TimeInSeconds;
            TimeBar.Value = 0;
            displayTime(TimeBar.Value, CurrentTime);
        }

        private void TimeBar_Scroll(object sender, EventArgs e)
        {
            displayTime(TimeBar.Value, CurrentTime);
        }

        private void SongTimer_Tick(object sender, EventArgs e)
        {   
            if (!player.IsPaused)
            {
                TimeBar.Value += 1;
            }

            if (TimeBar.Value >= player.song.TimeInSeconds)
            {
                player.playNextSong();
                resetTimeBarData();
                displayData();
            }
            else
            {
                displayTime(TimeBar.Value, CurrentTime);
            }
        }

        private void TimeBar_MouseUp(object sender, EventArgs e)
        {
            SongTimer.Start();
            player.Time = TimeBar.Value;

            if (TimeBar.Value >= player.song.TimeInSeconds)
            {
                player.playNextSong();
                resetTimeBarData();
                displayData();
                songTable.CurrentCell = songTable.Rows[player.song.Index].Cells["SongName"];
            }
        }

        private void TimeBar_MouseDown(object sender, EventArgs e)
        {
            SongTimer.Stop();
        }

        private void displayTime(int timeInSeconds, Label label)
        {
            int minutes = timeInSeconds / 60;
            int seconds = timeInSeconds % 60;

            if (seconds < 10)
                label.Text = minutes.ToString() + ":0" + seconds.ToString();
            else
                label.Text = minutes.ToString() + ":" + seconds.ToString();
        }

        private void Shuffle_Click(object sender, EventArgs e)
        {
            player.Shuffle = !player.Shuffle;

            if (player.Shuffle)
                Shuffle.Text = "Shuffle: on";
            else
                Shuffle.Text = "Shuffle: off";
        }
    }
}
