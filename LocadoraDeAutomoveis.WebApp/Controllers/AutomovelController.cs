using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class AutomovelController : WebControllerBase
    {
        private readonly AutomovelService service;
        private readonly GrupoAutomoveisService serviceGrupo;
        private readonly IMapper mapeador;

        public AutomovelController(AutomovelService service, IMapper mapeador, GrupoAutomoveisService serviceGrupo)
        {
            this.service = service;
            this.mapeador = mapeador;
            this.serviceGrupo = serviceGrupo;
        }

        public IActionResult Listar()
        {
            var resultado = service.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var automoveis = resultado.Value;

            var listarAutomoveisVm = mapeador.Map<IEnumerable<ListarAutomoveisViewModel>>(automoveis);

            return View(listarAutomoveisVm);
        }

        public IActionResult Inserir()
        {
            return View(CarregarDados());
        }

        [HttpPost]
        public IActionResult Inserir(InserirAutomovelViewModel inserirAutomovelVm)
        {
            if (!ModelState.IsValid)
                return View(inserirAutomovelVm);

            var novoAutomovel = mapeador.Map<Automovel>(inserirAutomovelVm);

            var resultado = service.Inserir(novoAutomovel);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{novoAutomovel.Id}] foi inserido com sucesso!");

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

            var resultadoGrupo = serviceGrupo.SelecionarTodos();

            if(resultadoGrupo.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupo.ToResult());

                return null;
            }

            var automovel = resultado.Value;

            var editarAutomovelVm = mapeador.Map<EditarAutomovelViewModel>(automovel);

            var gruposDisponiveis = resultadoGrupo.Value;

            editarAutomovelVm.GrupoAutomovel = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return View(editarAutomovelVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarAutomovelViewModel editarAutomovelVm)
        {
            if (!ModelState.IsValid)
                return View(editarAutomovelVm);

            var automovel = mapeador.Map<Automovel>(editarAutomovelVm);

            var resultado = service.Editar(automovel, editarAutomovelVm.GrupoAutomovelId);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{automovel.Id}] foi atualizado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var automovel = resultado.Value;

            var detalhesAutomovelVm = mapeador.Map<DetalhesAutomovelViewModel>(automovel);

            return View(detalhesAutomovelVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesAutomovelViewModel detalhesAutomovelVm)
        {
            var resultado = service.Excluir(detalhesAutomovelVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{detalhesAutomovelVm.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = service.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var automovel = resultado.Value;

            var detalhesAutomovelVm = mapeador.Map<DetalhesAutomovelViewModel>(automovel);

            return View(detalhesAutomovelVm);
        }

        private InserirAutomovelViewModel? CarregarDados(InserirAutomovelViewModel? dadosPrevios = null)
        {
            var resultadoGrp = serviceGrupo.SelecionarTodos();

            if(resultadoGrp.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrp.ToResult());

                return null;
            }

            var gruposDisponiveis = resultadoGrp.Value;

            if (dadosPrevios is null)
            {
                var inserirAutomovelVm = new InserirAutomovelViewModel
                {
                    GrupoAutomovel = gruposDisponiveis
                        .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
                };
                return inserirAutomovelVm;
            }

            dadosPrevios.GrupoAutomovel = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }
}
