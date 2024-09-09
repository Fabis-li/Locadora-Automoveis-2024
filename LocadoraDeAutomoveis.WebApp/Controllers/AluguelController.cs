using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class AluguelController : WebControllerBase
    {
        private readonly AluguelService servico;
        private readonly AutomovelService serviceAutomovel;
        private readonly CondutorService serviceCondutor;
        private readonly TaxaService serviceTaxa;
        private readonly IMapper mapeador;

        public AluguelController(AutenticacaoService autenticacaoService,AluguelService servico ,AutomovelService serviceAutomovel, CondutorService serviceCondutor, IMapper mapeador, TaxaService serviceTaxa) : base(autenticacaoService)
        {
            this.servico = servico;
            this.serviceAutomovel = serviceAutomovel;
            this.serviceCondutor = serviceCondutor;
            this.mapeador = mapeador;
            this.serviceTaxa = serviceTaxa;
        }

        public IActionResult Listar()
        {
            var resultado = servico.SelecionarTodos(EmpresaId.GetValueOrDefault());

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var alugueis = resultado.Value;

            var listarAlugueisVm = mapeador.Map<IEnumerable<ListarAluguelViewModel>>(alugueis);

            return View(listarAlugueisVm);
        }

        public IActionResult Inserir()
        {
            return View(CarregarDados());
        }

        [HttpPost]
        public IActionResult Inserir(InserirAluguelViewModel inserirVm)
        {
            var aluguel = mapeador.Map<Aluguel>(inserirVm);

            var resultado = servico.Inserir(aluguel);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(inserirVm);
            }

            ApresentarMensagemSucesso($"O Aluguel ID [{aluguel.Id}] foi inserido com sucesso!");

            return RedirectToAction("Listar");
        }

        public IActionResult Editar(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var aluguel = resultado.Value;

            var editarVm = mapeador.Map<EditarAluguelViewModel>(aluguel);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarAluguelViewModel editarVm)
        {
            var aluguel = mapeador.Map<Aluguel>(editarVm);

            var resultado = servico.Editar(aluguel);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(editarVm);
            }

            ApresentarMensagemSucesso($"O Aluguel ID [{aluguel.Id}] foi editado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = servico.Excluir(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var Aluguel = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesAluguelViewModel>(Aluguel);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesAluguelViewModel detalhesVm)
        {
            var resultado = servico.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(detalhesVm);
            }

            ApresentarMensagemSucesso($"O Aluguel [{detalhesVm.Id}] excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var aluguel = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesAluguelViewModel>(aluguel);

            return View(detalhesVm);
        }

        public IActionResult Concluir(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var aluguel = resultado.Value;

            var concluirVm = mapeador.Map<ConcluirAluguelViewModel>(aluguel);

            return View(concluirVm);
        }

        [HttpPost]
        public IActionResult Concluir(ConcluirAluguelViewModel concluirVm)
        {
            var AluguelOriginal = servico.SelecionarPorId(concluirVm.Id).Value;

            var AluguelAtualizado = mapeador.Map<ConcluirAluguelViewModel, Aluguel>(concluirVm, AluguelOriginal);

            var resultado = servico.Concluir(AluguelAtualizado);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(concluirVm);
            }

            ApresentarMensagemSucesso($"O Aluguel ID [{AluguelAtualizado.Id}] foi concluído com sucesso!");

            return RedirectToAction(nameof(Listar));
            
        }

        public IActionResult Devolucao(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var aluguel = resultado.Value;

            var devolverVm = mapeador.Map<DevolucaoAluguelViewModel>(aluguel);

            return View(devolverVm);
        }

        [HttpPost]
        public IActionResult Devolucao(DevolucaoAluguelViewModel devolverVm)
        {
            var AluguelOriginal = servico.SelecionarPorId(devolverVm.Id).Value;

            var AluguelAtualizado = mapeador.Map<DevolucaoAluguelViewModel, Aluguel>(devolverVm, AluguelOriginal);

            var resultado = servico.Devolver(AluguelAtualizado);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(devolverVm);
            }

            var concluir = servico.Concluir(AluguelAtualizado);

            if(concluir.IsFailed)
            {
                ApresentarMensagemFalha(concluir.ToResult());

                return View(devolverVm);
            }

            ApresentarMensagemSucesso($"O Aluguel ID [{AluguelAtualizado.Id}] foi devolvido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }



        private InserirAluguelViewModel CarregarDados(InserirAluguelViewModel? dadosPrevisto = null)
        {
            var condutores = serviceCondutor.SelecionarTodos(EmpresaId.GetValueOrDefault()).Value;
            var automoveis = serviceAutomovel.SelecionarTodos(EmpresaId.GetValueOrDefault()).Value;
            var taxas = serviceTaxa.SelecionarTodos(EmpresaId.GetValueOrDefault()).Value;

            if(dadosPrevisto is null)
                dadosPrevisto = new InserirAluguelViewModel();

            dadosPrevisto.Condutores = condutores.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
            dadosPrevisto.Automoveis = automoveis.Select(c => new SelectListItem(c.Modelo, c.Id.ToString()));
            dadosPrevisto.Taxas= taxas.Select(c => new SelectListItem(c.ToString(), c.Id.ToString()));

            return dadosPrevisto;
        }

    }

}
