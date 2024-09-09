using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class ConfiguracaoController : WebControllerBase
    {
        private readonly ConfiguracaoService service;
        private readonly IMapper mapeador;

        public ConfiguracaoController(AutenticacaoService autenticacaoService,ConfiguracaoService service, IMapper mapeador) : base(autenticacaoService)
        {
            this.service = service;
            this.mapeador = mapeador;
        }

        public IActionResult Inserir()
        {
            return View(new InserirConfiguracaoViewModel());
        }

        [HttpPost]
        public IActionResult Inserir(InserirConfiguracaoViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(inserirVm);

            var configuracao = mapeador.Map<Configuracao>(inserirVm);

            var resultado = service.Inserir(configuracao);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(inserirVm);
            }

            ApresentarMensagemSucesso($"A configuração ID [{configuracao.Id}] inserida com sucesso!");

            return RedirectToAction();
        }

        public IActionResult Editar(int id)
        {
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Inserir));
            }

            var configuracao = resultado.Value;

            var editarConfiguracaoVm = mapeador.Map<EditarConfiguracaoViewModel>(configuracao);

            return View(editarConfiguracaoVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarConfiguracaoViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(editarVm);

            var configuracao = mapeador.Map<Configuracao>(editarVm);

            var resultado = service.Editar(configuracao);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(editarVm);
            }

            ApresentarMensagemSucesso($"A configuração ID [{configuracao.Id}] editada com sucesso!");

            return RedirectToAction(nameof(Inserir));
        }
       
    }
}
