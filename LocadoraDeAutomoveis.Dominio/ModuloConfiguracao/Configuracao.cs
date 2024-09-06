using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloConfiguracao
{
    public class Configuracao : EntidadeBase
    {
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoAlcool { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoGas { get; set; }

        public Configuracao() { }

        public Configuracao(decimal precoGasolina, decimal precoAlcool, decimal precoDiesel, decimal precoGas)
        {
            PrecoGasolina = precoGasolina;
            PrecoAlcool = precoAlcool;
            PrecoDiesel = precoDiesel;
            PrecoGas = precoGas;
        }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (PrecoGasolina <= 0)
                erros.Add("Preço da gasolina deve ser maior que zero");

            if (PrecoAlcool <= 0)
                erros.Add("Preço do álcool deve ser maior que zero");

            if (PrecoDiesel <= 0)
                erros.Add("Preço do diesel deve ser maior que zero");

            if (PrecoGas <= 0)
                erros.Add("Preço do gás deve ser maior que zero");

            return erros;
        }
    }


}
