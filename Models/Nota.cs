using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspNotes.Models
{
    public class Nota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id {get; set;}
        [Required]
        public string titulo {get; set;}
        [Required]
        public string corpo {get; set;}
        public Guid? pastaId {get; set;}
        public Pasta? pasta {get; set;}
    }
}