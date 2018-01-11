using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjApp.Helpers.CustomValidators;

namespace ProjApp.Models.CarViewModels
{
    public class EditCarViewModel
    {
        public string CarId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string BrandId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.0, 10_000_000.0, ErrorMessage = "The ammount of models built must be between 0.0 and 10000000.0")]
        [Display(Name = "Models Built")]
        public decimal Built { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string CountryId { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<Brand> Brands { get; set; }
    }
}
