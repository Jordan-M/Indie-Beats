using System;
using System.IO;
using System.Data.SQLite;

namespace IndieBeats_WFA
{
    class MusicLibrary
    {
        // Instance variables
        SQLiteConnection library = null;

        // Constructor
        public MusicLibrary()
        {

        }

        public void createLibraryDatabase(string libraryName)
        {
            if (!File.Exists(libraryName))
            {
                SQLiteConnection.CreateFile(libraryName);
                loadLibrary(libraryName);
                string sql = "create table songPaths (path text)";
                SQLiteCommand command = new SQLiteCommand(sql, library);
                command.ExecuteNonQuery(); 
            }
                 
        }

        public void loadLibrary(string libraryName)
        {
            if (!File.Exists(libraryName))
            {
                throw new FileNotFoundException("Database not found!");
            }
            if (library == null)
            {
                library = new SQLiteConnection("Data Source=" + libraryName + "; Version=3;");
                library.Open();
            }
        }

        public void addMusicFolder(string folderPath)
        {
            string [] files = Directory.GetFiles(folderPath);


            for (int i = files.Length - 1; i >= 0; i--)
            {
                SQLiteCommand sql = new SQLiteCommand("insert into songPaths (path) values (?)", library);
                sql.Parameters.AddWithValue("path", files[i]);
                sql.ExecuteNonQuery();
            }
        }

        public void addMusicFile(string filePath)
        {
            SQLiteCommand sql = new SQLiteCommand("insert into songPaths (path) values (?)", library);
            sql.Parameters.AddWithValue("path", filePath);
            sql.ExecuteNonQuery();
        }


        public string getSongPath(int songNumber)
        {
            string sql = "select * from songPaths limit 1 offset " + songNumber;
            SQLiteCommand command = new SQLiteCommand(sql, library);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string test = reader["path"].ToString();
                return reader["path"].ToString();
            }
            reader.Close();
            return "Invalid Song Path!";
        }

        public int getNumOfSongs()
        {
            string sql = "select count(path) from songPaths";
            SQLiteCommand command = new SQLiteCommand(sql, library);

            return Convert.ToInt32(command.ExecuteScalar()) - 1;
        }

        public bool libraryIsValid()
        {
            if (getSongPath(0) != "Invalid Song Path!")
                return true;
            return false;
        }
    }
}
