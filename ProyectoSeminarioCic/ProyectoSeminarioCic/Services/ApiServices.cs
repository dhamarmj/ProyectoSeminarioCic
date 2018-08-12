using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProyectoSeminarioCic.Services
{
    public class ApiServices
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/";
        HttpClient httpClient = new HttpClient();
        async public Task<HttpResponseMessage> RegisterUser(string email, string pass, string confpass)
        {
            var registry = new Models.RegisterModel()
            {
                Email = email,
                Password = pass,
                ConfirmPassword = confpass
            };

            var jsonobj = JsonConvert.SerializeObject(registry);
            var content = new StringContent(jsonobj, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(BaseUri + "Account/Register", content);
            return response;
        }
       
        public async Task<bool> LoginUser(string email, string pass)
        {
            var keyval = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", pass),
                new KeyValuePair<string, string>("grant_type", "password"),
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://proyectosapi.azurewebsites.net/Token");
            request.Content = new FormUrlEncodedContent(keyval);
            var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            JObject jobject = JsonConvert.DeserializeObject<dynamic>(content);
            Settings.AccesToken = jobject.Value<string>("access_token");
            Settings.Email = email;
            Settings.Password = pass;

            return response.IsSuccessStatusCode;
        }
        async public Task<Models.Usuario> CheckUsername(string email, string pass)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var url = BaseUri + "Usuarios";
            var json = await httpClient.GetStringAsync($"{url}?email={email}&pass={pass}");
            return JsonConvert.DeserializeObject<Models.Usuario>(json);
        }
        async public Task<List<Models.Usuario>> GetUsers()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync(BaseUri + "Usuarios");
            return JsonConvert.DeserializeObject<List<Models.Usuario>>(json);
        }
        async public Task<bool> RegisterUser(Models.Usuario user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = BaseUri + "Usuarios";
            var response = await httpClient.PostAsync(path, content);

            return response.IsSuccessStatusCode;
        }


    }
}
