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
using TesteEstapar.Data.Context;

namespace TesteEstapar.App.Controllers
{
    public class ResponsavelManobrasController : BaseController
    {
        private readonly IManobristaRepository _manobristaRepository;
        private readonly IResponsavelManobraRepository _responsavelManobraRepository;
        private readonly IResponsavelManobraService _responsavelManobraService;
        private readonly ICarroRepository _carroRepository;
        private readonly IMapper _mapper;

        public ResponsavelManobrasController(IManobristaRepository manobristaRepository,
            IResponsavelManobraRepository responsavelManobraRepository,
                                                ICarroRepository carroRepository,
                                                IResponsavelManobraService responsavelManobraService,
                                                INotificador notificador, 
                                                IMapper mapper) : base(notificador)
        {
            _manobristaRepository = manobristaRepository;
            _responsavelManobraRepository = responsavelManobraRepository;
            _carroRepository = carroRepository;
            _responsavelManobraService = responsavelManobraService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ResponsavelManobraViewModel>>(await _responsavelManobraRepository.ObterTodosResponsavelManobristaCarro()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var responsavelManobraViewModel = _mapper.Map<ResponsavelManobraViewModel>(await _responsavelManobraRepository.ObterResponsavelManobristaCarro(id));
            if (responsavelManobraViewModel == null)
            {
                return NotFound();
            }

            return View(responsavelManobraViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var responsavelManobraViewModel = await PopularManobristasCarros(new ResponsavelManobraViewModel());
            return View(responsavelManobraViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResponsavelManobraViewModel responsavelManobraViewModel)
        {
            responsavelManobraViewModel = await PopularManobristasCarros(responsavelManobraViewModel);
            if (!ModelState.IsValid) return View(responsavelManobraViewModel);

            var responsavelManobra = _mapper.Map<ResponsavelManobra>(responsavelManobraViewModel);
            await _responsavelManobraService.Adicionar(responsavelManobra);

            if (!OperacaoValida()) return View(responsavelManobraViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var responsavelManobraViewModel = await ObterResponsavelManobra(id);

            var listaCarros = await _carroRepository.ObterTodos();

            ViewBag.Carros = new SelectList(listaCarros, "Id", "Modelo", responsavelManobraViewModel.CarroId);

            if (responsavelManobraViewModel == null)
            {
                return NotFound();
            }
            return View(responsavelManobraViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ResponsavelManobraViewModel responsavelManobraViewModel)
        {
            if (id != responsavelManobraViewModel.Id) return NotFound();

            var responsavelManobraAtualizacao = await ObterResponsavelManobra(id);
            
            if (!ModelState.IsValid) return View(responsavelManobraViewModel);

            responsavelManobraAtualizacao.CarroId = responsavelManobraViewModel.CarroId;

            await _responsavelManobraService.Atualizar(_mapper.Map<ResponsavelManobra>(responsavelManobraAtualizacao));

            if (!OperacaoValida()) return View(responsavelManobraViewModel);
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var responsavelManobraViewModel = await ObterResponsavelManobra(id);
            if (responsavelManobraViewModel == null) return NotFound();

            return View(_mapper.Map<ResponsavelManobraViewModel>(responsavelManobraViewModel));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var responsavelManobraViewModel = await ObterResponsavelManobra(id);

            if (responsavelManobraViewModel == null) return NotFound();
            await _responsavelManobraService.Remover(id);

            if (!OperacaoValida()) return View(responsavelManobraViewModel);

            TempData["Sucesso"] = "Registro excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private async Task<ResponsavelManobraViewModel> PopularManobristasCarros(ResponsavelManobraViewModel responsavelManobra)
        {
            responsavelManobra.Manobristas = _mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos());
            responsavelManobra.Carros = _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterTodos());

            return responsavelManobra;
        }

        private async Task<ResponsavelManobraViewModel> ObterResponsavelManobra(Guid id)
        {
            var responsavelManobra = _mapper.Map<ResponsavelManobraViewModel>(await _responsavelManobraRepository.ObterResponsavelManobristaCarro(id));
            responsavelManobra.Manobristas = _mapper.Map<IEnumerable<ManobristaViewModel>>(await _manobristaRepository.ObterTodos());
            responsavelManobra.Carros = _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterTodos());

            return responsavelManobra;
        }

    }
}
