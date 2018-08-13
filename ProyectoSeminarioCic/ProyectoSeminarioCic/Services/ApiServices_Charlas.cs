using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.Services
{
    public class ApiServices_Charlas
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/Charlas";
        HttpClient httpClient = new HttpClient();
        async public Task<List<Models.Charla>> GetCharla()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync(BaseUri);

            return JsonConvert.DeserializeObject<List<Models.Charla>>(json);
        }
        async public Task<bool> RegistrarCharla(Models.Charla semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var response = await httpClient.PostAsync(BaseUri, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> ActualizarCharla(Models.Evento semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, semi.Id);
            var response = await httpClient.PutAsync(path, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<Models.Charla> GetCharla(int id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, id);
            var json = await httpClient.GetStringAsync(path);

            return JsonConvert.DeserializeObject<Models.Charla>(json);
        }
        async public Task<bool> EliminarCharla(int Id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, Id);
            var response = await httpClient.DeleteAsync(path);

            return response.IsSuccessStatusCode;
        }
    }
}
