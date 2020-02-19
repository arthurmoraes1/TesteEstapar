using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Business.Interfaces
{
    public interface ICarroRepository : IRepository<Carro>
    {
        Task<Carro> ObterCarro(Guid id);
    }
}
