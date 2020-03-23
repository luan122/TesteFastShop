using System;
using System.Collections.Generic;
using System.Text;
using TestFast.Data.Data.Interfaces;
using TestFast.Data.Data.Models;

namespace TestFast.Domain.Clientes.Interfaces
{
    public interface IClienteDomainService : IBaseRepository<ClientEntity>
    {
    }
}
