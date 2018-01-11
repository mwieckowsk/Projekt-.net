using System;
using System.ComponentModel.DataAnnotations;

namespace ProjApp.Models.CarViewModels
{
    public class DetailsCarViewModel
    {
        public string CarId { get; set; }

        [Display(Name = "Brand")]
        public Brand Brand { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Models Built")]
        public decimal Built { get; set; }

        [Display(Name = "Country")]
        public Country Country { get; set; }
    }
}
