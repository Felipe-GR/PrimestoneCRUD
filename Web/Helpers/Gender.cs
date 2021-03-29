using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Web.Helpers
{
    public class Gender : ICombosHelper
    {
        public IEnumerable<SelectListItem> Genders()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Value="1", Text="Femenino"},
                new SelectListItem {Value="2", Text="Masculino"},
                new SelectListItem {Value="3", Text="No Definido"}
            };
        }
    }
}
