﻿using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
    public enum TipoClienteEnum
    {
        [Display(Name = "Pessoa Física")] CPF,
        [Display(Name = "Pessoa Jurídica")]CNPJ
        
    }
}
