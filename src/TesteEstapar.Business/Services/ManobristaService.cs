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
    public class ManobristaService : BaseService, IManobristaService
    {
        private readonly IManobristaRepository _manobristaRepository;
        private readonly IResponsavelManobraRepository _responsavelManobraRepository;
        public ManobristaService(IManobristaRepository manobristaRepository,
                                IResponsavelManobraRepository responsavelManobraRepository,
                                INotificador notificador) : base(notificador)
        {
            _manobristaRepository = manobristaRepository;
            _responsavelManobraRepository = responsavelManobraRepository;
        }

        public async Task Adicionar(Manobrista manobrista)
        {
            manobrista.Cpf = Utils.RemoverCharEspecial(manobrista.Cpf);
            if (!ExecutarValidacao(new ManobristaValidation(), manobrista)) return;

            if (_manobristaRepository.Buscar(m => m.Cpf == manobrista.Cpf).Result.Any())
            {
                Notificar("Já existe um manobrista com esse cpf informado.");
                return;
            }

            await _manobristaRepository.Adicionar(manobrista);
        }

        public async Task Atualizar(Manobrista manobrista)
        {
            manobrista.Cpf = Utils.RemoverCharEspecial(manobrista.Cpf);
            if (!ExecutarValidacao(new ManobristaValidation(), manobrista)) return;

            if(_manobristaRepository.Buscar(m=>m.Cpf == manobrista.Cpf && m.Id != manobrista.Id).Result.Any())
            {
                Notificar("Já existe um manobrista com esse cpf informado.");
                return;
            }

            await _manobristaRepository.Atualizar(manobrista);
        }
        
        public async Task Remover(Guid id)
        {
            if (_responsavelManobraRepository.Buscar(c => c.ManobristaId == id).Result.Any())
            {
                Notificar("Não é possível excluir, exclua primeiro o vinculo de carro e manobrista na aba Responsável.");
                return;
            }

            await _manobristaRepository.Remover(id);
        }
        public void Dispose()
        {
            _manobristaRepository?.Dispose();
        }

        public bool ValidaData(string dataNascimento)
        {
            if (!Utils.ValidaData(dataNascimento))
            {
                Notificar("A data fornecida é inválida.");
                return false;
            }

            return true;
        }
    }
}
