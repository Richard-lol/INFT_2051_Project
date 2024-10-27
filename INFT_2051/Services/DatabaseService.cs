
using SQLite;
using INFT_2051.Models;

namespace INFT_2051.Services
{
    internal static class DatabaseService
    {
        private static string _databaseFile;
        private static string DatabaseFile
        {
            get
            {
                if (_databaseFile == null)
                {
                    string databaseDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "data");
                    System.IO.Directory.CreateDirectory(databaseDir);

                    _databaseFile = Path.Combine(databaseDir, "character_data.sqlite");
                }
                return _databaseFile;
            }
        }

        private static SQLiteConnection _connection;
        public static SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(DatabaseFile);
                    _connection.CreateTable<CarModel>();
                  

                }
                return _connection;
            }
        }
    }
}
