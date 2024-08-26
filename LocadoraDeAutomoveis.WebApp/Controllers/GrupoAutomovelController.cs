using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Extensions;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class GrupoAutomovelController : WebControllerBase
    {
        private readonly GrupoAutomoveisService servicoGrpAutomoveis;
        private readonly IMapper mapeador;

        public GrupoAutomovelController(GrupoAutomoveisService servicoGrpAutomoveis, IMapper mapeador)
        {
            this.servicoGrpAutomoveis = servicoGrpAutomoveis;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var grupos = servicoGrpAutomoveis.SelecionarTodos();

            if (grupos.IsFailed)
            {
                ApresentarMensagemFalha(grupos.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var grpAutomoveis = grupos.Value;

            var listarGrpAutomoveisVm = mapeador.Map<IEnumerable<ListarGrupoAutomovelViewModel>>(grpAutomoveis);

            ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

            return View(listarGrpAutomoveisVm);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(InserirGrupoAutomovelViewModel inserirGrpAutomoveisVm)
        {
            var novoGrupo = mapeador.Map<GrupoAutomovel>(inserirGrpAutomoveisVm);

            var resultado = servicoGrpAutomoveis.Inserir(novoGrupo);

            if(resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{novoGrupo.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Editar(int id)
        {
            var grupo = servicoGrpAutomoveis.SelecionarPorId(id);

            if (grupo.IsFailed)
            {
                ApresentarMensagemFalha(grupo.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var editarGrupoViewModel = mapeador.Map<EditarGrupoAutomovelViewModel>(grupo.Value);

            return View(editarGrupoViewModel);
        }

        [HttpPost]
        public IActionResult Editar(EditarGrupoAutomovelViewModel editarGrupoVm)
        {
            var grupo = mapeador.Map<GrupoAutomovel>(editarGrupoVm);

            var resultado = servicoGrpAutomoveis.Editar(grupo);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi atualizado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = servicoGrpAutomoveis.Excluir(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }
            
            var detalhesGrpAutomoveisViewModel = mapeador.Map<DetalhesGrupoAutomovelViewModel>(resultado.Value);

            return View(detalhesGrpAutomoveisViewModel);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesGrupoAutomovelViewModel detalhesGrupoVm)
        {
            var resultado = servicoGrpAutomoveis.Excluir(detalhesGrupoVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{detalhesGrupoVm.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Detalhes(int id)
        {
            var grupo = servicoGrpAutomoveis.SelecionarPorId(id);

            if (grupo.IsFailed)
            {
                ApresentarMensagemFalha(grupo.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var detalhesGrpAutomoveisViewModel = mapeador.Map<DetalhesGrupoAutomovelViewModel>(grupo.Value);

            return View(detalhesGrpAutomoveisViewModel);
        }
    }
}
