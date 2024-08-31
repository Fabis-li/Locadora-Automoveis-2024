using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {

        public int CondutorId { get; set; }
        public Condutor Condutor { get; set; }

        public int AutomovelId { get; set; }
        public Automovel Automovel { get; set; }

        //public int GrupoAutomvel { get; set; }
        //public GrupoAutomovel GrupoAutomovel { get; set; }

        public int PlanoCobrancaId { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }


        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public decimal ValorEntrada { get; set; }

        public StatusAluguelEnum Status { get; set; }

        protected Aluguel() { }

        public Aluguel(int condutorId, Condutor condutor, int automovelId, Automovel autonoAutomovel,int planoCobrancaId, PlanoCobranca planoCobranca,DateTime dataSaida, DateTime? dataRetorno, decimal valorEntrada, StatusAluguelEnum status)
        {
            CondutorId = condutorId;
            Condutor = condutor;
            AutomovelId = automovelId;
            Automovel = autonoAutomovel;
            //GrupoAutomvel = grupoAutomvel;
            //GrupoAutomovel = grupoAutomovel;
            PlanoCobrancaId = planoCobrancaId;
            PlanoCobranca = planoCobranca;
            DataSaida = dataSaida;
            DataRetorno = dataRetorno;
            ValorEntrada = valorEntrada;
            Status = status;
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (CondutorId == 0)
                erros.Add("O campo \"CondutorId\" é obrigatório");

            if (AutomovelId == 0)
                erros.Add("O campo \"AutomovelId\" é obrigatório");

            //if (GrupoAutomvel == 0)
            //    erros.Add("O campo \"GrupoAutomvel\" é obrigatório");

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
