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
                Email = email.ToLower(),
                Password = pass,
                ConfirmPassword = confpass
            };

            var jsonobj = JsonConvert.SerializeObject(registry);
            var content = new StringContent(jsonobj, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(BaseUri + "Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginUser(string email, string pass)
        {
            email = email.ToLower();
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


            //var jobject = JsonConvert.DeserializeObject<dynamic>(content);
            var jobject = JObject.Parse(content);
            //Console.WriteLine("=======================================");
            //Console.WriteLine(jobject);
            //Console.WriteLine("========================== =============");
            var value = (string) jobject["access_token"];
            //Settings.AccesToken = (string)jobject["access_token"];
            //.Value<string>("access_token");
            Settings.Email = email;
            Settings.Password = pass;

            return response.IsSuccessStatusCode;
        }

    }
}
