using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Business.Models;

namespace TesteEstapar.Business.Services
{
    public class ResponsavelManobraService : BaseService, IResponsavelManobraService
    {
        private readonly IResponsavelManobraRepository _responsavelManobraRepository;

        public ResponsavelManobraService(IResponsavelManobraRepository responsavelManobraRepository, 
                                        INotificador notificador) : base(notificador)
        {
            _responsavelManobraRepository = responsavelManobraRepository;
        }

        public async Task Adicionar(ResponsavelManobra responsavelManobra)
        {
            if (_responsavelManobraRepository.Buscar(m => m.CarroId == responsavelManobra.CarroId).Result.Any())
            {
                Notificar("Esse carro ja foi adicionado.");
                return;
            }

            await _responsavelManobraRepository.Adicionar(responsavelManobra);
        }

        public async Task Atualizar(ResponsavelManobra responsavelManobra)
        {
            if (_responsavelManobraRepository.Buscar(m => m.CarroId == responsavelManobra.CarroId).Result.Any())
            {
                Notificar("Esse carro ja foi adicionado.");
                return;
            }

            await _responsavelManobraRepository.Atualizar(responsavelManobra);
        }

        public async Task Remover(Guid id)
        {
            await _responsavelManobraRepository.Remover(id);
        }

        public void Dispose()
        {
            _responsavelManobraRepository?.Dispose();
        }

    }
}
