using Common.Models;
using Web.Models;

namespace Web.Helpers
{
    public interface IConverterHelper
    {
        Common.Models.Student student(Models.Student model);
        Models.Student ToEstudentViewModel(Common.Models.Student estudiante);
    }
}
