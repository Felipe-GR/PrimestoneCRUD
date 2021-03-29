using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> Genders();

    }
}
