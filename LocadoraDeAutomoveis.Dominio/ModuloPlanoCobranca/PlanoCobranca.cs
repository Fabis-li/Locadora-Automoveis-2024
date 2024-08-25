using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase
    {
        public int GrupoAutomovelId { get; set; }
        public GrupoAutomovel? GrupoAutomovel { get; set; }

        public decimal PrecoDiarioPlanoDiario { get; set; }
        public decimal PrecoPorKmPlanoDiario { get; set; }
        public decimal KmDisponivelPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoControlado { get; set; }
        public decimal PrecoPorKmExcedido { get; set; }
        public decimal PrecoDiarioPlanoLivre { get; set; }

        protected PlanoCobranca() { }

        public PlanoCobranca(int grupoAutomovelId, decimal precoDiarioPlanoDiario, decimal precoPorKmPlanoDiario, decimal kmDisponivelPlanoControlado, decimal precoDiarioPlanoControlado, decimal precoPorKmExcedido, decimal precoDiarioPlanoLivre)
        {
            GrupoAutomovelId = grupoAutomovelId;

            PrecoDiarioPlanoDiario = precoDiarioPlanoDiario;
            PrecoPorKmPlanoDiario = precoPorKmPlanoDiario;

            KmDisponivelPlanoControlado = kmDisponivelPlanoControlado;
            PrecoDiarioPlanoControlado = precoDiarioPlanoControlado;
            PrecoPorKmExcedido = precoPorKmExcedido;

            PrecoDiarioPlanoLivre = precoDiarioPlanoLivre;
        }

        public List<string> Validar()
        {
            List<string> erros = [];

            if(GrupoAutomovelId == 0)
                erros.Add("Grupo de automóvel inválido");
            
            return erros;
        }

    }

    
}
