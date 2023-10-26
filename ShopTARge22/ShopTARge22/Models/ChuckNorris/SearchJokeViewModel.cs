using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.ChuckNorris
{
    public class SearchJokeViewModel
    {
        [Required(ErrorMessage = "You must enter a joke name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a joke Name greater than 2 and lesser than 20 characters")]
        [Display(Name = "City Name")]
        public string JokeName { get; set; }
    }
}