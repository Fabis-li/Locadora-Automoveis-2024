using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class InserirGrupoAutomovelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
    }

    public class EditarGrupoAutomovelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
    }

    public class ListarGrupoAutomovelViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class DetalhesGrupoAutomovelViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}
