using System.Drawing;


namespace IndieBeats_WFA
{
    class Song
    {
        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string artist;
        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        private string album;
        public string Album
        {
            get { return album; }
            set { album = value; }
        }

        private Image albumArt;
        public Image AlbumArt
        {
            get { return albumArt; }
            set { albumArt = value; }
        }

        private int minutes;
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        private int seconds;
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        private int timeInSeconds;
        public int TimeInSeconds
        {
            get { return timeInSeconds; }
            set { timeInSeconds = value; }
        }
    }
}
