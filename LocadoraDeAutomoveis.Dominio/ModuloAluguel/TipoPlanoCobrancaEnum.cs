using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel;

public enum TipoPlanoCobrancaEnum
{
    [Display(Name="Diário")] Diario,
    Controlado,
    Livre
}