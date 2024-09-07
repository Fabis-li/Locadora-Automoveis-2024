using AutoMapper;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    [Authorize(Roles = "Empresa")]
    public class FuncionarioController : WebControllerBase
    {
       private readonly FuncionarioService funcionarioService;
       private readonly AutenticacaoService autenticacaoService;
       private readonly IMapper mapeador;

        public FuncionarioController(FuncionarioService funcionarioService, AutenticacaoService autenticacaoService, IMapper mapeador)
        {
            this.funcionarioService = funcionarioService;
            this.autenticacaoService = autenticacaoService;
            this.mapeador = mapeador;
        }

        public async Task<IActionResult> Listar()
        {

            var empresa = autenticacaoService.ObterUsuarioAsync(User);

            var resultado = funcionarioService.SelecionarFuncionariosDaEmpresa(empresa!.Id);

            if(resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());
                return RedirectToAction("Index", "Home");
            }

            var funcionarios = resultado.Value;

            var listarFuncionariosVm = mapeador.Map<IEnumerable<ListarFuncionarioViewModel>>(funcionarios);

            return View(listarFuncionariosVm);
        }

        public IActionResult Inserir()
        {
            return View(new InserirFuncionarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(InserirFuncionarioViewModel inserirFuncionarioVm)
        {
            if (!ModelState.IsValid)
                return View(inserirFuncionarioVm);

            var funcionario = mapeador.Map<Funcionario>(inserirFuncionarioVm);

            var resultado = await funcionarioService.Inserir(funcionario, inserirFuncionarioVm.NomeUsuario ,inserirFuncionarioVm.Senha);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());
                return View(inserirFuncionarioVm);
            }

            ApresentarMensagemSucesso("Funcionário inserido com sucesso!");

            return RedirectToAction("Listar");
        }

    }
}
