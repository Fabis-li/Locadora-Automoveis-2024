using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;

namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }
        public Usuario? Empresa { get; set; }
    }
}
