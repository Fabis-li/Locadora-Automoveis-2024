using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class PlanoCobrancaController : WebControllerBase
    {
        private readonly PlanoCobrancaService service;
        private readonly GrupoAutomoveisService serviceGrupo;
        private readonly IMapper mapeador;


        public PlanoCobrancaController(PlanoCobrancaService service, GrupoAutomoveisService serviceGrupo, IMapper mapeador)
        {
            this.service = service;
            this.serviceGrupo = serviceGrupo;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado = service.SelecionarTodos();

            if(resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var planosCobranca = resultado.Value;

            var listarPlanoCobrancaVm = mapeador.Map<IEnumerable<ListarPlanoCobrancaViewModel>>(planosCobranca);

            return View(listarPlanoCobrancaVm);
        }
        public IActionResult Inserir()
        {
            return View(CarregarDados());
        }

        [HttpPost]
        public IActionResult Inserir(InserirPlanoCobrancaViewModel inserirPlanoCobrancaVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDados(inserirPlanoCobrancaVm));

            var novoPlanoCobranca = mapeador.Map<PlanoCobranca>(inserirPlanoCobrancaVm);

            var resultado = service.Inserir(novoPlanoCobranca);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro [{novoPlanoCobranca.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Editar(int id)
        {
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var grupos = serviceGrupo.SelecionarTodos().Value;

            var planoCobranca = resultado.Value;

            var editarPlanoCobrancaVm = mapeador.Map<EditarPlanoCobrancaViewModel>(planoCobranca);


            editarPlanoCobrancaVm.GrupoAutomovel = grupos
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return View(editarPlanoCobrancaVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarPlanoCobrancaViewModel editarPlanoCobrancaVm)
        {
            if (!ModelState.IsValid)
                return View(editarPlanoCobrancaVm);

            var planoCobranca = mapeador.Map<PlanoCobranca>(editarPlanoCobrancaVm);

            var resultado = service.Editar(planoCobranca);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro [{planoCobranca.Id}] foi editado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = service.Excluir(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var planoCobranca = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesPlanoCobrancaViewModel>(planoCobranca);

            ApresentarMensagemSucesso($"O registro [{id}] foi excluído com sucesso!");

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesPlanoCobrancaViewModel detalhesPlanoCobrancaVm)
        {
            var resultado = service.Excluir(detalhesPlanoCobrancaVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro [{detalhesPlanoCobrancaVm.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        private InserirPlanoCobrancaViewModel? CarregarDados(InserirPlanoCobrancaViewModel dadosPrevios = null)
        {
            var resultadoGrupo = serviceGrupo.SelecionarTodos();

            if (resultadoGrupo.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupo.ToResult());

                return null;
            }

            var grupoAutomovelLista = resultadoGrupo.Value
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
                .ToList();

            if (dadosPrevios is null)
            {
                var inserirPlanoCobrancaVm = new InserirPlanoCobrancaViewModel
                {
                    GrupoAutomovel = grupoAutomovelLista
                };

                return inserirPlanoCobrancaVm;
            }

            dadosPrevios.GrupoAutomovel = resultadoGrupo.Value
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }
}
