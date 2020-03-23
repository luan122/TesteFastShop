using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestFast.Api.Model;
using TestFast.Application.Clientes.Interfaces;
using TestFast.Application.Clientes.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace TestFast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteApplicationService clienteApplicationService, IMapper mapper)
        {
            _clienteApplicationService = clienteApplicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> Get()
        {
            var dto = await _clienteApplicationService.ListarClientes();
            var model = dto.Select(c => _mapper.Map<ClienteModel>(c)).ToList();
            return model;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var dto = await _clienteApplicationService.AdquirirCliente(id);
            if (dto != null)
            {
                var model = _mapper.Map<ClienteModel>(dto);
                return Ok(model);
            }
            return NotFound(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dto = _mapper.Map<ClienteDto>(cliente);
            if (await _clienteApplicationService.InserirCliente(dto))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ClienteModel cliente)
        {
            var dto = _clienteApplicationService.AdquirirCliente(id);
            if (dto != null && dto.Id == id)
            {
                var obj = _mapper.Map<ClienteModel>(dto);
                obj.Nome = cliente.Nome;
                obj.Documento = cliente.Documento;
                if (await _clienteApplicationService.ModificarCliente(_mapper.Map<ClienteDto>(obj)))
                    return Ok();
                return NotFound();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(long id, [FromBody]JsonPatchDocument<ClienteModel> cliente)
        {
            var dto = _clienteApplicationService.AdquirirCliente(id);
            if(dto != null && dto.Id == id)
            {
                var obj = _mapper.Map<ClienteModel>(dto);
                cliente.ApplyTo(obj);
                if(await _clienteApplicationService.ModificarCliente(_mapper.Map<ClienteDto>(cliente)))
                    return Ok();
                return NotFound();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var dto = _clienteApplicationService.AdquirirCliente(id);
            if(dto != null && dto.Id == id)
            {
                if (await _clienteApplicationService.DeletarCliente(dto.Id))
                    return Ok();
                return NotFound();
            }
            return NotFound();
        }
    }
}
