using FluentResults;
using LocadoraDeAutomoveis.WebApp.Extensions;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeAutomovies.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado
{
    public class WebControllerBase : Controller
    {
        protected readonly AutenticacaoService serviceAutenticacao;

        public int? EmpresaId
        {
            get
            {
                var empresaId = serviceAutenticacao.ObterIdEmpresaAsync(User).Result;

                return empresaId;
            }
        }
        protected WebControllerBase(AutenticacaoService serviceAutenticacao)
        {
            this.serviceAutenticacao = serviceAutenticacao;
        }

        protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Erro",
                Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
            });

            return RedirectToAction("Index", "Home");
        }

        protected void ApresentarMensagemFalha(Result resultado)
        {
            ViewBag.Mensagem = new MensagemViewModel
            {
                Titulo = "Falha",
                Mensagem = resultado.Errors[0].Message
            };
        }

        protected void ApresentarMensagemSucesso(string mensagem)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = mensagem
            });
        }
    }
}
