using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.Services
{
    public class ApiServices_Seminario
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/";
        HttpClient httpClient = new HttpClient();
        async public Task<List<Models.Seminario>> GetSeminarios()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = BaseUri + "Seminarios";
            var json = await httpClient.GetStringAsync(path);

            return JsonConvert.DeserializeObject<List<Models.Seminario>>(json);
        }

        async public Task<bool> RegistrarSeminario(Models.Seminario semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = BaseUri + "Seminarios";
            var response = await httpClient.PostAsync(path, content);


            return response.IsSuccessStatusCode;

        }

        async public Task<HttpResponseMessage> ActualizarSeminario(Models.Seminario semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path =string.Format("{0}Seminarios/{1}",  BaseUri, semi.Id);
            var response = await httpClient.PutAsync(path, content);

            return response;
        }
        async public Task<HttpResponseMessage> EliminarSeminario(int Id)
        {
          //  var json = JsonConvert.SerializeObject(semi);
          //  var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}Seminarios/{1}", BaseUri,Id);
            var response = await httpClient.DeleteAsync(path);

            return response;
        }

    }
}
