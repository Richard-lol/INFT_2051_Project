using INFT_2051.Models;
using INFT_2051.Services;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace INFT_2051.ViewModels
{
    internal class CharacterViewModel : ObservableObject
    {
        public static CharacterViewModel Current { get; set; }

        SQLiteConnection connection;

        public CharacterViewModel()
        {
            Current = this;
            
        }

        public List<CharacterModel> Characters
        {
            get
            {
                return connection.GetAllWithChildren<CharacterModel>();
            }
        }

        public void SaveCharacter(CharacterModel model)
        {
            //If it has an Id, then it already exists and we can update it
            if (model.Id > 0)
            {
                connection.Update(model);
            }
            //If not, it's new and we need to add it
            else
            {
                connection.Insert(model);
            }

           
        }

        public void DeleteCharacter(CharacterModel model)
        {
            //If it has an Id, then we can delete it
            if (model.Id > 0)
            {
                connection.Delete(model);
            }
        }
    }
}
