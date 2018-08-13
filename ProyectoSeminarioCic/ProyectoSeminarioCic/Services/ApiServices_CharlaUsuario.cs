using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.Services
{
    public class ApiServices_CharlaUsuario
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/Charla_usuario";
        HttpClient httpClient = new HttpClient();
        async public Task<List<Models.Charla_Usuario>> GetCharla_Usuario()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync(BaseUri);

            return JsonConvert.DeserializeObject<List<Models.Charla_Usuario>>(json);
        }
        async public Task<Models.Charla_Usuario> GetCharla_Usuario(int IdUsuario, int idCharla)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?idUsuario={IdUsuario}&idCharla={idCharla}");
            
            var value = JsonConvert.DeserializeObject<Models.Charla_Usuario>(json);

            return value;
        }
        async public Task<Models.Charla_Usuario> GetCharla_Usuario(int idCharla)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?idCharla={idCharla}");

            return JsonConvert.DeserializeObject<Models.Charla_Usuario>(json);
        }
        //async public Task<Models.Charla_Usuario> GetCharla_Usuario(int id)
        //{
        //    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
        //    var path = string.Format("{0}/{1}", BaseUri, id);
        //    var json = await httpClient.GetStringAsync(path);

        //    return JsonConvert.DeserializeObject<Models.Charla_Usuario>(json);
        //}
        async public Task<bool> RegistrarCharla_Usuario(Models.Charla_Usuario semi)
        {

            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var response = await httpClient.PostAsync(BaseUri, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> ActualizarCharla_Usuario(Models.Charla_Usuario semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, semi.Id);
            var response = await httpClient.PutAsync(path, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> EliminarCharla_Usuario(int Id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, Id);
            var response = await httpClient.DeleteAsync(path);

            return response.IsSuccessStatusCode;
        }





    }
}
