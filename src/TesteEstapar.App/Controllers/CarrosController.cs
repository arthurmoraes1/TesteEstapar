using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteEstapar.App.ViewModels;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Business.Models;

namespace TesteEstapar.App.Controllers
{
    public class CarrosController : BaseController
    {
        private readonly ICarroRepository _carrosRepository;
        private readonly IMapper _mapper;
        private readonly ICarroService _carroService;
        public CarrosController(ICarroRepository carrosRepository, 
                                IMapper mapper, ICarroService carroService,
                                INotificador notificador) : base(notificador)
        {
            _carrosRepository = carrosRepository;
            _mapper = mapper;
            _carroService = carroService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CarroViewModel>>(await _carrosRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var carroViewModel = await ObterCarro(id);
            if (carroViewModel == null)
            {
                return NotFound();
            }

            return View(carroViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid) return View(carroViewModel);

            var carro = _mapper.Map<Carro>(carroViewModel);
            await _carroService.Adicionar(carro);

            if (!OperacaoValida()) return View(carroViewModel);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var carroViewModel = await ObterCarro(id);
            if (carroViewModel == null)
            {
                return NotFound();
            }

            return View(carroViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CarroViewModel carroViewModel)
        {
            if (id != carroViewModel.Id) return NotFound();

            var carroAtualizacao = await ObterCarro(id);

            if (!ModelState.IsValid) return View(carroViewModel);

            carroAtualizacao.Marca = carroViewModel.Marca;
            carroAtualizacao.Modelo = carroViewModel.Modelo;
            carroAtualizacao.Placa = carroViewModel.Placa.Remove(3,1);

            await _carroService.Atualizar(_mapper.Map<Carro>(carroAtualizacao));
            
            
            
            if (!OperacaoValida()) return View(carroViewModel);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var carroViewModel = await ObterCarro(id);
            if (carroViewModel == null) return NotFound();

            return View(carroViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carroViewModel = await ObterCarro(id);

            if (carroViewModel == null) return NotFound();
            await _carroService.Remover(id);

            if (!OperacaoValida()) return View(carroViewModel);

            TempData["Sucesso"] = "Carro excluido com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private async Task<CarroViewModel> ObterCarro(Guid id)
        {
            var carro = _mapper.Map<CarroViewModel>(await _carrosRepository.ObterCarro(id));

            return carro;
        }
    }
}
