namespace Common.Models
{
    public class EstudianteCurso
    {
        public int EstudianteCursoID { get; set; }

        public int EstudianteId { get; set; }
        public Student Estudiante { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; } 
    }
}