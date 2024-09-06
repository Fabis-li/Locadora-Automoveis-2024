using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorioBase<Taxa>
    {
        List<Taxa> SelecionarMuito(List<int> idsTaxasEscolhidas);
    }
}
