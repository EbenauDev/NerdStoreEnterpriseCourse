using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(content: JsonSerializer.Serialize(usuarioLogin),
                                                 encoding: Encoding.UTF8,
                                                 mediaType: "application/json");

            var response = await _httpClient.PostAsync(requestUri: "", loginContent);
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> RegistrarAsync(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(content: JsonSerializer.Serialize(usuarioRegistro),
                                      encoding: Encoding.UTF8,
                                      mediaType: "application/json");

            var response = await _httpClient.PostAsync(requestUri: "", registroContent);
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
