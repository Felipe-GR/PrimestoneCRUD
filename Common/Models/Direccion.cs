using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class Direccion
    {
        public int ID { get; set; }
        [Display(Name = "Direccion")]
        public string StringDireccion { get; set; }
        public TipoDireccion TipoDireccion { get; set; }

        [JsonIgnore]
        public Student Estudiante { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdEstudiante { get; set; }
    }
}