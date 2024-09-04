using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutomoveis
{
    public class Automovel : EntidadeBase
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public int Ano { get; set; }
        public int CapacidadeCombustivel { get; set; } //capacidade do tanque
        public string FotoVeiculo { get; set; }
        public int GrupoAutomovelId { get; set; }
        public GrupoAutomovel? GrupoAutomoveis { get; set; }

        public bool Alugado { get; set; }

        public Automovel() { }

        public Automovel(string modelo, string marca, string cor, string placa, TipoCombustivel tipoCombustivel, int ano,
            int capacidadeCombustivel, string fotoVeiculo, GrupoAutomovel grupoAutomoveis, int grupoAutomovelId )
        {
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
            TipoCombustivel = tipoCombustivel;
            Ano = ano;
            CapacidadeCombustivel = capacidadeCombustivel;
            FotoVeiculo = fotoVeiculo;
            GrupoAutomoveis = grupoAutomoveis;
            GrupoAutomovelId = grupoAutomovelId;
        }

        public void Alugar()
        {
            Alugado = true;
        }
        public void Desocupar()
        {
            Alugado = false;
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Modelo))
                erros.Add("O campo \"Modelo\" é obrigatório");

            if (string.IsNullOrEmpty(Marca))
                erros.Add("O campo \"Marca\" é obrigatório");

            if (string.IsNullOrEmpty(Cor))
                erros.Add("O campo \"Cor\" é obrigatório");

            if (string.IsNullOrEmpty(Placa))
                erros.Add("O campo \"Placa\" é obrigatório");

            if (Ano < 0)
                erros.Add("O campo \"Ano\" é obrigatório");

            if (CapacidadeCombustivel < 1)
                erros.Add("O campo \"CapacidadeCombustivel\" é obrigatório");

            if (string.IsNullOrEmpty(FotoVeiculo))
                erros.Add("O campo \"FotoVeiculo\" é obrigatório");

            return erros;

        }
    }
}
