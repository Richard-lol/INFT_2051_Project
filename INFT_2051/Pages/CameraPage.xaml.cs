using INFT_2051.Models;
using INFT_2051.ViewModels;
using OpenCvSharp;
using System.Diagnostics;


namespace INFT_2051.Pages;

public partial class CameraPage : ContentPage
{
    CarViewModel viewModel;
    private CarModel carModel;
    private string haarCascadePath;

    public CameraPage()
	{
        carModel = new CarModel();
        InitializeComponent();

        haarCascadePath = Path.Combine(FileSystem.AppDataDirectory, "haarcascade_russian_plate_number.xml");

        if (!File.Exists(haarCascadePath))
        {
            //Get the Haar Cascade XML 
            using (var stream = FileSystem.OpenAppPackageFileAsync("Resources/haarcascade_russian_plate_number.xml").Result)
            {
                using (var output = File.Create(haarCascadePath))
                {
                    stream.CopyTo(output);
                }
            }
        }

    }
    private void CarTagPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CarTagPage(carModel));
    }

    //Camera upload
    private async void PhotoButtonClicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null)
            {
                //Apply blurring and get the path of the blurred image
                string blurredImagePath = await BlurLicensePlate(photo.FullPath);

                //Display the blurred image
                var stream = File.OpenRead(blurredImagePath);
                PhotoPreview.Source = ImageSource.FromStream(() => stream);

                //Save the blurred image path to the carModel
                carModel.ImageFilePath = blurredImagePath;
            }
        }
    }
    //Local upload
    private async void UploadButtonClicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.PickPhotoAsync();

        if (photo != null)
        {
            //Apply blurring and get the path of the blurred image
            string blurredImagePath = await BlurLicensePlate(photo.FullPath);

            //Display the blurred image
            var stream = File.OpenRead(blurredImagePath);
            PhotoPreview.Source = ImageSource.FromStream(() => stream);

            //Save the blurred image path to the carModel
            carModel.ImageFilePath = blurredImagePath;
        }
    }

    private async Task<string> BlurLicensePlate(string imagePath)
    {
        //Load the image using OpenCvSharp
        using var image = Cv2.ImRead(imagePath);

        //Load the Haar Cascade for detection
        using var haarCascade = new CascadeClassifier(haarCascadePath);

        //Detect the license plate
        var licensePlates = haarCascade.DetectMultiScale(image, scaleFactor: 1.05, minNeighbors: 3, minSize: new OpenCvSharp.Size(10, 10));

        // Apply Gaussian blur to each detected license plate
        foreach (var plate in licensePlates)
        {
            var licensePlateROI = new Mat(image, plate);
            Cv2.GaussianBlur(licensePlateROI, licensePlateROI, new OpenCvSharp.Size(55, 55), 0);
        }

        //Save blurred image to path variable
        string blurredImagePath = Path.Combine(FileSystem.AppDataDirectory, $"blurred_{Path.GetFileName(imagePath)}");
        Cv2.ImWrite(blurredImagePath, image); 

        return blurredImagePath;  
    }

}