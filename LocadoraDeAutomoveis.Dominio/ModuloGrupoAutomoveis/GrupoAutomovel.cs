using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis
{
    public class GrupoAutomovel : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Automovel> Automoveis { get; set; }
        //public PlanoCobranca PlanosCobranca { get; set; }

        public GrupoAutomovel()
        {
           
        }

        public GrupoAutomovel(string nome)
        {
            Nome = nome;
            Automoveis = new List<Automovel>();
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
