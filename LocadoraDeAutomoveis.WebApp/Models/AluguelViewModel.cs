using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class FormularioViewModel
    {
        [Required(ErrorMessage = "O campo Automóvel é obrigatório")]
        public int AutomovelId { get; set; }
        
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

        [Required(ErrorMessage = "O campo Valor Entrada é obrigatório")]
        public decimal ValorEntrada { get; set; }

        [Required(ErrorMessage = "O marcador de combustível é obrigatório")]
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        [Required(ErrorMessage = "O tipo de plano é obrigatório")]
        public TipoPlanoCobrancaEnum TipoPlanoCobranca { get; set; }
        public StatusAluguelEnum Status { get; set; }   

        [Required(ErrorMessage = "O campo Km Rodado é obrigatório")]
        public int KmRodado { get; set; }

        public IEnumerable<int> TaxasEscolhidas { get; set; }

        public IEnumerable<SelectListItem> Automoveis { get; set; }
        public IEnumerable<SelectListItem> Condutores { get; set; }
        public IEnumerable<SelectListItem> Taxas { get; set; }

    }

    public class InserirAluguelViewModel : FormularioViewModel
    {

    }

    public class EditarAluguelViewModel : FormularioViewModel
    {
        public int Id { get; set; }

    }

    public class DevolucaoAluguelViewModel : FormularioViewModel
    {
        public int Id { get; set; }

        public decimal ValorTotal { get; set; }
    }

    public class ListarAluguelViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Automovel { get; set; }
        public string Condutor { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
        public string TipoPlanoCobranca { get; set; }
        public string MarcadorCombustivel { get; set; }
        public int KmRodado { get; set; }
    }

    public class DetalhesAluguelViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Automovel { get; set; }
        //public string PlanoCobranca { get; set; }
        public string Condutor { get; set; }
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
