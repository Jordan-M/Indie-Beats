using System;
using System.Drawing;
using System.IO;

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

        public static Image getAlbumArt(string filePath)
        {
            TagLib.File info = TagLib.File.Create(filePath);
            
            if (info.Tag.Pictures.Length >= 1)
            {
                var bin = (byte[])(info.Tag.Pictures[0].Data.Data);
                return Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(100, 100, null, IntPtr.Zero);
            }

            return Image.FromFile("..\\..\\..\\Images\\album_not_found.jpg").GetThumbnailImage(100, 100, null, IntPtr.Zero);
        }
    }
}
