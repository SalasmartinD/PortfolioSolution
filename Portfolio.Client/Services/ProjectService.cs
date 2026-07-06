using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Portfolio.Shared.Models;

namespace Portfolio.Client.Services
{
    public class ProjectService
    {
        private readonly HttpClient _httpClient;
        private readonly string _supabaseUrl;
        private readonly string _supabaseAnonKey;

        public ProjectService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _supabaseUrl = configuration["Supabase:Url"] ?? string.Empty;
            _supabaseAnonKey = configuration["Supabase:AnonKey"] ?? string.Empty;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            if (string.IsNullOrWhiteSpace(_supabaseUrl) || string.IsNullOrWhiteSpace(_supabaseAnonKey))
            {
                throw new InvalidOperationException("Supabase Url or AnonKey is not configured. Please check your appsettings.json file.");
            }

            // Construir la URL consultando todos los campos y ordenando por 'priority' de forma ascendente
            var url = $"{_supabaseUrl.TrimEnd('/')}/rest/v1/projects?select=*&order=priority.asc";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            // Supabase requiere que se pasen la clave anon tanto en la cabecera 'apikey' como en 'Authorization'
            request.Headers.Add("apikey", _supabaseAnonKey);
            request.Headers.Add("Authorization", $"Bearer {_supabaseAnonKey}");

            using var response = await _httpClient.SendAsync(request);
            
            // Genera una excepción si el código de estado HTTP no indica éxito
            response.EnsureSuccessStatusCode();

            var projects = await response.Content.ReadFromJsonAsync<List<Project>>();
            return projects ?? new List<Project>();
        }
    }
}
