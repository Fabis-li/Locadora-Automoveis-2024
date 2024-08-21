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
        public string Combustivel { get; set; }
        public int Ano { get; set; }
        public int CapacidadeCombustivel { get; set; } //capacidade do tanque
        public string FotoVeiculo { get; set; }

        public List<GrpAutomoveis> GrupoAutomoveis;

        public Automovel()
        {

        }

        public Automovel(string modelo, string marca, string cor, string placa, string combustivel, int ano,
            int capacidadeCombustivel, string fotoVeiculo)
        {
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
            Combustivel = combustivel;
            Ano = ano;
            CapacidadeCombustivel = capacidadeCombustivel;
            FotoVeiculo = fotoVeiculo;
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

            if (string.IsNullOrEmpty(Combustivel))
                erros.Add("O campo \"Combustível\" é obrigatório");

            if (Ano < 0)
                erros.Add("O campo \"Ano\" é obrigatório");

            if (CapacidadeCombustivel == 0)
                erros.Add("O campo \"Capacidade do Tanque\" é obrigatório");

            if (string.IsNullOrEmpty(FotoVeiculo))
                erros.Add("O campo \"Foto do Veículo\" é obrigatório");

            return erros;

        }
    }
}
