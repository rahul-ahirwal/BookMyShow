using BookMyShow.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Utilities.Validations
{
    public class MovieGenreAttribute : ValidationAttribute
    {
        private string? Genre { get; set; }
        private string Error => "Genre is not correct";
        public MovieGenreAttribute(string genre)
        {
            this.Genre = genre;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if(!(movie.Genre == Genre))
            {
                return new ValidationResult(Error);
            }
            return ValidationResult.Success;
        }
    }
}
