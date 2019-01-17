using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using uMediaBot.Entities;

namespace uMediaBot
{
    public class AspNetAPI
    {
        private readonly HttpClient _http;

        public AspNetAPI()
        {
            _http = new HttpClient() {BaseAddress = new Uri("http://localhost:5000/api/") };
        }

        public async Task<List<Folder>> GetUserFolders(long userId)
        {
            var result = await _http.GetAsync($"folders/{userId}");
            var resultString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Folder>>(resultString);
        }

        public async Task<int> CreateUserFolder(Folder folder)
        {
            string data = $"{{\"user_id\":{folder.UserId}, \"name\":\"{folder.Name}\", \"previousFolderId\":{folder.PreviousFolderId.ToString()}}}";
            var result = await _http.PostAsync("folders/create", new StringContent(data, Encoding.UTF8,  "application/json"));
            var resultString = await result.Content.ReadAsStringAsync();
            return int.Parse(resultString);
        }
    }
}
