﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminarioCic.Services
{
    public class ApiServices_Eventos
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/Eventos";
        HttpClient httpClient = new HttpClient();
        async public Task<List<Models.Evento>> GetEventos()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync(BaseUri);

            return JsonConvert.DeserializeObject<List<Models.Evento>>(json);
        }
        async public Task<bool> RegistrarEvento(Models.Evento semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var response = await httpClient.PostAsync(BaseUri, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> ActualizarEvento(Models.Evento semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, semi.Id);
            var response = await httpClient.PutAsync(path, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<Models.Evento> GetEvento(int id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, id);
            var json = await httpClient.GetStringAsync(path);

            return JsonConvert.DeserializeObject<Models.Evento>(json);
        }
        async public Task<Models.Evento> GetEvento(string titulo, string idSeminario)
        {
            var id = Convert.ToInt32(idSeminario);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?titulo={titulo}&idSem={idSeminario}&idSeminario={id}");

            return JsonConvert.DeserializeObject<Models.Evento>(json);
        }
        //async public Task<Models.Evento> GetEvento(string NomUsu, int idUsuario)
        //{
        //    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
        //    var json = await httpClient.GetStringAsync($"{BaseUri}?NomUsu={NomUsu}&idUsuario={idUsuario}");

        //    return JsonConvert.DeserializeObject<Models.Evento>(json);
        //}
        async public Task<List<Models.Evento>> GetEventos(int idSeminario)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?id={idSeminario}&idV={idSeminario}");

            return JsonConvert.DeserializeObject<List<Models.Evento>>(json);
        }
        async public Task<bool> EliminarEvento(int Id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, Id);
            var response = await httpClient.DeleteAsync(path);

            return response.IsSuccessStatusCode;
        }
    }
}
