namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoControlado : PlanoCobranca
    {
        public decimal KmDisponivel { get; set; }
        public decimal PrecoDiaria { get; set; }
        public decimal PrecoPorkmExtrapolado { get; set; }

        public PlanoControlado(decimal kmDisponivel, decimal precoDiaria, decimal precoPorkmExtrapolado)
        {
            KmDisponivel = kmDisponivel;
            PrecoDiaria = precoDiaria;
            PrecoPorkmExtrapolado = precoPorkmExtrapolado;
        }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (KmDisponivel <= 0)
                erros.Add("Km disponível deve ser maior que zero");

            if (PrecoDiaria <= 0)
                erros.Add("Preço da diária deve ser maior que zero");

            if (PrecoPorkmExtrapolado <= 0)
                erros.Add("Preço por km excedido deve ser maior que zero");

            return erros;
        }
    }
}
