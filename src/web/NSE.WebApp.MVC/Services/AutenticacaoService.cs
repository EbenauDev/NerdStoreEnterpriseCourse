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

    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient, IContextoService contextoService)
        {
            httpClient.BaseAddress = new Uri(contextoService.GetContexto("Identidade")?.Endereco);

            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> LoginAsync(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);
            var response = await _httpClient.PostAsync(requestUri: $"/api/identidade/autenticar", loginContent);

            if (DeveTratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> RegistrarAsync(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);
            var response = await _httpClient.PostAsync(requestUri: $"/api/identidade/nova-conta", registroContent);

            if (DeveTratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
