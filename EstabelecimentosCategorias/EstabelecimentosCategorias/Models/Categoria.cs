using System.ComponentModel.DataAnnotations;

namespace EstabelecimentosCategorias.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [NomeUnico]
        public string Nome { get; set; }


    }
}