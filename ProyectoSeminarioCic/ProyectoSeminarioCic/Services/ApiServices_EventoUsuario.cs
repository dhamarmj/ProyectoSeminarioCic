using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.Services
{
   public class ApiServices_EventoUsuario
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/Evento_usuario";
        HttpClient httpClient = new HttpClient();
        async public Task<List<Models.Evento_Usuario>> GetEvento_Usuario()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync(BaseUri);

            return JsonConvert.DeserializeObject<List<Models.Evento_Usuario>>(json);
        }
        //async public Task<Models.Evento_Usuario> GetEventoUsuario(int id)
        //{
        //    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
        //    var path = string.Format("{0}/{1}", BaseUri, id);
        //    var json = await httpClient.GetStringAsync(path);

        //    return JsonConvert.DeserializeObject<Models.Evento_Usuario>(json);
        //}
        async public Task<Models.Evento_Usuario> GetEvento_Usuario(int IdUsuario, int idEvento)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?idUsuario={IdUsuario}&idEvento={idEvento}");

            return JsonConvert.DeserializeObject<Models.Evento_Usuario>(json);
        }
        async public Task<Models.Evento_Usuario> GetEvento_Usuario(int idEvento)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?idEvento={idEvento}");

            return JsonConvert.DeserializeObject<Models.Evento_Usuario>(json);
        }
        async public Task<bool> RegistrarEvento_Usuario(Models.Evento_Usuario semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var response = await httpClient.PostAsync(BaseUri, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> ActualizarEvento_Usuario(Models.Evento_Usuario semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, semi.Id);
            var response = await httpClient.PutAsync(path, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> EliminarEvento_Usuario(int Id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, Id);
            var response = await httpClient.DeleteAsync(path);

            return response.IsSuccessStatusCode;
        }
    }
}
