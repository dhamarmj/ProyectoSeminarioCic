using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.Services
{
    public class ApiServicesNotificaciones
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/Notificaciones";
        HttpClient httpClient = new HttpClient();
        async public Task<List<Models.Notificacion>> GetNotificacion()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync(BaseUri);

            return JsonConvert.DeserializeObject<List<Models.Notificacion>>(json);
        }
        async public Task<List<Models.Notificacion>> GetNotificacion(string destinatario)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?destinatario={destinatario}");

            var value = JsonConvert.DeserializeObject<List<Models.Notificacion>>(json);

            return value;
        }
        async public Task<bool> RegistrarNotificacion(Models.Notificacion semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var response = await httpClient.PostAsync(BaseUri, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> ActualizarNotificacion(Models.Notificacion semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, semi.Id);
            var response = await httpClient.PutAsync(path, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<Models.Notificacion> GetNotificacion(int id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, id);
            var json = await httpClient.GetStringAsync(path);

            return JsonConvert.DeserializeObject<Models.Notificacion>(json);
        }
        async public Task<bool> EliminarNotificacion(int Id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, Id);
            var response = await httpClient.DeleteAsync(path);

            return response.IsSuccessStatusCode;
        }
    }
}
