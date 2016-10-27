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

                if (pausePlay.Text == "Play")
                    pausePlay.Text = "Pause";
                else
                    pausePlay.Text = "Play";
            }
        }

        private void previousSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                // Play the previous audio file
                player.playPreviousSong();

                // Display the name of the new audio file to screen
                this.SongName.Text = MetadataHandler.getTitle(player.CurrentSongPath);
            }

        }

        private void nextSong_Click(object sender, EventArgs e)
        {
            if (player.library.libraryIsValid())
            {
                player.playNextSong();
                this.SongName.Text = MetadataHandler.getTitle(player.CurrentSongPath);
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
                songTable.Rows.Add(player.library.getSongPath(i));
            }
        }


    }
}
