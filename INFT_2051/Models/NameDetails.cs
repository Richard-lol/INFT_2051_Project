using INFT_2051.Services;
using Newtonsoft.Json;


namespace INFT_2051.Models
{
    public static class NameDetails
    {


        public static string[] _names;

        public static string[] Names
        {
            get
            {
                if (_names != null)

                    return _names;
                else
                    return new string[0];
            }
            set
            {
                _names = value;
            }
        }
        public static async Task LoadCarNames(String selectedModel)
        {
            
            string json = await ApiService.GetJsonFromAPI("model&where=make%3A\"" + selectedModel + "\"&limit=100");
 
            var response = JsonConvert.DeserializeObject<ApiNameResponse>(json);

            string[] carNames = new string[100];
            for (int i = 0; i < 100; i++)
            {
                carNames[i] = response.Results[i].Model;
            }
            _names = carNames;

        }
    }

}
