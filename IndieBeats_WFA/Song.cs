using System.Drawing;


namespace IndieBeats_WFA
{
    class Song
    {
        string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string artist;
        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        string album;
        public string Album
        {
            get { return album; }
            set { album = value; }
        }

        Image albumArt;
        public Image AlbumArt
        {
            get { return albumArt; }
            set { albumArt = value; }
        }
    }
}
