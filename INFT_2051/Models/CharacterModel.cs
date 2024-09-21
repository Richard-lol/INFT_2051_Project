
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace INFT_2051.Models
{
    [Table("characters")]
    public class CharacterModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //NamePage
        //This is how getters and setters are specified in C#
        [MaxLength(260)]
        public string Name { get; set; }
        public string Class { get; set; }
        public int HPTotal { get; set; } = 1;
        public int HPCurrent { get; set; }
        public double HPPercent
        {
            get
            {
                return (double)HPCurrent / HPTotal;
            }
        }

        public int Iniative { get; set; }
        public int Speed { get; set; }
        public int Inspiration { get; set; }
        public bool DeathSave1 { get; set; }
        public bool DeathSave2 { get; set; }
        public bool DeathSave3 { get; set; }

        public string ImageFilePath { get; set; }

        //StatsPage
        public int StatStrength { get; set; }
        public int StatDexterity { get; set; }
        public int StatConstitution { get; set; }
        public int StatIntelligence { get; set; }
        public int StatWisdom { get; set; }
        public int StatCharisma { get; set; }

        //TraitsPage
        public string TraitPersonality { get; set; }
        public string TraitIdeals { get; set; }
        public string TraitBonds { get; set; }
        public string TraitFlaws { get; set; }

    
       


    }
}
