﻿using System.ComponentModel.DataAnnotations;
using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloTaxa
{
    public enum TipoCobrancaEnum
    {
        [Display(Name = "Diária")]
        Diaria,
        Fixa
    }

    public class Taxa : EntidadeBase
    {

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCobrancaEnum TipoCobrancaEnum { get; set; }

        protected Taxa() { }
        
        public Taxa(string nome, decimal valor, TipoCobrancaEnum tipoCobrancaEnum)
        {
            Nome = nome;
            Valor = valor;
            TipoCobrancaEnum = tipoCobrancaEnum;
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O Nome é obrigatório");

            if (Valor < 1.0m)
                erros.Add("O valor precisa ser ao menos 1");

            return erros;
        }
    }
}
