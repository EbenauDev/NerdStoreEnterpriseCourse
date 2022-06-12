using Microsoft.Extensions.Configuration;
using NSE.WebAPI.Core.Identidade;
using System.Linq;

namespace NSE.WebAPI.Core.Services
{
    public interface IContextoService
    {
        Contexto GetContexto(string nome);
    }

    public sealed class ContextoService : IContextoService
    {
        private readonly IConfiguration _configuration;

        public ContextoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Contexto GetContexto(string nome)
        {
            var settings = _configuration.Get<AppSettings>();

            return settings.Contextos.FirstOrDefault(c => c.Nome.ToUpper() == nome.ToUpper());
        }
    }
}
