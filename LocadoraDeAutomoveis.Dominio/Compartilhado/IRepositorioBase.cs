﻿namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        void Inserir(TEntidade entidade);
        void Editar(TEntidade entidadeAtualizada);
        void Excluir(TEntidade entidadeParaExcluir);
        TEntidade SelecionarPorId(int idSelecionado);
        List<TEntidade> SelecionarTodos();
        List<TEntidade> Filtrar(Func<TEntidade, bool> predicate);


    }
}
