using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Business.Interfaces
{
    public interface IResponsavelManobraRepository : IRepository<ResponsavelManobra>
    {
        Task<ResponsavelManobra> ObterResponsavelManobristaCarro(Guid id);
        Task<IEnumerable<ResponsavelManobra>> ObterTodosResponsavelManobristaCarro();
        Task<ResponsavelManobra> ObterResponsavelManobra(Guid id);
    }
}
