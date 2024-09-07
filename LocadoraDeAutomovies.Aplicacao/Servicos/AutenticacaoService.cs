﻿using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class AutenticacaoService
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly RoleManager<Perfil> roleManager;

        public AutenticacaoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, RoleManager<Perfil> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<Result<Usuario>> Registrar(Usuario usuario, string senha, TipoUsuarioEnum tipoUsuario)
        {
            var resultadoCriacaoUsuario = await userManager.CreateAsync(usuario, senha);

            var tipoUsuarioStr = tipoUsuario.ToString();

            var resultadoBuscaTipoUsuario = await roleManager.FindByNameAsync(tipoUsuarioStr);

            if (resultadoBuscaTipoUsuario is null)
            {
                var perfil = new Perfil()
                {
                    Name = tipoUsuarioStr,
                    NormalizedName = tipoUsuarioStr.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                await roleManager.CreateAsync(perfil);
            }

            await userManager.AddToRoleAsync(usuario, tipoUsuarioStr);

            if(resultadoCriacaoUsuario.Succeeded && tipoUsuario == TipoUsuarioEnum.Empresa)
            {
                await signInManager.SignInAsync(usuario, isPersistent: false);
            }
            else if(!resultadoCriacaoUsuario.Succeeded)
            {
                var erros = resultadoCriacaoUsuario.Errors.Select(e => e.Description);

                return Result.Fail(erros);
            }

            return Result.Ok(usuario);
        }

        public async Task<Result> Login(string usuario, string senha)
        {
            var resultadoLogin = await signInManager.PasswordSignInAsync(
                usuario,
                senha,
                isPersistent: false, 
                lockoutOnFailure: false
            );

            if(!resultadoLogin.Succeeded)
                return Result.Fail("Usuário ou senha inválidos");
            
            return Result.Ok();
        }

        public async Task<Result> Logout()
        {
            await signInManager.SignOutAsync();

            return Result.Ok();
        }
    }
}