using Microsoft.Extensions.DependencyInjection;
using NSE.Cliente.API.Data;

namespace NSE.Clientes.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ClientesContext>();
        }
    }
}