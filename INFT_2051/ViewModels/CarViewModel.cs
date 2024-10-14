using INFT_2051.Models;
using INFT_2051.Services;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace INFT_2051.ViewModels
{
    internal class CarViewModel : ObservableObject
    {
        public static CarViewModel Current { get; set; }

        SQLiteConnection connection;

        public CarViewModel()
        {
            Current = this;
            connection = DatabaseService.Connection;
        }

        public List<CarModel> Cars
        {
            get
            {
                return connection.GetAllWithChildren<CarModel>();
            }


        }

        public void SaveCar(CarModel model)
        {
            if (connection == null)
            {
                throw new NullReferenceException("Database connection is not initialized.");
            }

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

        public void DeleteCar(CarModel model)
        {
            //If it has an Id, then we can delete it
            if (model.Id > 0)
            {
                connection.Delete(model);
            }
        }
        
    }
}
