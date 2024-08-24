namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoDiario : PlanoCobranca
    {
        public override string TipoPlanoCobranca { get; set; } = "Diário";
        public override decimal PrecoDiaria { get; set; }
        public override decimal? PrecoPorKm { get; set; }
        public override decimal? KmDisponivel
        {
            get => null;
            set => throw new NotImplementedException();
        }

        public override decimal? PrecoPorkmExcedido
        {
            get => null;
            set => throw new NotImplementedException();
        }

        public PlanoDiario() { }

        public PlanoDiario(string nomePlano, int grupoAutomovelId, decimal precoDiaria, decimal precoPorKm)
            : base(nomePlano, grupoAutomovelId)
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
