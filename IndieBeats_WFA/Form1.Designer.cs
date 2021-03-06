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
            this.components = new System.ComponentModel.Container();
            this.pausePlay = new System.Windows.Forms.Button();
            this.nextSong = new System.Windows.Forms.Button();
            this.previousSong = new System.Windows.Forms.Button();
            this.SongName = new System.Windows.Forms.Label();
            this.CurrentVolume = new System.Windows.Forms.Label();
            this.VolumeSlider = new System.Windows.Forms.TrackBar();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMusicSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.songTable = new System.Windows.Forms.DataGridView();
            this.albumArt = new System.Windows.Forms.PictureBox();
            this.ArtistName = new System.Windows.Forms.Label();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.Time = new System.Windows.Forms.Label();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.SongTimer = new System.Windows.Forms.Timer(this.components);
            this.Shuffle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pausePlay
            // 
            this.pausePlay.Location = new System.Drawing.Point(76, 548);
            this.pausePlay.Name = "pausePlay";
            this.pausePlay.Size = new System.Drawing.Size(58, 45);
            this.pausePlay.TabIndex = 0;
            this.pausePlay.Text = "Play";
            this.pausePlay.UseVisualStyleBackColor = true;
            this.pausePlay.Click += new System.EventHandler(this.pausePlay_Click);
            // 
            // nextSong
            // 
            this.nextSong.Location = new System.Drawing.Point(140, 548);
            this.nextSong.Name = "nextSong";
            this.nextSong.Size = new System.Drawing.Size(58, 45);
            this.nextSong.TabIndex = 1;
            this.nextSong.Text = "Next Song";
            this.nextSong.UseVisualStyleBackColor = true;
            this.nextSong.Click += new System.EventHandler(this.nextSong_Click);
            // 
            // previousSong
            // 
            this.previousSong.Location = new System.Drawing.Point(12, 548);
            this.previousSong.Name = "previousSong";
            this.previousSong.Size = new System.Drawing.Size(58, 45);
            this.previousSong.TabIndex = 2;
            this.previousSong.Text = "Previous Song";
            this.previousSong.UseVisualStyleBackColor = true;
            this.previousSong.Click += new System.EventHandler(this.previousSong_Click);
            // 
            // SongName
            // 
            this.SongName.AutoSize = true;
            this.SongName.Location = new System.Drawing.Point(12, 512);
            this.SongName.Name = "SongName";
            this.SongName.Size = new System.Drawing.Size(33, 13);
            this.SongName.TabIndex = 4;
            this.SongName.Text = "None";
            // 
            // CurrentVolume
            // 
            this.CurrentVolume.AutoSize = true;
            this.CurrentVolume.Location = new System.Drawing.Point(927, 487);
            this.CurrentVolume.Name = "CurrentVolume";
            this.CurrentVolume.Size = new System.Drawing.Size(25, 13);
            this.CurrentVolume.TabIndex = 6;
            this.CurrentVolume.Text = "100";
            // 
            // VolumeSlider
            // 
            this.VolumeSlider.Location = new System.Drawing.Point(907, 480);
            this.VolumeSlider.Maximum = 100;
            this.VolumeSlider.Name = "VolumeSlider";
            this.VolumeSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VolumeSlider.Size = new System.Drawing.Size(45, 113);
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
            this.MenuStrip.Size = new System.Drawing.Size(964, 24);
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
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.fileToolStripMenuItem1.Text = "File";
            this.fileToolStripMenuItem1.Click += new System.EventHandler(this.fileToolStripMenuItem1_Click);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // FileBrowser
            // 
            this.FileBrowser.Filter = "MP3|*.mp3|MP2|*.mp2|MP1|*.mp1|OGG|*.ogg|WAV|*.wav|AIFF|*.AIFF|All Files|*.*";
            // 
            // songTable
            // 
            this.songTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.songTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.songTable.Location = new System.Drawing.Point(12, 27);
            this.songTable.Name = "songTable";
            this.songTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.songTable.Size = new System.Drawing.Size(940, 328);
            this.songTable.TabIndex = 9;
            // 
            // albumArt
            // 
            this.albumArt.Location = new System.Drawing.Point(15, 367);
            this.albumArt.Name = "albumArt";
            this.albumArt.Size = new System.Drawing.Size(142, 142);
            this.albumArt.TabIndex = 10;
            this.albumArt.TabStop = false;
            // 
            // ArtistName
            // 
            this.ArtistName.AutoSize = true;
            this.ArtistName.Location = new System.Drawing.Point(12, 532);
            this.ArtistName.Name = "ArtistName";
            this.ArtistName.Size = new System.Drawing.Size(33, 13);
            this.ArtistName.TabIndex = 11;
            this.ArtistName.Text = "None";
            // 
            // TimeBar
            // 
            this.TimeBar.Location = new System.Drawing.Point(268, 548);
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(633, 45);
            this.TimeBar.TabIndex = 12;
            this.TimeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TimeBar.Scroll += new System.EventHandler(this.TimeBar_Scroll);
            this.TimeBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeBar_MouseDown);
            this.TimeBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimeBar_MouseUp);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(871, 569);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(30, 13);
            this.Time.TabIndex = 13;
            this.Time.Text = "Time";
            // 
            // CurrentTime
            // 
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Location = new System.Drawing.Point(269, 569);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(28, 13);
            this.CurrentTime.TabIndex = 14;
            this.CurrentTime.Text = "0:00";
            // 
            // SongTimer
            // 
            this.SongTimer.Interval = 1000;
            this.SongTimer.Tick += new System.EventHandler(this.SongTimer_Tick);
            // 
            // Shuffle
            // 
            this.Shuffle.Location = new System.Drawing.Point(204, 548);
            this.Shuffle.Name = "Shuffle";
            this.Shuffle.Size = new System.Drawing.Size(58, 45);
            this.Shuffle.TabIndex = 15;
            this.Shuffle.Text = "Shuffle: Off";
            this.Shuffle.UseVisualStyleBackColor = true;
            this.Shuffle.Click += new System.EventHandler(this.Shuffle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 605);
            this.Controls.Add(this.Shuffle);
            this.Controls.Add(this.CurrentTime);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.ArtistName);
            this.Controls.Add(this.albumArt);
            this.Controls.Add(this.songTable);
            this.Controls.Add(this.CurrentVolume);
            this.Controls.Add(this.SongName);
            this.Controls.Add(this.previousSong);
            this.Controls.Add(this.nextSong);
            this.Controls.Add(this.pausePlay);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.VolumeSlider);
            this.Controls.Add(this.TimeBar);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pausePlay;
        private System.Windows.Forms.Button nextSong;
        private System.Windows.Forms.Button previousSong;
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
        private System.Windows.Forms.DataGridView songTable;
        private System.Windows.Forms.PictureBox albumArt;
        private System.Windows.Forms.Label ArtistName;
        private System.Windows.Forms.TrackBar TimeBar;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label CurrentTime;
        private System.Windows.Forms.Timer SongTimer;
        private System.Windows.Forms.Button Shuffle;
    }
}

