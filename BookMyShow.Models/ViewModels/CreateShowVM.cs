using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace BookMyShow.Models.ViewModels
{
    public class CreateShowVM
    {
        [ValidateNever]
        public IEnumerable<SelectListItem> MovieDD { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TheatreDD { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ShowTypeDD { get; set; }
        public Show Show { get; set; }
    }
}
