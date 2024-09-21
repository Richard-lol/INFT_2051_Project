
namespace INFT_2051.Services
{
    internal static class ApiService
    {
        //Maintain one instance of a HttpClient to use for all requests
        private static HttpClient _client;
        private static string _baseUrl = "https://www.dnd5eapi.co/api/";

        //A static constructor runs once the first time the static class is referenced
        //We use this to create a new client and set the base url
        static ApiService()
        {
            _client = new HttpClient();
            //Setting a base url means now we only need to send the last snippet of
            //the url to the client and it will add it to the base
            _client.BaseAddress = new Uri(_baseUrl);
        }

        public static async Task<string> GetJsonFromAPI(string url)
        {
            //A HttpResponseMessage is a container containing all the response data
            HttpResponseMessage response = await _client.GetAsync(url);
            //This just checks if the response code is in the 200 range, indicating it was successful
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                //return the body content of the response as a string
                return json;
            }
            else
            {
                return "";
            }
        }
    }
}
