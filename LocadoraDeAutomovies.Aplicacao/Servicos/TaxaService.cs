using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;

namespace LocadoraDeAutomovies.Aplicacao.Servicos
{
    public class TaxaService
    {
        private readonly IRepositorioTaxa repositorioTaxa;

        public TaxaService(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            var errosValidacao = taxa.Validar();

            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);
           

            repositorioTaxa.Inserir(taxa);

            return Result.Ok(taxa);
        }

        public Result<Taxa> Editar(Taxa taxaAtualizada)
        {
            var taxa = repositorioTaxa.SelecionarPorId(taxaAtualizada.Id);

            if (taxa is null)
                return Result.Fail("Taxa não encontrada!");
            

            var errosValidacao = taxaAtualizada.Validar();

            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);
           
            taxa.Nome = taxaAtualizada.Nome;
            taxa.Valor = taxaAtualizada.Valor;
            taxa.TipoCobranca = taxaAtualizada.TipoCobranca;

            repositorioTaxa.Editar(taxa);

            return Result.Ok(taxa);
        }

        public Result<Taxa> Excluir(int taxaId)
        {
            var taxa = repositorioTaxa.SelecionarPorId(taxaId);

            if (taxa is null)
                return Result.Fail("Taxa não encontrada!");

            repositorioTaxa.Excluir(taxa);

            return Result.Ok(taxa);
        }

        public Result<Taxa> SelecionarPorId(int taxaId)
        {
            var taxa = repositorioTaxa.SelecionarPorId(taxaId);

            if (taxa is null)
                return Result.Fail("Taxa não encontrada!");

            return Result.Ok(taxa);
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            var taxas = repositorioTaxa.SelecionarTodos();

            return Result.Ok(taxas);
        }
    }
}
