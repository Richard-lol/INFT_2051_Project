
using INFT_2051.Services.PartialMethods;

namespace INFT_2051;

public partial class App : Application
{
    
    public App()
    {
        InitializeComponent();

        WindowSizeHandler.CallSetWindowSize();

        MainPage = new NavigationPage(new MainPage());

    }
}
