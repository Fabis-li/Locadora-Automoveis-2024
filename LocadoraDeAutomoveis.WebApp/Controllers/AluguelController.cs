using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class AluguelController : WebControllerBase
    {
        private readonly AluguelService servico;
        private readonly ClienteService serviceCliente;
        private readonly AutomovelService serviceAutomovel;
        private readonly PlanoCobrancaService servicePlanoCobranca;
        private readonly CondutorService serviceCondutor;
        private readonly GrupoAutomoveisService serviceGrupoAutomovel;
        private readonly IMapper mapeador;

        public AluguelController(AluguelService servico, ClienteService serviceCliente, AutomovelService serviceAutomovel, PlanoCobrancaService servicePlanoCobranca, CondutorService serviceCondutor, GrupoAutomoveisService serviceGrupoAutomovel, IMapper mapeador)
        {
            this.servico = servico;
            this.serviceCliente = serviceCliente;
            this.serviceAutomovel = serviceAutomovel;
            this.servicePlanoCobranca = servicePlanoCobranca;
            this.serviceCondutor = serviceCondutor;
            this.serviceGrupoAutomovel = serviceGrupoAutomovel;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado = servico.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Inicio");
            }

            var alugueis = resultado.Value;

            var listarAlugueisVm = mapeador.Map<ListarAluguelViewModel>(alugueis);

            return View(listarAlugueisVm);
        }

        public IActionResult Inserir()
        {
            return View(new InserirAluguelViewModel());
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

            ApresentarMensagemSucesso("Aluguel inserido com sucesso!");

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

            ApresentarMensagemSucesso("Aluguel editado com sucesso!");

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

            ApresentarMensagemSucesso("Aluguel excluído com sucesso!");

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

        public IActionResult Concluir(ConcluirAluguelViewModel concluirVm)
        {
            if(!ModelState.IsValid)
                return View(concluirVm);

            var resultado = servico.Concluir(concluirVm.Id, concluirVm.KmFinal);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(concluirVm);
            }

            var aluguel = resultado.Value;

            

            ApresentarMensagemSucesso("Aluguel concluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

    }
}
