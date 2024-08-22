using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class AutomovelController : WebControllerBase
    {
        private readonly AutomovelService service;
        private readonly IMapper mapeador;

        public AutomovelController(AutomovelService service, IMapper mapeador)
        {
            this.service = service;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado = service.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var automoveis = resultado.Value;

            var listarAutomoveisVm = mapeador.Map<IEnumerable<ListarAutomoveisViewModel>>(automoveis);

            return View(listarAutomoveisVm);
        }

        public IActionResult Inserir()
        {
            return View();
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

            var automovel = resultado.Value;

            var editarAutomovelVm = mapeador.Map<EditarAutomovelViewModel>(automovel);

            return View(editarAutomovelVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarAutomovelViewModel editarAutomovelVm)
        {
            if (!ModelState.IsValid)
                return View(editarAutomovelVm);

            var automovel = mapeador.Map<Automovel>(editarAutomovelVm);

            var resultado = service.Editar(automovel);

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

            var excluirAutomovelVm = mapeador.Map<DetalhesAutomovelViewModel>(automovel);

            return RedirectToAction(nameof(Listar));
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
    }
}
