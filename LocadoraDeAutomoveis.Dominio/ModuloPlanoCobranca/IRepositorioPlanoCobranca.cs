using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorioBase<PlanoCobranca>
    {
        PlanoControlado ObterPlanoControladoPorId(int id);
        PlanoDiario ObterPlanoDiarioPorId(int id);
        PlanoLivre ObterPlanoLivrePorId(int id);

    }
}
