using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Livros
{
    public class Livros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage ="O campo título é obrigatório!")]
        [StringLength(100, ErrorMessage ="O campo título tem um tamanho limite de 100 caracteres!")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "O campo autor é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo autor tem um tamanho limite de 100 caracteres!")]
        public string autor { get; set; }

        [Required(ErrorMessage = "O campo ISBN é obrigatório!")]
        public string ISBN { get; set; }

        [StringLength(500, ErrorMessage = "O campo descrição tem um tamanho limite de 500 caracteres!")]
        public string descricao { get; set; }

        public int? ano { get; set; }

        public int? numeroEd { get; set; }

        [StringLength(100, ErrorMessage = "O campo autor tem um tamanho limite de 100 caracteres!")]
        public string editora { get; set; }

        public int? categoriaID { get; set; }
        public virtual Categorias.Categorias categoria { get; set; }

        public string idioma { get; set; }
    }
}