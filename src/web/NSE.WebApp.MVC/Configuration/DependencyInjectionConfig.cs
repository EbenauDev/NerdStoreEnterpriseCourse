using Microsoft.Extensions.DependencyInjection;
using NSE.WebAPI.Core.Services;
using NSE.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            services.AddHttpClient<ICatalogoService, CatalogoService>();

            services.AddScoped<IContextoService, ContextoService>();
        }
    }
}
