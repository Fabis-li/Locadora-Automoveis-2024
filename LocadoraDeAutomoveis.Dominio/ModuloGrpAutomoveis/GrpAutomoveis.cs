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

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo \"Nome\" é obrigatório");

            return erros;
        }
    }
}
