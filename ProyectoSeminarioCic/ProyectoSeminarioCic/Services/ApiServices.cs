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
        async public Task<bool> RegisterUser(string email, string pass, string confpass)
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
            Settings.Email = email;
            Settings.Password = pass;
            return response.IsSuccessStatusCode;
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
            HttpClient cliente = new HttpClient();
            var response = await cliente.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var jobject = JsonConvert.DeserializeObject<dynamic>(content);
            Settings.AccesToken = jobject.Value<string>("access_token");
            

            return response.IsSuccessStatusCode;
        }

    }
}
