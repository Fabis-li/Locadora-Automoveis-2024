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
        private readonly ClienteService seriveCliente;
        private readonly IMapper mapeador;

        public CondutorController(CondutorService serviceCondutor, IMapper mapeador, ClienteService seriveCliente)
        {
            this.serviceCondutor = serviceCondutor;
            this.mapeador = mapeador;
            this.seriveCliente = seriveCliente;
        }

        public IActionResult Listar()
        {
            var resultado = serviceCondutor.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var condutores = resultado.Value;

            var listaCondutoresVm = mapeador.Map<IEnumerable<ListarCondutorViewModel>>(condutores);

            return View(listaCondutoresVm);
        }

        public IActionResult SelecionarCliente()
        {
            var resultado = seriveCliente.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var clientes = resultado.Value;

            var selecionarVm = new SelecionarClienteViewModel()
            {
                Clientes = clientes.Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
            };

            return View(selecionarVm);
        }

        [HttpPost]
        public IActionResult SelecionarCliente(SelecionarClienteViewModel selecionarVm)
        {
            if (!ModelState.IsValid)
                return View(selecionarVm);

            int clienteId = selecionarVm.ClienteId;
            bool clienteCondutor = selecionarVm.ClienteCondutor;

            return RedirectToAction("Inserir", new { clienteId, clienteCondutor });
        }

        public IActionResult Inserir(int clienteId, bool clienteCondutor)
        {
            var clienteResult = seriveCliente.SelecionarPorId(clienteId);

            if(clienteResult.IsFailed)
                return RedirectToAction("SelecionarCliente");

            var cliente = clienteResult.Value;

            var viewModel = new InserirCondutorViewModel();

            if (clienteCondutor)
            {
                viewModel.ClienteId = clienteId;
                viewModel.ClienteCondutor = clienteCondutor;
                viewModel.Nome = cliente.Nome;
                viewModel.Telefone = cliente.Telefone;
                viewModel.Cpf = cliente.NumeroDocumento;
            }

            ViewBag.ClienteSelecionado = cliente.Nome;

            return View(viewModel);
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

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O condutor ID [{condutor.Id}] foi inserido com sucesso!");

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
