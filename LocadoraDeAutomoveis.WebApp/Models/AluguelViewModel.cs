using System.ComponentModel.DataAnnotations;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirAluguelViewModel
    {
        [Required(ErrorMessage = "O campo Cliente é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo Automóvel é obrigatório")]
        public int AutomovelId { get; set; }

        [Required(ErrorMessage = "O campo Plano de Cobrança é obrigatório")]
        public int PlanoCobrancaId { get; set; }

        [Required(ErrorMessage = "O campo Condutor é obrigatório")]
        public int CondutorId { get; set; }

        [Required(ErrorMessage = "O campo Data de Início é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataSaida { get; set; }

        [Required(ErrorMessage = "O campo Data de Fim é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataRetorno { get; set; }

        [Required(ErrorMessage = "O campo Valor Total é obrigatório")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O marcador de combustível é obrigatório")]
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        [Required(ErrorMessage = "O tipo de plano é obrigatório")]
        public TipoPlanoCobrancaEnum TipoPlanoCobranca { get; set; }

        [Required(ErrorMessage = "O campo Km Rodado é obrigatório")]
        public int KmRodado { get; set; }

        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<SelectListItem> Automoveis { get; set; }
        public IEnumerable<PlanoCobranca> PlanosCobranca { get; set; }
        public IEnumerable<SelectListItem> Condutores { get; set; }
        public IEnumerable<SelectListItem> TaxasEscolhidas { get; set; }

    }

    public class EditarAluguelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo Automóvel é obrigatório")]
        public int AutomovelId { get; set; }

        [Required(ErrorMessage = "O campo Plano de Cobrança é obrigatório")]
        public int PlanoCobrancaId { get; set; }

        [Required(ErrorMessage = "O campo Condutor é obrigatório")]
        public int CondutorId { get; set; }

        [Required(ErrorMessage = "O campo Data de Início é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataSaida { get; set; }

        [Required(ErrorMessage = "O campo Data de Fim é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataRetorno { get; set; }

        [Required(ErrorMessage = "O campo Valor Total é obrigatório")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O marcador de combustível é obrigatório")]
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        [Required(ErrorMessage = "O tipo de plano é obrigatório")]
        public TipoPlanoCobrancaEnum TipoPlanoCobranca { get; set; }

        [Required(ErrorMessage = "O campo Km Rodado é obrigatório")]
        public int KmRodado { get; set; }

        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<SelectListItem> Automoveis { get; set; }
        public IEnumerable<PlanoCobranca> PlanosCobranca { get; set; }
        public IEnumerable<SelectListItem> Condutores { get; set; }
        public IEnumerable<SelectListItem> TaxasEscolhidas { get; set; }

    }

    public class ListarAluguelViewModel
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Automovel { get; set; }
        public int PlanoCobranca { get; set; }
        public int Condutor { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public decimal ValorTotal { get; set; }
        public string TipoPlanoCobranca { get; set; }
        public string MarcadorCombustivel { get; set; }
        public int KmRodado { get; set; }
    }

    public class DetalhesAluguelViewModel
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Automovel { get; set; }
        public int PlanoCobranca { get; set; }
        public int Condutor { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public decimal ValorTotal { get; set; }
        public string TipoPlanoCobranca { get; set; }
        public string MarcadorCombustivel { get; set; }
        public int KmRodado { get; set; }
    }

    public class ConcluirAluguelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo Automóvel é obrigatório")]
        public int AutomovelId { get; set; }

        [Required(ErrorMessage = "O campo Plano de Cobrança é obrigatório")]
        public int PlanoCobrancaId { get; set; }

        [Required(ErrorMessage = "O campo Condutor é obrigatório")]
        public int CondutorId { get; set; }

        [Required(ErrorMessage = "O campo Data de Início é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataSaida { get; set; }

        [Required(ErrorMessage = "O campo Data de Fim é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataRetorno { get; set; }

        [Required(ErrorMessage = "O campo Valor Total é obrigatório")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O marcador de combustível é obrigatório")]
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        [Required(ErrorMessage = "O tipo de plano é obrigatório")]
        public TipoPlanoCobrancaEnum TipoPlanoCobranca { get; set; }

        [Required(ErrorMessage = "O campo Km Rodado é obrigatório")]
        public int KmRodado { get; set; }

        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<SelectListItem> Automoveis { get; set; }
        public IEnumerable<PlanoCobranca> PlanosCobranca { get; set; }
        public IEnumerable<SelectListItem> Condutores { get; set; }
        public IEnumerable<SelectListItem> TaxasEscolhidas { get; set; }
    }

}
