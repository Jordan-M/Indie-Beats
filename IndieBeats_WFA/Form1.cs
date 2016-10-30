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

            player = new MediaPlayer();

            createSongTable();

            displayData();
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
                    pausePlay.Text = "Play";
                else
                    pausePlay.Text = "Pause";
            }
        }

        private void previousSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play the previous audio file
                player.playPreviousSong();
                displayData();
            }

        }

        private void nextSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play next audio file
                player.playNextSong();
                displayData();
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
        }


    }
}
