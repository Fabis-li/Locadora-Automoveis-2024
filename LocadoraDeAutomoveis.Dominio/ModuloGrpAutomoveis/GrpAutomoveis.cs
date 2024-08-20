using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis
{
    public class GrpAutomoveis : EntidadeBase
    {
        public string Nome { get; set; }

        //lista de valores dos planos

        public GrpAutomoveis() { }
        public GrpAutomoveis(string nome)
        {
            Nome = nome;
        }
    }
}
