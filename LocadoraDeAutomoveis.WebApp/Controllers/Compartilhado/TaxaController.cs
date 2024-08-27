using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado
{
    public class TaxaController : WebControllerBase
    {
        private readonly TaxaService taxaService;
        private readonly IMapper mapeador;

        public IActionResult Listar()
        {
            var resultado = taxaService.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index","Inicio");
            }

            var taxas = resultado.Value;

            var taxasViewModel = mapeador.Map<List<TaxaViewModel>>(taxas);

            return View(taxasViewModel);
        }

        public IActionResult Inserir()
        {
            return View(new InserirTaxaViewModel);
        }

        [HttpPost]
        public IActionResult Inserir(InserirTaxaViewModel inserirVm)
        {
            if (!ModelState.IsValid)
            {
                return View(inserirVm);
            }

            var taxa = mapeador.Map<Taxa>(inserirTaxaViewModel);

            var resultado = taxaService.Inserir(taxa);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof("Listar"));
        }

        public IActionResult Editar(int id)
        {
            var resultado = taxaService.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var taxa = resultado.Value;

            var taxaVm = mapeador.Map<EditarTaxaViewModel>(taxa);

            return View(taxaVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarTaxaViewModel editarVm)
        {
            if (!ModelState.IsValid)
            {
                return View(editarVm);
            }

            var taxa = mapeador.Map<Taxa>(editarVm);

            var resultado = taxaService.Editar(taxa);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi atualizado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = taxaService.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var taxa = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesTaxaViewModel>(taxa);

            return View (detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesTaxaViewModel detalhesVm)
        {
            var resultado = taxaService.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = taxaService.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var taxa = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesTaxaViewModel>(taxa);

            return View(detalhesVm);
        }
    }
    
}
