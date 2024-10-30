using System.ComponentModel.DataAnnotations;

namespace Lopez_Darwin_examenProgreso1.Models
{
    public class Celular
    {
        
        [Required]
        public int Id { get; set; }

        [Key]
        [MaxLength(100)]
        [Required]
        public string modelo { get; set; }

        [Required]
        public int año { get; set; }

        [Required]
        public double precio { get; set; }
    }
}
