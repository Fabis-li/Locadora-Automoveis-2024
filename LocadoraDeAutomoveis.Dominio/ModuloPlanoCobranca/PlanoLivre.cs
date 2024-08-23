namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoLivre : PlanoCobranca
    {
        public decimal PrecoDiaria { get; set; }

        public PlanoLivre(decimal precoDiaria)
        {
            PrecoDiaria = precoDiaria;
        }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (PrecoDiaria <= 0)
                erros.Add("Preço da diária deve ser maior que zero");

            return erros;
        }

    }
}
