using System;

// We use TagLib here instead of Un4seen.Bass so we dont have to pass around a stream, 
// we can get the file info with just a path.
using TagLib;

namespace IndieBeats_WFA
{
    class MetadataHandler
    {
        public MetadataHandler()
        {

        }

        public static string getAlbum(string filePath)
        {
            TagLib.File info = TagLib.File.Create(filePath);
            return info.Tag.Album;
        }

        public static string getTitle(string filePath)
        {
            TagLib.File info = TagLib.File.Create(filePath);
            return info.Tag.Title;
        }

        public static string getArtist(string filePath)
        {
            TagLib.File info = TagLib.File.Create(filePath);
            return info.Tag.FirstAlbumArtist;
        }

        public static string getComment(string filePath)
        {
            TagLib.File info = TagLib.File.Create(filePath);
            return info.Tag.Comment;
        }

        public static string getYear(string filePath)
        {
            TagLib.File info = TagLib.File.Create(filePath);
            return info.Tag.Year.ToString();
        }

    }
}
