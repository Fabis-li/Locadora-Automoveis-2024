using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class AutenticacaoController : WebControllerBase
    {
        private readonly AutenticacaoService autenticacaoService;

        public AutenticacaoController(AutenticacaoService autenticacaoService) : base(autenticacaoService)
        {
            this.autenticacaoService = autenticacaoService;
        }

        public IActionResult Registrar()
        {
            return View(new RegistrarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarViewModel registrarVm)
        {
           if(!ModelState.IsValid)
                return View(registrarVm);

            //criando nova instancia de usuario
            var usuario = new Usuario()
            {
                UserName = registrarVm.Usuario,
                Email = registrarVm.Email
            };

            var senha = registrarVm.Senha!;

            var resultado = await autenticacaoService.Registrar(usuario, senha, TipoUsuarioEnum.Empresa);

            if(resultado.IsSuccess)
                return RedirectToAction("Index", "Home");

            foreach (var erro in resultado.Errors)
                ModelState.AddModelError(string.Empty, erro.Message);
            
            return View(registrarVm);
        }

        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm, string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
                return View(loginVm);

            var resultado = await autenticacaoService.Login(loginVm.Usuario!, loginVm.Senha!);

            if (resultado.IsSuccess)
                return LocalRedirect(returnUrl ?? "/");

            var msgErro = resultado.Errors.First().Message;  //extração da primeira mensagem de erro

            ModelState.AddModelError(string.Empty, msgErro);

            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await autenticacaoService.Logout();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
