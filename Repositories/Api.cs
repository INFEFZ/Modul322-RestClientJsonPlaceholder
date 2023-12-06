using Newtonsoft.Json;
using RestClient.Models;
using System.Net.Http;

namespace RestClient.Repositories
{
    internal class Api
    {
        public static async Task<IEnumerable<Album>?> GetAlbum()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, AppSettings.Instance.AlbumsUrl);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error Http Request");

            var result = JsonConvert.DeserializeObject<List<Album>>(await response.Content.ReadAsStringAsync());

            return result;
        }
    }
}
