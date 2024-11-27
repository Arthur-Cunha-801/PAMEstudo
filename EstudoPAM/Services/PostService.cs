using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EstudoPAM.Models;

namespace EstudoPAM.Services
{
    public class PostService
    {
        private HttpClient? httpClient;
        private Post? post;
        private ObservableCollection<Post>? _posts;
        private JsonSerializerOptions? jsonSerializerOptions;

        public PostService()
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Post>> getPosts()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/users");

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    _posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return _posts;
        }

    }
}
