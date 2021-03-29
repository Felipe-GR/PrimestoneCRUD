using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CursoViewModel
    {
        [Display(Name = "Codigo")]
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
