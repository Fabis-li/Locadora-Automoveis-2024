namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        void Inserir(TEntidade registro);
        bool Editar(TEntidade registro);
        bool Excluir(TEntidade registro);
        TEntidade SElecionarPorId(int id);
        List<TEntidade> SelecionarTodos();
    }
}
