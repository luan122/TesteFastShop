using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestFast.Application.Clientes.Dtos;

namespace TestFast.Application.Clientes.Interfaces
{
    public interface IClienteApplicationService
    {
        Task<List<ClienteDto>> ListarClientes();
        Task<ClienteDto> AdquirirCliente(long id);
        Task<bool> DeletarCliente(long id);
        Task<bool> ModificarCliente(ClienteDto cliente);
        Task<bool> InserirCliente(ClienteDto cliente);
    }
}
