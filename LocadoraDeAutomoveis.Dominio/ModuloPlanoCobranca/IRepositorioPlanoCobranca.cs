using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorioBase<PlanoCobranca>
    {
        PlanoCobranca? FiltrarPlano(Func<PlanoCobranca, bool> predicate);
    }
}
