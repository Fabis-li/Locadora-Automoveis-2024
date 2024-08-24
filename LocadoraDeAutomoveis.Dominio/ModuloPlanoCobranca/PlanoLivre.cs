namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoLivre : PlanoCobranca
    {
        public override string TipoPlanoCobranca { get; set; } = "Livre";
        public override decimal PrecoDiaria { get; set; }

        public override decimal? PrecoPorKm
        {
            get  => null; 
            set => throw new NotImplementedException();
        }
        public override PlanoControlado KmDisponivel
        {
            get => null;
            set => throw new NotImplementedException();
        }
        public override decimal? PrecoPorkmExcedido
        {
            get => null;
            set => throw new NotImplementedException();
        }

        public PlanoLivre() { }

        public PlanoLivre(string nomePlano, int grupoAutomovelId, decimal precoDiaria)
            : base(nomePlano, grupoAutomovelId)
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
