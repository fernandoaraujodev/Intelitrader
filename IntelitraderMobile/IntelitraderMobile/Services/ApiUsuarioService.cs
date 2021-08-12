using IntelitraderMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntelitraderMobile.Services
{
    public class ApiUsuarioService : IUsuarioService
    {

        HttpClient _httpClient = new HttpClient();
        private string baseUrl = "http://192.168.0.16:5000/v1/usuario/";

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
            var response = await _httpClient.GetAsync(baseUrl);
            System.Console.WriteLine(response);

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Usuario>>(responseAsString);

        }

        public async Task<Usuario> GetUser(string id)
        {
            var response = await _httpClient.GetAsync(baseUrl + id);

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Usuario>(responseAsString);
        }



        public async Task AddUser(Usuario usuario)
        {
            Console.WriteLine(usuario);

            var response = await _httpClient.PostAsync(baseUrl,
                new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(string id)
        {
            var response = await _httpClient.DeleteAsync(baseUrl + id);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUser(string id, Usuario usuario)
        {
            var response = await _httpClient.PutAsync(baseUrl + id,
                new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}