using Microsoft.Extensions.Configuration;
using NSE.WebAPI.Core.Identidade;
using NSE.WebAPI.Core.Services;
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

    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> LoginAsync(UsuarioLogin usuarioLogin);
        Task<UsuarioRespostaLogin> RegistrarAsync(UsuarioRegistro usuarioRegistro);
    }

    public class AutenticacaoService : ResponseHandlerService, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endereco;

        public AutenticacaoService(HttpClient httpClient, IContextoService contextoService)
        {
            _httpClient = httpClient;
            _endereco = contextoService.GetContexto("Identidade")?.Endereco;
        }

        public async Task<UsuarioRespostaLogin> LoginAsync(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(content: JsonSerializer.Serialize(usuarioLogin),
                                                 encoding: Encoding.UTF8,
                                                 mediaType: "application/json");

            var response = await _httpClient.PostAsync(requestUri: $"{_endereco}/api/identidade/autenticar", loginContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (DeveTratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> RegistrarAsync(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(content: JsonSerializer.Serialize(usuarioRegistro),
                                      encoding: Encoding.UTF8,
                                      mediaType: "application/json");

            var response = await _httpClient.PostAsync(requestUri: $"{_endereco}/api/identidade/nova-conta", registroContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (DeveTratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());
        }
    }
}
