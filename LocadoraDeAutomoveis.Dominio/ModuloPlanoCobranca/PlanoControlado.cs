namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoControlado : PlanoCobranca
    {
        public override string TipoPlanoCobranca { get; set; } = "Controlado";
        public override decimal PrecoDiaria { get; set; }
        public override decimal? PrecoPorKm
        {
            get => null;
            set => throw new NotImplementedException();
        }
        public override decimal KmDisponivel { get; set; }
        public override decimal? PrecoPorkmExcedido { get; set; }

        public PlanoControlado() { }

        public PlanoControlado(string nomePlano, int grupoAutomovelId, decimal precoDiaria, decimal kmDisponivel, decimal precoPorkmExcedido)
            : base(nomePlano, grupoAutomovelId)
        {
            PrecoDiaria = precoDiaria;
            KmDisponivel = kmDisponivel;
            PrecoPorkmExcedido = precoPorkmExcedido;
        }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (KmDisponivel <= 0)
                erros.Add("Km disponível deve ser maior que zero");

            if (PrecoDiaria <= 0)
                erros.Add("Preço da diária deve ser maior que zero");

            if (PrecoPorkmExcedido <= 0)
                erros.Add("Preço por km excedido deve ser maior que zero");

            return erros;
        }
    }
}
