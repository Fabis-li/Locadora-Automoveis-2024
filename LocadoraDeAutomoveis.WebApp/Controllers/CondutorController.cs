using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class CondutorController : WebControllerBase
    {
        private readonly CondutorService serviceCondutor;
        private readonly ClienteService serviceCliente;
        private readonly IMapper mapeador;

        public CondutorController(CondutorService serviceCondutor, IMapper mapeador, ClienteService serviceCliente)
        {
            this.serviceCondutor = serviceCondutor;
            this.mapeador = mapeador;
            this.serviceCliente = serviceCliente;
        }

        public IActionResult Listar()
        {
            var resultado = serviceCondutor.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var condutores = resultado.Value;

            var listaCondutoresVm = mapeador.Map<IEnumerable<ListarCondutorViewModel>>(condutores);

            return View(listaCondutoresVm);
        }

        public IActionResult Inserir()
        {
            var clientes = serviceCliente.SelecionarTodos();

            if (clientes.IsFailed)
            {
                ApresentarMensagemFalha(clientes.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var clientesSelecionados = clientes.Value;

            var inserirVm = new InserirCondutorViewModel()
            {
                Clientes = clientesSelecionados.Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
            };

            return View(inserirVm);
        }

        [HttpPost]
        public IActionResult Inserir(InserirCondutorViewModel inserirVm)
        {
            if (!ModelState.IsValid)
            {
                return View(inserirVm);
            }

            var condutor = mapeador.Map<Condutor>(inserirVm);

            var resultado = serviceCondutor.Inserir(condutor);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(inserirVm);
            }

            ApresentarMensagemSucesso($"O condutor ID [{condutor.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Editar(int id)
        {
            var resultado = serviceCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var condutor = resultado.Value;

            var editarVm = mapeador.Map<EditarCondutorViewModel>(condutor);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarCondutorViewModel editarVm)
        {
            if (!ModelState.IsValid)
            {
                return View(editarVm);
            }

            var condutor = mapeador.Map<Condutor>(editarVm);

            var resultado = serviceCondutor.Editar(condutor);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(editarVm);
            }

            ApresentarMensagemSucesso($"O condutor ID [{condutor.Id}] foi editado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = serviceCondutor.Excluir(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var condutor = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesCondutorViewModel>(condutor);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesCondutorViewModel detalhesVm)
        {
            var resultado = serviceCondutor.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(detalhesVm);
            }

            ApresentarMensagemSucesso($"O condutor ID [{detalhesVm.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = serviceCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var condutor = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesCondutorViewModel>(condutor);

            return View(detalhesVm);
        }
    }
}
