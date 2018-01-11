using System.ComponentModel.DataAnnotations;
using ProjApp.Helpers.CustomValidators;

namespace ProjApp.Models.CountryViewModels
{
    public class EditCountryViewModel
    {
        public string CountryId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Capitalizer]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
