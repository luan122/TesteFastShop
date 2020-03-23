using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFast.Application.Clientes.Dtos;
using TestFast.Application.Clientes.Interfaces;
using TestFast.Data.Data.Models;
using TestFast.Domain.Clientes.Interfaces;

namespace TestFast.Application.Clientes.Services
{
    public class ClienteApplicationService: IClienteApplicationService
    {
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IMapper _mapper;

        public ClienteApplicationService(IClienteDomainService clienteDomainService, IMapper mapper)
        {
            _clienteDomainService = clienteDomainService;
            _mapper = mapper;
        }

        public async Task<List<ClienteDto>> ListarClientes()
        {
            var listaEntity = _clienteDomainService.GetAll().ToList();
            var retorno = listaEntity.Select(c => _mapper.Map<ClienteDto>(c)).ToList();
            return retorno;
        }

        public async Task<ClienteDto> AdquirirCliente(long id)
        {
            var clienteEntity = await _clienteDomainService.GetById(id);
            var retorno = _mapper.Map<ClienteDto>(clienteEntity);
            return retorno;
        }

        public async Task<bool> DeletarCliente(long id)
        {
            _clienteDomainService.Remove(id);
            return (await _clienteDomainService.SaveChanges()) > 0;
        }

        public async Task<bool> ModificarCliente(ClienteDto cliente)
        {
            var entity = _mapper.Map<ClientEntity>(cliente);
            _clienteDomainService.Update(entity);
            return (await _clienteDomainService.SaveChanges()) > 0;
        }

        public async Task<ClienteDto> InserirCliente(ClienteDto cliente)
        {
            var entity = _mapper.Map<ClientEntity>(cliente);
            await _clienteDomainService.Add(entity);
            if(await _clienteDomainService.SaveChanges() > 0)
                return _mapper.Map<ClienteDto>(entity);
            return null;
        }
    }
}
