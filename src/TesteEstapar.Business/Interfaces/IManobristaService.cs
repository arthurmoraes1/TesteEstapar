using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Business.Interfaces
{
    public interface IManobristaService : IDisposable
    {
        Task Adicionar(Manobrista manobrista);
        Task Atualizar(Manobrista manobrista);
        Task Remover(Guid id);
        bool ValidaData(string dataNascimento);
    }
}
