﻿using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using Microsoft.AspNetCore.Identity;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class FuncionarioService
    {
        private readonly IRepositorioFuncionario repositorioFuncionario;
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<Perfil> roleManager;

        public FuncionarioService(IRepositorioFuncionario repositorioFuncionario, UserManager<Usuario> userManager, RoleManager<Perfil> roleManager)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Result<Funcionario>> Inserir(Funcionario funcionario, string nomeUsuario, string senha)
        {
            var usuario = new Usuario()
            {
                UserName = nomeUsuario, 
                Email = funcionario.Email 
            };

            var resultadoCriacaoUsuario = await userManager.CreateAsync(usuario, senha);

            if (!resultadoCriacaoUsuario.Succeeded)            
                return Result.Fail(resultadoCriacaoUsuario.Errors.Select(e => e.Description));
            
            var perfilStr = TipoUsuarioEnum.Funcionario.ToString();

            var resultadoBuscaPerfil = await roleManager.FindByNameAsync(perfilStr);

            if (resultadoBuscaPerfil is null)
            {
                var perfil = new Perfil()
                {
                    Name = perfilStr,
                    NormalizedName = perfilStr.ToUpperInvariant(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                await roleManager.CreateAsync(perfil);
            }

            await userManager.AddToRoleAsync(usuario, perfilStr);

            funcionario.UsuarioId = usuario.Id;

            repositorioFuncionario.Inserir(funcionario);

            return Result.Ok(funcionario);
        }

        public async Task<Result<Funcionario>> Editar(Funcionario funcionario)
        {
           var erros = funcionario.Validar();

            if (erros.Count > 0)
                return Result.Fail(erros);

            repositorioFuncionario.Editar(funcionario);

            return Result.Ok(funcionario);
        }

        public async Task<Result<Funcionario>> Excluir(int funcionarioId)
        {
            var funcionario = repositorioFuncionario.SelecionarPorId(f => f.Id == funcionarioId);

            if (funcionario is null)
                return Result.Fail("Funcionário não foi encontrado!");

            var usuario = await userManager.FindByIdAsync(funcionario.UsuarioId.ToString());

            if (usuario is null)
                return Result.Fail("Usuário não foi encontrado!");

            var resultadoExclusaoUsuario = await userManager.DeleteAsync(usuario);

            if (!resultadoExclusaoUsuario.Succeeded)
                return Result.Fail("Não foi possível excluir o funcionário!");

            repositorioFuncionario.Excluir(funcionario);

            return Result.Ok(funcionario);
        }

        public Result<Funcionario?> SelecionarPorId(int funcionarioId)
        {
            var funcionario = repositorioFuncionario.SelecionarPorId(f => f.Id == funcionarioId);
            

            return Result.Ok(funcionario);
        }

        public Result<List<Funcionario>> SelecionarFuncionariosDaEmpresa(int empresaId)
        {
            var funcionarios = repositorioFuncionario.SelecionarTodos(f => f.EmpresaId == empresaId);

            return Result.Ok(funcionarios);
        }

    }
}
