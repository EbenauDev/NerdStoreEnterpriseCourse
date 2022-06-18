using NSE.WebAPI.Core.Services;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{

    public interface ICatalogoService
    {
        Task<ProdutoViewModel> ObterPorIdAsync(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterTodosAsync();
    }

    public class CatalogoService : Service, ICatalogoService
    {

        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IContextoService contextoService)
        {
            httpClient.BaseAddress = new Uri(contextoService.GetContexto("Catalogo")?.Endereco);
            _httpClient = httpClient;
        }

        public async Task<ProdutoViewModel> ObterPorIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/catalogo/produtos/{id}");
            if (DeveTratarErrosResponse(response))
            {

            }
            return await DeserializarObjetoResponse<ProdutoViewModel>(response);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodosAsync()
        {
            var response = await _httpClient.GetAsync($"/api/catalogo/produtos");
            if (DeveTratarErrosResponse(response))
            {

            }
            return await DeserializarObjetoResponse<IEnumerable<ProdutoViewModel>>(response);
        }
    }
}
