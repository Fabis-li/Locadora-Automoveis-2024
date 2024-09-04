using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxa;

namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {

        public int CondutorId { get; set; }
        public Condutor Condutor { get; set; }

        public int AutomovelId { get; set; }
        public Automovel Automovel { get; set; }

        public int PlanoCobrancaId { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }


        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public decimal ValorEntrada { get; set; }

        public int KmRodado { get; set; }
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        public StatusAluguelEnum Status { get; set; }
        public TipoPlanoCobrancaEnum TipoPlanoCobranca { get; set; }

        public List<Taxa> TaxasEscolhidas { get; set; }

        protected Aluguel()
        {
            TaxasEscolhidas = new List<Taxa>();
            MarcadorCombustivel = MarcadorCombustivelEnum.Completo;
            DataRetorno = null;
        }

        public Aluguel(int condutorId, int automovelId, int planoCobrancaId, DateTime dataSaida, DateTime? dataRetorno, decimal valorEntrada, StatusAluguelEnum status, TipoPlanoCobrancaEnum planoCobranca): this()
        {
            CondutorId = condutorId;
            AutomovelId = automovelId;
            PlanoCobrancaId = planoCobrancaId;
            DataSaida = dataSaida;
            ValorEntrada = valorEntrada;
            Status = status;
            TipoPlanoCobranca = planoCobranca;
        }

        public void Devolucao()
        {
            DataRetorno = DateTime.Now;

            if (Automovel is null)
                return;

            Automovel.Desocupar();
        }

        public bool TemMulta()
        {
            int diasAlugado = (DataRetorno - DataSaida).Value.Days;

            if (DataRetorno is null)
                return (DateTime.Now - DataSaida).Days > diasAlugado;

            return (DataRetorno - DataSaida).Value.Days > diasAlugado;
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0;

            if (TipoPlanoCobranca == TipoPlanoCobrancaEnum.Diario)
            {
                decimal valorDiaria = PlanoCobranca.PrecoDiarioPlanoDiario * (DataRetorno - DataSaida).Value.Days;

                decimal valorKm = PlanoCobranca.PrecoPorKmPlanoDiario * KmRodado;

                valorTotal = valorDiaria + valorKm;
            }
            else if (TipoPlanoCobranca == TipoPlanoCobrancaEnum.Controlado)
            {
                decimal valorDiaria = PlanoCobranca.PrecoDiarioPlanoControlado * (DataRetorno - DataSaida).Value.Days;

                if(PlanoCobranca.KmDisponivelPlanoControlado < KmRodado)
                {
                    decimal valorKmExcedido = (KmRodado - PlanoCobranca.KmDisponivelPlanoControlado) * PlanoCobranca.PrecoPorKmExcedido;
                    valorTotal = valorDiaria + valorKmExcedido;
                }
                else
                {
                    valorTotal = valorDiaria;
                }
            }
            else if (TipoPlanoCobranca == TipoPlanoCobrancaEnum.Livre)
            {
                valorTotal = PlanoCobranca.PrecoDiarioPlanoLivre * (DataRetorno - DataSaida).Value.Days;
            }

            return valorTotal;
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (CondutorId == 0)
                erros.Add("O campo \"CondutorId\" é obrigatório");

            if (AutomovelId == 0)
                erros.Add("O campo \"AutomovelId\" é obrigatório");
            
            if (PlanoCobrancaId == 0)
                erros.Add("O campo \"PlanoCobrancaId\" é obrigatório");

            if (DataSaida == null)
                erros.Add("O campo \"DataSaída\" é obrigatório");

            if (ValorEntrada == 0)
                erros.Add("O campo \"ValorEntrada\" é obrigatório");

            if (Status == null)
                erros.Add("O campo \"Status\" é obrigatório");

            return erros;
        }

    }
}
