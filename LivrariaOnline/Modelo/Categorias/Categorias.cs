using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Categorias
{
    public class Categorias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "O campo descrição tem um tamanho limite de 50 caracteres!")]
        public string descricao { get; set; }
    }
}