using System;
using System.Collections.Generic;
using System.Text;
using TestFast.Data.Data.Context;
using TestFast.Data.Data.Interfaces;
using TestFast.Data.Data.Models;
using TestFast.Data.Data.Repositories;
using TestFast.Domain.Clientes.Interfaces;

namespace TestFast.Domain.Clientes.Services
{
    public class ClienteDomainService : BaseRepository<ClientEntity>, IClienteDomainService
    {
        public ClienteDomainService(ApplicationDbContext context): base(context) { }
    }
}
