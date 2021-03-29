using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Student
    {
        public int studentId { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentLastname { get; set; }
        [Display(Name = "Fecha de Nacimento")]
        public DateTime FechaNacimento { get; set; }
        public IEnumerable<SelectListItem> Genero { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar el genero")]
        [Display(Name = "Genero")]
        public int SelectedGenero { get; set; }
    }
}
