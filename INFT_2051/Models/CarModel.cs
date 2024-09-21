
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace INFT_2051.Models
{
    [Table("cars")]
    public class CarModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //NamePage
        //This is how getters and setters are specified in C#
        [MaxLength(260)]
        public string Name { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string AlbumName { get; set; }

        public string Location { get; set; }

        public string ImageFilePath { get; set; }
       


    }
}
