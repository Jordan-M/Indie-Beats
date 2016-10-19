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

            player = new MediaPlayer("C:\\Users\\Jordan\\Music\\New Soundcloud");
        }

        private void pausePlay_Click(object sender, EventArgs e)
        {
            // Play the audio file
            player.pausePlay();

            // Display the name of the current playing song to screen
            this.SongName.Text = player.CurrentSongName;

        }

        private void previousSong_Click(object sender, EventArgs e)
        {
            // Play the previous audio file
            player.playPreviousSong();

            // Display the name of the new audio file to screen
            this.SongName.Text = player.CurrentSongName;
        }

        private void nextSong_Click(object sender, EventArgs e)
        {
            player.playNextSong();
            this.SongName.Text = player.CurrentSongName;
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
                string library = FolderBrowser.SelectedPath;
            }
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FileBrowser.ShowDialog() == DialogResult.OK)
            {
                string library = FolderBrowser.SelectedPath;
            }
        }
    }
}
