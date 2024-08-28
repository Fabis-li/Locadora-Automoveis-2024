using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class ConfiguracaoService
    {
        private readonly IRepositorioConfiguracao repositorioConfiguracao;

        public ConfiguracaoService(IRepositorioConfiguracao repositorioConfiguracao)
        {
            this.repositorioConfiguracao = repositorioConfiguracao;
        }

        public Result<Configuracao> Inserir(Configuracao configuracao)
        {
            repositorioConfiguracao.Inserir(configuracao);

            return Result.Ok(configuracao);
        }

        public Result<Configuracao> Editar(Configuracao configuracaoatualizada)
        {
            var configuracao = repositorioConfiguracao.SelecionarPorId(configuracaoatualizada.Id);

            if (configuracao is null)
                return Result.Fail("A configuração não foi encontrada!");

            configuracao.PrecoGasolina = configuracaoatualizada.PrecoGasolina;
            configuracao.PrecoAlcool = configuracaoatualizada.PrecoAlcool;
            configuracao.PrecoDiesel = configuracaoatualizada.PrecoDiesel;
            configuracao.PrecoGas = configuracaoatualizada.PrecoGas;

            repositorioConfiguracao.Editar(configuracao);

            return Result.Ok(configuracao);
        }

        public Result<Configuracao> Excluir(int configuracaoid)
        {
            var configuracao = repositorioConfiguracao.SelecionarPorId(configuracaoid);

            if (configuracao is null)
                return Result.Fail("A configuração não foi encontrada!");

            repositorioConfiguracao.Excluir(configuracao);

            return Result.Ok(configuracao);
        }

        public Result<Configuracao> SelecionarPorId(int configuracaoid)
        {
            var configuracao = repositorioConfiguracao.SelecionarPorId(configuracaoid);

            if (configuracao is null)
                return Result.Fail("A configuração não foi encontrada!");

            return Result.Ok(configuracao);
        }

        public Result<List<Configuracao>> SelecionarTodos()
        {
            var configuracoes = repositorioConfiguracao.SelecionarTodos();

            if (configuracoes.Count == 0)
                return Result.Fail<List<Configuracao>>("Nenhuma configuração encontrada!");

            return Result.Ok(configuracoes);
        }
    }
}
