namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoControlado : PlanoCobranca
    {
        public decimal KmDisponivel { get; set; }
        public decimal PrecoDiaria { get; set; }
        public decimal PrecoPorkmExcedido { get; set; }
        public TipoPlanoCobranca Tipo { get; set; }

        public PlanoControlado() { } 

        public PlanoControlado(decimal kmDisponivel, decimal precoDiaria, decimal precoPorkmExcedido)
        {
            KmDisponivel = kmDisponivel;
            PrecoDiaria = precoDiaria;
            PrecoPorkmExcedido = precoPorkmExcedido;
            Tipo = TipoPlanoCobranca.Controlado;
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
