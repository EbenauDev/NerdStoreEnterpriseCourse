using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> LoginAsync(UsuarioLogin usuarioLogin);
        Task<UsuarioRespostaLogin> RegistrarAsync(UsuarioRegistro usuarioRegistro);
    }


}
