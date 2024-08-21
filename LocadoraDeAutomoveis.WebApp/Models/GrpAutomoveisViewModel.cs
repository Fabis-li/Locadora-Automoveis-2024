using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirGrpAutomoveisViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
    }

    public class EditarGrpAutomoveisViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
    }

    public class listarGrpAutomoveisViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class DetalhesGrpAutomoveisViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}
