﻿namespace IndieBeats_WFA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pausePlay = new System.Windows.Forms.Button();
            this.nextSong = new System.Windows.Forms.Button();
            this.previousSong = new System.Windows.Forms.Button();
            this.currentlyPlaying = new System.Windows.Forms.Label();
            this.SongName = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.CurrentVolume = new System.Windows.Forms.Label();
            this.VolumeSlider = new System.Windows.Forms.TrackBar();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMusicSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileBrowser = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pausePlay
            // 
            this.pausePlay.Location = new System.Drawing.Point(137, 227);
            this.pausePlay.Name = "pausePlay";
            this.pausePlay.Size = new System.Drawing.Size(119, 45);
            this.pausePlay.TabIndex = 0;
            this.pausePlay.Text = "Pause/Play";
            this.pausePlay.UseVisualStyleBackColor = true;
            this.pausePlay.Click += new System.EventHandler(this.pausePlay_Click);
            // 
            // nextSong
            // 
            this.nextSong.Location = new System.Drawing.Point(261, 227);
            this.nextSong.Name = "nextSong";
            this.nextSong.Size = new System.Drawing.Size(119, 45);
            this.nextSong.TabIndex = 1;
            this.nextSong.Text = "Next Song";
            this.nextSong.UseVisualStyleBackColor = true;
            this.nextSong.Click += new System.EventHandler(this.nextSong_Click);
            // 
            // previousSong
            // 
            this.previousSong.Location = new System.Drawing.Point(12, 227);
            this.previousSong.Name = "previousSong";
            this.previousSong.Size = new System.Drawing.Size(119, 45);
            this.previousSong.TabIndex = 2;
            this.previousSong.Text = "Previous Song";
            this.previousSong.UseVisualStyleBackColor = true;
            this.previousSong.Click += new System.EventHandler(this.previousSong_Click);
            // 
            // currentlyPlaying
            // 
            this.currentlyPlaying.AutoSize = true;
            this.currentlyPlaying.Location = new System.Drawing.Point(9, 39);
            this.currentlyPlaying.Name = "currentlyPlaying";
            this.currentlyPlaying.Size = new System.Drawing.Size(88, 13);
            this.currentlyPlaying.TabIndex = 3;
            this.currentlyPlaying.Text = "Currently Playing:";
            // 
            // SongName
            // 
            this.SongName.AutoSize = true;
            this.SongName.Location = new System.Drawing.Point(98, 39);
            this.SongName.Name = "SongName";
            this.SongName.Size = new System.Drawing.Size(33, 13);
            this.SongName.TabIndex = 4;
            this.SongName.Text = "None";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(15, 62);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(82, 13);
            this.volumeLabel.TabIndex = 5;
            this.volumeLabel.Text = "Current Volume:";
            // 
            // CurrentVolume
            // 
            this.CurrentVolume.AutoSize = true;
            this.CurrentVolume.Location = new System.Drawing.Point(106, 62);
            this.CurrentVolume.Name = "CurrentVolume";
            this.CurrentVolume.Size = new System.Drawing.Size(25, 13);
            this.CurrentVolume.TabIndex = 6;
            this.CurrentVolume.Text = "100";
            // 
            // VolumeSlider
            // 
            this.VolumeSlider.Location = new System.Drawing.Point(12, 78);
            this.VolumeSlider.Maximum = 100;
            this.VolumeSlider.Name = "VolumeSlider";
            this.VolumeSlider.Size = new System.Drawing.Size(368, 45);
            this.VolumeSlider.TabIndex = 7;
            this.VolumeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeSlider.Value = 100;
            this.VolumeSlider.Scroll += new System.EventHandler(this.volumeSlider_Scroll);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(392, 24);
            this.MenuStrip.TabIndex = 8;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMusicSourceToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addMusicSourceToolStripMenuItem
            // 
            this.addMusicSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.folderToolStripMenuItem});
            this.addMusicSourceToolStripMenuItem.Name = "addMusicSourceToolStripMenuItem";
            this.addMusicSourceToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addMusicSourceToolStripMenuItem.Text = "Add Music Source";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.fileToolStripMenuItem1.Text = "File";
            this.fileToolStripMenuItem1.Click += new System.EventHandler(this.fileToolStripMenuItem1_Click);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // FileBrowser
            // 
            this.FileBrowser.Filter = "MP3|*.mp3|MP2|*.mp2|MP1|*.mp1|OGG|*.ogg|WAV|*.wav|AIFF|*.AIFF|All Files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 313);
            this.Controls.Add(this.VolumeSlider);
            this.Controls.Add(this.CurrentVolume);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.SongName);
            this.Controls.Add(this.currentlyPlaying);
            this.Controls.Add(this.previousSong);
            this.Controls.Add(this.nextSong);
            this.Controls.Add(this.pausePlay);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pausePlay;
        private System.Windows.Forms.Button nextSong;
        private System.Windows.Forms.Button previousSong;
        private System.Windows.Forms.Label currentlyPlaying;
        private System.Windows.Forms.Label volumeLabel;
        internal System.Windows.Forms.Label SongName;
        internal System.Windows.Forms.Label CurrentVolume;
        internal System.Windows.Forms.TrackBar VolumeSlider;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMusicSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog FileBrowser;
    }
}
