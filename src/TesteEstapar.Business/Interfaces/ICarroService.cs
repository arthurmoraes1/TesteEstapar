using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Business.Interfaces
{
    public interface ICarroService : IDisposable
    {
        Task Adicionar(Carro carro);
        Task Atualizar(Carro carro);
        Task Remover(Guid id);

    }
}
