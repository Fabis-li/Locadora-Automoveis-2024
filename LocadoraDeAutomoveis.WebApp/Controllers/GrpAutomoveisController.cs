using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Extensions;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class GrpAutomoveisController : WebControllerBase
    {
        private readonly GrpAutomoveisService servicoGrpAutomoveis;
        private readonly IMapper mapeador;

        public GrpAutomoveisController(GrpAutomoveisService servicoGrpAutomoveis, IMapper mapeador)
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
            }

            var gruposViewModel = mapeador.Map<IEnumerable<GrpAutomoveisViewModel>>(grupos.Value);

            ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

            return View(gruposViewModel);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(InserirGrpAutomoveisViewModel inserirGrpAutomoveisVm)
        {
            var novoGrupo = mapeador.Map<GrpAutomoveis>(inserirGrpAutomoveisVm);

            var resultado = servicoGrpAutomoveis.Inserir(novoGrupo);

            if(resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{novoGrupo.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IAsyncResult Editar(int id)
        {
            var grupo = servicoGrpAutomoveis.SelecionarPorId(id);

            if (grupo.IsFailed)
            {
                ApresentarMensagemFalha(grupo.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var editarGrupoViewModel = mapeador.Map<EditarGrpAutomoveisViewModel>(grupo.Value);

            return View(editarGrupoViewModel);
        }

        [HttpPost]
        public IActionResult Editar(EditarGrpAutomoveisViewModel editarGrupoVm)
        {
            var grupo = mapeador.Map<GrpAutomoveis>(editarGrupoVm);

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
            
            var detalhesGrpAutomoveisViewModel = mapeador.Map<DetalhesGrpAutomoveisViewModel>(resultado.Value);

            return View(detalhesGrpAutomoveisViewModel);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesGrpAutomoveisViewModel detalhesGrupoVm)
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

            var detalhesGrpAutomoveisViewModel = mapeador.Map<DetalhesGrpAutomoveisViewModel>(grupo.Value);

            return View(detalhesGrpAutomoveisViewModel);
        }
    }
}
