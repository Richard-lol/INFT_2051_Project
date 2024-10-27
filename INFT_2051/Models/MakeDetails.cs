using INFT_2051.Services;
using Newtonsoft.Json;


namespace INFT_2051.Models
{
    public static class MakeDetails
    {
        public static string[] _makes;

        public static string[] Makes
        {
            get
            {
                if (_makes != null)
                    return _makes;
                else
                    return new string[0];
            }
            set
            {
                _makes = value;
            }
        }
        public static async void LoadCarMakes()
        {
       ;
            string json = await ApiService.GetJsonFromAPI("make&limit=100");
     
            var response = JsonConvert.DeserializeObject<ApiMakeResponse>(json);
            string[] makeNames = new string[100];
            for (int i = 0; i < 100; i++)
            {
                makeNames[i] = response.Results[i].Make;
            }
            _makes = makeNames;

        }
    }

}
