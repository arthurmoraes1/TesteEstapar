using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Business.Models;
using TesteEstapar.Business.Validations;
using TesteEstapar.Business.Validations.Docs;

namespace TesteEstapar.Business.Services
{
    public class CarroService : BaseService, ICarroService
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IResponsavelManobraRepository _responsavelManobraRepository;
        public CarroService(ICarroRepository carroRepository,
                            IResponsavelManobraRepository responsavelManobraRepository,
                            INotificador notificador) : base(notificador)
        {
            _carroRepository = carroRepository;
            _responsavelManobraRepository = responsavelManobraRepository;
        }
        public async Task Adicionar(Carro carro)
        {
            if (!ExecutarValidacao(new CarroValidation(), carro)) return;
            carro.Placa = Utils.RemoverCharEspecial(carro.Placa);
            await _carroRepository.Adicionar(carro);
        }

        public async Task Atualizar(Carro carro)
        {
            carro.Placa = carro.Placa.Insert(3, "-");
            if (!ExecutarValidacao(new CarroValidation(), carro)) return;
            carro.Placa = Utils.RemoverCharEspecial(carro.Placa);
            await _carroRepository.Atualizar(carro);
        }

        public async Task Remover(Guid id)
        {
            if(_responsavelManobraRepository.Buscar(c=>c.CarroId == id).Result.Any())
            {
                Notificar("Não é possível excluir, exclua primeiro o vinculo de carro e manobrista na aba Responsável.");
                return;
            }

            await _carroRepository.Remover(id);
        }

        public void Dispose()
        {
            _carroRepository?.Dispose();
        }
    }
}
