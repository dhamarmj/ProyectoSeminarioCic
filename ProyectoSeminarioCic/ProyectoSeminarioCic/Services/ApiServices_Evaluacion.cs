using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoSeminarioCic.Services
{
   public class ApiServices_Evaluacion
    {
        string BaseUri = "http://proyectosapi.azurewebsites.net/api/Evaluaciones";
        HttpClient httpClient = new HttpClient();
        async public Task<List<Models.Evaluacion>> GetEvaluacion()
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync(BaseUri);

            return JsonConvert.DeserializeObject<List<Models.Evaluacion>>(json);
        }
        async public Task<bool> RegistrarEvaluacion(Models.Evaluacion semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var response = await httpClient.PostAsync(BaseUri, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<Models.Evaluacion> GetEvaluacion(int idEventoP, string rol)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var json = await httpClient.GetStringAsync($"{BaseUri}?idEventoP={idEventoP}&rol={rol}");

            return JsonConvert.DeserializeObject<Models.Evaluacion>(json);
        }
        async public Task<bool> ActualizarEvaluacion(Models.Evaluacion semi)
        {
            var json = JsonConvert.SerializeObject(semi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, semi.Id);
            var response = await httpClient.PutAsync(path, content);

            return response.IsSuccessStatusCode;
        }
        async public Task<bool> EliminarEvaluacion(int Id)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Settings.AccesToken);
            var path = string.Format("{0}/{1}", BaseUri, Id);
            var response = await httpClient.DeleteAsync(path);

            return response.IsSuccessStatusCode;
        }
    }
}
