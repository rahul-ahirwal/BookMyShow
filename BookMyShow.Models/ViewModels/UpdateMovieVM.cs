using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models.ViewModels
{
    public  class UpdateMovieVM
    {
        [ValidateNever]
        public IEnumerable<SelectListItem> MovieState { get; set; }
        public Movie Movie { get; set; }
    }
}
