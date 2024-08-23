using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase
    {
        public string NomePlano { get; set; }

        public decimal ValorDiaria { get; set; }

        public decimal ValorKm { get; set; }

        public int QuantidadeDias { get; set; }

        public int GrupoAutomoveis_Id { get; set; }

        public GrupoAutomovel GrpAutomoveis { get; set; }

        protected PlanoCobranca() { }

        public PlanoCobranca(string nomePlano, decimal valorDiaria, decimal valorKm, int quantidadeDias, int grupoAutomoveis_Id)
        {
            NomePlano = nomePlano;
            ValorDiaria = valorDiaria;
            ValorKm = valorKm;
            QuantidadeDias = quantidadeDias;
            GrupoAutomoveis_Id = grupoAutomoveis_Id;
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(NomePlano))
                erros.Add("O campo \"Nome do Plano\" é obrigatório");

            if (ValorDiaria <= 0)
                erros.Add("O campo \"Valor da Diária\" é obrigatório");

            if (ValorKm <= 0)
                erros.Add("O campo \"Valor do Km\" é obrigatório");

            if (QuantidadeDias <= 0)
                erros.Add("O campo \"Quantidade de Dias\" é obrigatório");

            if (GrupoAutomoveis_Id <= 0)
                erros.Add("O campo \"Grupo de Automóveis\" é obrigatório");

            return erros;
        }
    }

    
}
