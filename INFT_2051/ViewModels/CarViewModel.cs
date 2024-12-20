﻿using INFT_2051.Models;
using INFT_2051.Services;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Collections.ObjectModel;


namespace INFT_2051.ViewModels
{
    public class CarViewModel : ObservableObject
    {
        public static CarViewModel Current { get; set; }

        SQLiteConnection connection;

        public CarViewModel()
        {
            Current = this;
            connection = DatabaseService.Connection;

            Makes = Cars.Select(car => car.Make).Distinct().ToList();
            Makes.Insert(0, "All");
            Names = Cars.Select(car => car.Name).Distinct().ToList();
            Names.Insert(0, "All");
            Albums = Cars.Select(car => car.AlbumName).Distinct().ToList();
            Albums.Insert(0, "All");
            Locations = Cars.Select(car => car.Location).Distinct().ToList();
            Locations.Insert(0, "All");

            SelectedMake = "All";
            SelectedName = "All";
            SelectedAlbum = "All";
            SelectedLocation = "All";

            FilteredCars = new ObservableCollection<CarModel>(Cars);

        }

        public List<CarModel> Cars
        {
            get
            {
                return connection.GetAllWithChildren<CarModel>();
            }

        }
    

        private ObservableCollection<CarModel> filteredCars;
        public ObservableCollection<CarModel> FilteredCars
        {
            get => filteredCars;
            set
            {
                filteredCars = value;
                OnPropertyChanged(nameof(FilteredCars));
            }
        }

   
        public List<string> Makes { get; private set; }
        public List<string> Names { get; private set; }
        public List<string> Albums { get; private set; }
        public List<string> Locations { get; private set; }


  
        private string selectedMake;
        public string SelectedMake
        {
            get => selectedMake;
            set
            {
                selectedMake = value;
                OnPropertyChanged(nameof(SelectedMake));
                ApplyFilters();
            }
        }

        private string selectedName;
        public string SelectedName
        {
            get => selectedName;
            set
            {
                selectedName = value;
                OnPropertyChanged(nameof(SelectedName));
                ApplyFilters();
            }
        }

        private string selectedAlbum;
        public string SelectedAlbum
        {
            get => selectedAlbum;
            set
            {
                selectedAlbum = value;
                OnPropertyChanged(nameof(SelectedAlbum));
                ApplyFilters();
            }
        }

        private string selectedLocation;
        public string SelectedLocation
        {
            get => selectedLocation;
            set
            {
                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
                ApplyFilters();
            }
        }

        //Apply filtering logic based on filter dropdowns
        public void ApplyFilters()
        {
            var filtered = Cars.AsEnumerable();

            if (!string.IsNullOrEmpty(SelectedMake) && SelectedMake != "All")
            {
                filtered = filtered.Where(car => car.Make == SelectedMake);
            }

            if (!string.IsNullOrEmpty(SelectedName) && SelectedName != "All")
            {
                filtered = filtered.Where(car => car.Name == SelectedName);
            }

            if (!string.IsNullOrEmpty(SelectedAlbum) && SelectedAlbum != "All")
            {
                filtered = filtered.Where(car => car.AlbumName == SelectedAlbum);
            }

            if (!string.IsNullOrEmpty(SelectedLocation) && SelectedLocation != "All")
            {
                filtered = filtered.Where(car => car.Location == SelectedLocation);
            }

            FilteredCars = new ObservableCollection<CarModel>(filtered.ToList());
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
