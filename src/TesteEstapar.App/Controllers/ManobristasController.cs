using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteEstapar.App.ViewModels;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Business.Models;
using TesteEstapar.Business.Validations.Docs;
using TesteEstapar.Data.Context;

namespace TesteEstapar.App.Controllers
{
    public class ManobristasController : BaseController
    {
        private readonly IManobristaRepository _manobristaRepository;
        private readonly IManobristaService _manobristaService;
        private readonly IMapper _mapper;

        public ManobristasController(IManobristaRepository manobristaRepository, 
                                        IMapper mapper, IManobristaService manobristaService,
                                        INotificador notificador) : base(notificador)
        {
            _manobristaRepository = manobristaRepository;
            _mapper = mapper;
            _manobristaService = manobristaService;

        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var manobristaViewModel = await ObterManobrista(id);
            if (manobristaViewModel == null)
            {
                return NotFound();
            }

            return View(manobristaViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManobristaViewModel manobristaViewModel)
        {
            if (!ModelState.IsValid) return View(manobristaViewModel);

            if(!_manobristaService.ValidaData(manobristaViewModel.DataNascimento)) return View(manobristaViewModel); 
            
            var manobrista = _mapper.Map<Manobrista>(manobristaViewModel);
            await _manobristaService.Adicionar(manobrista);

            if (!OperacaoValida()) return View(manobristaViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var manobristaViewModel = await ObterManobrista(id);
            if (manobristaViewModel == null)
            {
                return NotFound();
            }
            return View(manobristaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ManobristaViewModel manobristaViewModels)
        {
            if (id != manobristaViewModels.Id) return NotFound();

            var manobristaAtualizacao = await ObterManobrista(id);

            if (!_manobristaService.ValidaData(manobristaViewModels.DataNascimento)) return View(manobristaViewModels);

            if (!ModelState.IsValid) return View(manobristaViewModels);

            manobristaAtualizacao.Nome = manobristaViewModels.Nome;
            manobristaAtualizacao.Cpf = manobristaViewModels.Cpf;
            manobristaAtualizacao.DataNascimento = manobristaViewModels.DataNascimento;

            await _manobristaService.Atualizar(_mapper.Map<Manobrista>(manobristaAtualizacao));

            if (!OperacaoValida()) return View(manobristaViewModels);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var manobristaViewModels = await ObterManobrista(id);
            if (manobristaViewModels == null) return NotFound();

            return View(manobristaViewModels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var manobristaViewModels = await ObterManobrista(id);

            if (manobristaViewModels == null) return NotFound();
            await _manobristaService.Remover(id);

            if (!OperacaoValida()) return View(manobristaViewModels);

            TempData["Sucesso"] = "manobrista excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private async Task<ManobristaViewModel> ObterManobrista(Guid id)
        {
            var manobrista = _mapper.Map<ManobristaViewModel>(await _manobristaRepository.ObterManobrista(id));

            return manobrista;
        }
    }
}
