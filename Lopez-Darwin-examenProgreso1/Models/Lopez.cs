using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lopez_Darwin_examenProgreso1.Models
{
    public class Lopez
    {
        [Key]

        [MaxLength(100)]
        [Required]
        public string nombre { get; set; }

        [Required]
        [Range(1, 100)]
        public int edad { get; set; }

        [Required]
        public bool? EsEcuatoriano { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public decimal estatura { get; set; }

        public Celular? celulares { get; set; }

        [ForeignKey(nameof(celulares))]

        public string celularesmodelo { get; set; }
    }
}
