using Common.Models;
using Web.Models;

namespace Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly ICombosHelper helpers;

        public ConverterHelper(ICombosHelper helper)
        {
            helpers = helper;
        }
        public Common.Models.Student student(Models.Student student)
        {
            return new Common.Models.Student
            {
                ID = student.studentId,
                Nombres = student.studentName,
                Apellidos = student.studentLastname,
                FechaNacimento = student.FechaNacimento,
                Genero = GeneroById(student.SelectedGenero)
            };
        }

        private static Genero GeneroById(int id)
        {
            return id switch
            {
                1 => Genero.Femenino,
                2 => Genero.Masculino,
                _ => Genero.NoDefinido,
            };
        }

        public Models.Student ToEstudentViewModel(Common.Models.Student estudiante)
        {
            return new Models.Student
            {
                studentId = estudiante.ID,
                studentName = estudiante.Nombres,
                studentLastname = estudiante.Apellidos,
                FechaNacimento = estudiante.FechaNacimento,
                Genero = helpers.Genders(),
                SelectedGenero = (int)estudiante.Genero
            };
        }
    }
}
