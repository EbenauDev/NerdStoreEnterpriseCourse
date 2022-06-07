using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<string> LoginAsync(UsuarioLogin usuarioLogin);
        Task<string> RegistrarAsync(UsuarioRegistro usuarioRegistro);
    }


}
