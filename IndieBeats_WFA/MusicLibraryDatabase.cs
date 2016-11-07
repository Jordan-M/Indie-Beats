using System;
using System.IO;
using System.Data.SQLite;

namespace IndieBeats_WFA
{
    class MusicLibraryDatabase
    {
        // Instance variables
        SQLiteConnection library = null;

        // Properties
        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        // Constructor
        public MusicLibraryDatabase()
        {

        }

        /* Creates a database file with a text table tableName */
        public void createLibraryDatabase(string libraryName)
        {
            if (!File.Exists(libraryName))
            {
                SQLiteConnection.CreateFile(libraryName);
            }    
        }

        /* Adds a new table table to the database */
        public void addLibraryTable(string table)
        {
            string sql = "create table " + table + " (path text)";
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, library);
                command.ExecuteNonQuery();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch(SQLiteException ex)
            {
               
            }

        }

        /* Loads a database file */
        public void loadLibrary(string libraryName)
        {
            if (!File.Exists(libraryName))
            {
                throw new FileNotFoundException("Database not found!");
            }
            if (library == null)
            {
                try
                {
                    library = new SQLiteConnection("Data Source=" + libraryName + "; Version=3;");
                    library.Open();
                }
                catch (DllNotFoundException)
                {
                    throw new DllNotFoundException();
                }
                catch (BadImageFormatException)
                {
                    throw new BadImageFormatException();
                }
            }
        }

        /* Adds all the valid music file paths to table tableName in the database */
        public void addMusicFolder(string folderPath)
        {
            string [] files = Directory.GetFiles(folderPath);


            for (int i = files.Length - 1; i >= 0; i--)
            {
                if (fileIsValid(files[i]))
                {
                    SQLiteCommand sql = new SQLiteCommand("insert into " + tableName + "(path) values (?)", library);
                    sql.Parameters.AddWithValue("path", files[i]);
                    sql.ExecuteNonQuery();
                }
            }
        }

        /* Adds the file filePath if it is a valid music file to the table tableName in the database*/
        public void addMusicFile(string filePath)
        {
            if (fileIsValid(filePath))
            {
                SQLiteCommand sql = new SQLiteCommand("insert into " + tableName + "(path) values (?)", library);
                sql.Parameters.AddWithValue("path", filePath);
                sql.ExecuteNonQuery();
            }
        }

        /* Retruns the song path of the song at index songNumber in the database */
        public string getSongPath(int songNumber)
        {
            string sql = "select * from " + tableName + " limit 1 offset " + songNumber;
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

        /* Returns the number of songs in the database */
        public int getNumOfSongs()
        {
            string sql = "select count(path) from " + TableName;
            SQLiteCommand command = new SQLiteCommand(sql, library);

            return Convert.ToInt32(command.ExecuteScalar()) - 1;
        }

        /* Checks to see if there is a song in index 0 of the database 
         * this confirms the database has music in it */
        public bool libraryIsValid()
        {
            if (getSongPath(0) != "Invalid Song Path!")
                return true;
            return false;
        }

        /* Checks to see if file is one of the file types the Bass API can handle. Returns true if it is. */
        private bool fileIsValid(string file)
        {
            if (new FileInfo(file).Length > 0)
            {
                string[] allowedTypes = new string[6]{".mp3", ".mp2", ".mp1", ".ogg", ".wav", ".aiff"};

                for (int i = 0; i < allowedTypes.Length; i++)
                {
                    if (Path.GetExtension(file) == allowedTypes[i])
                        return true;
                }
            }
            return false;
        }
    }
}
