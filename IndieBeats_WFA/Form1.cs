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
        }

        private void pausePlay_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play the audio file
                player.pausePlay();

                // Display the name of the current playing song to screen
                this.SongName.Text = MetadataHandler.getTitle(player.CurrentSongPath);

                // Display artist's name
                ArtistName.Text = MetadataHandler.getArtist(player.CurrentSongPath);

                // Display album art
                albumArt.Image = MetadataHandler.getAlbumArt((player.CurrentSongPath), 142, 142);

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

                // Display the name of the new audio file to screen
                SongName.Text = MetadataHandler.getTitle(player.CurrentSongPath);

                // Display artist's name
                ArtistName.Text = MetadataHandler.getArtist(player.CurrentSongPath);

                // Display the album art to screen
                albumArt.Image = MetadataHandler.getAlbumArt((player.CurrentSongPath), 142, 142);
            }

        }

        private void nextSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play next audio file
                player.playNextSong();

                // Display the name of the new audio file
                SongName.Text = MetadataHandler.getTitle(player.CurrentSongPath);

                // Display artist's name
                ArtistName.Text = MetadataHandler.getArtist(player.CurrentSongPath);

                // Display the album are of the new file
                albumArt.Image = MetadataHandler.getAlbumArt((player.CurrentSongPath), 142, 142);
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
            songTable.Columns.Add("SongName", "Song Name");
            songTable.Columns["SongName"].Width = songTable.Width;
            updateSongTable();
        }

        private void updateSongTable()
        {
            for (int i = 0; i <= player.library.getNumOfSongs(); i++)
            {
                songTable.Rows.Add(MetadataHandler.getTitle(player.library.getSongPath(i)));
            }
        }


    }
}
