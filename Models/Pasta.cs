using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspNotes.Models
{
    public class Pasta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id {get; set;}
        [Required]
        public string? nome {get; set;}
        public ICollection<Nota> Notas {get;} = new List<Nota>();
    }
}