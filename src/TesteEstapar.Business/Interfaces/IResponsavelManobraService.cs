using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Business.Interfaces
{
    public interface IResponsavelManobraService : IDisposable
    {
        Task Adicionar(ResponsavelManobra responsavelManobra);
        Task Atualizar(ResponsavelManobra responsavelManobra);
        Task Remover(Guid id);
    }
}
