using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public DateTime FechaNacimento { get; set; }
        public Genero Genero { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
        public ICollection<EstudianteCurso> EstudiantesCursos { get; set; }
    }
}