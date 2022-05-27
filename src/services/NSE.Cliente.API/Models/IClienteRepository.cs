using NSE.Core.Data;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Models
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);
        Task<Cliente> ObterPorCpfAsync(string cpf);
    }
}
