using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public abstract class PlanoCobranca : EntidadeBase
    {
        public string NomePlano { get; set; }

        public int GrupoAutomovelId { get; set; }

        public TipoPlanoCobranca TipoPlanoCobranca { get; set; }

        public GrupoAutomovel GrupoAutomoveis { get; set; }

        protected PlanoCobranca()
        {
            
        }

        public PlanoCobranca(string nomePlano, int grupoAutomovelId, GrupoAutomovel grupoAutomoveis, TipoPlanoCobranca tipoPlanoCobranca)
        {
            NomePlano = nomePlano;
            GrupoAutomovelId = grupoAutomovelId;
            GrupoAutomoveis = grupoAutomoveis;
            TipoPlanoCobranca = tipoPlanoCobranca;
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
