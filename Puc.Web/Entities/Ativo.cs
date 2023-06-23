using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Puc.Web.Entities
{
    public class Ativo
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string? Nome { get; set; }

        [Required, StringLength(100)]
        public string? Responsavel { get; set; }

        [Required]
        public int? Patrimonio { get; set; }

        [Required]
        public Status? Status { get; set; }

        [Required]
        public Categoria? Categoria { get; set; }
    }

    public enum Status
    {
        Disponivel,
        EmOperacao,
        ForaOperacao,
        Defeito,
    }

    public enum Categoria
    {
        Computadores = 1,
        Impressoras,
        Monitores,
        Perifericos,
        Escritorio,
        Redes,
    }
}
