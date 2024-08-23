namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoDiario : PlanoCobranca
    {
        public decimal PrecoDiaria { get; set; }
        public decimal PrecoPorKm { get; set; }

        public PlanoDiario(decimal precoDiaria, decimal precoPorKm)
        {
            PrecoDiaria = precoDiaria;
            PrecoPorKm = precoPorKm;
        }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (PrecoDiaria <= 0)
                erros.Add("Preço da diária deve ser maior que zero");

            if (PrecoPorKm <= 0)
                erros.Add("Preço por km deve ser maior que zero");

            return erros;
        }
    }


}
