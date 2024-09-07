using System.ComponentModel.DataAnnotations;

public enum TipoUsuarioEnum
{
    Empresa,
    [Display(Name = "Funcionário")] Funcionario,

}