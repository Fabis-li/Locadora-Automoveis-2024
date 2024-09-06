using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class ClienteController : WebControllerBase
    {
        private readonly ClienteService service;
        private readonly IMapper mapeador;

        public ClienteController(ClienteService service, IMapper mapeador)
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

                return RedirectToAction("Index", "Home");
            }

            var clientes = resultado.Value;

            var listarClientesVm = mapeador.Map<IEnumerable<ListarClienteViewModel>>(clientes);

            return View(listarClientesVm);
        }

        public IActionResult Inserir()
        {
            return View(new InserirClienteViewModel());
        }

        [HttpPost]
        public IActionResult Inserir(InserirClienteViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(inserirVm);

            var cliente = mapeador.Map<Cliente>(inserirVm);

            var resultado = service.Inserir(cliente);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(inserirVm);
            }

            ApresentarMensagemSucesso($"O cliente ID [{cliente.Id}] inserido com sucesso!");

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

            var cliente = resultado.Value;

            var editarVm = mapeador.Map<EditarClienteViewModel>(cliente);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarClienteViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(editarVm);

            var cliente = mapeador.Map<Cliente>(editarVm);

            var resultado = service.Editar(cliente);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(editarVm);
            }

            ApresentarMensagemSucesso($"O cliente ID [{cliente.Id}] editado com sucesso!");

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

            var cliente = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesClienteViewModel>(cliente);

            return RedirectToAction(nameof(Listar));
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesClienteViewModel detalhesVm)
        {
            var resultado = service.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(detalhesVm);
            }

            ApresentarMensagemSucesso($"O cliente ID [{detalhesVm.Id}] excluído com sucesso!");

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

            var cliente = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesClienteViewModel>(cliente);

            return View(detalhesVm);
        }
    }
}
