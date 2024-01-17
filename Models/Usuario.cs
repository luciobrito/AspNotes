using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspNotes.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id {get; set;}
        [Required]
        public string? nome {get; set;}
        [Required]
        public string? email {get; set;}
        [Required]
        public string? senha {get; set;}

        public DateTimeOffset CreatedAt {get; set;}
        public DateTimeOffset UpdatedAt {get; set;}
    }
}