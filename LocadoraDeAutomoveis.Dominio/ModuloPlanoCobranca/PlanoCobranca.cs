using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public abstract class PlanoCobranca : EntidadeBase
    {
        public string NomePlano { get; set; }

        public int GrupoAutomovelId { get; set; }

        public abstract string TipoPlanoCobranca { get; set; }
        public abstract decimal KmDisponivel { get; set; }
        public abstract decimal PrecoDiaria { get; set; }
        public abstract decimal? PrecoPorKm { get; set; }
        public abstract decimal? PrecoPorkmExcedido { get; set; }

        //public GrupoAutomovel GrupoAutomoveis { get; set; }

        protected PlanoCobranca() { }

        protected PlanoCobranca(string nomePlano, int grupoAutomovelId)
        {
            NomePlano = nomePlano;
            GrupoAutomovelId = grupoAutomovelId;
        }
       

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(NomePlano))
                erros.Add("O campo \"Nome do Plano\" é obrigatório");

            if (GrupoAutomovelId <= 0)
                erros.Add("O campo \"Grupo de Automóveis\" é obrigatório");

            return erros;
        }
    }

    
}
