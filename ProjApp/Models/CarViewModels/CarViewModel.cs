using System;
using System.ComponentModel.DataAnnotations;

namespace ProjApp.Models.CarViewModels
{
    public class CarViewModel
    {
        public string CarId { get; set; }
        [Display(Name = "Brand")]
        public Brand Brand { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Built { get; set; }
        [Display(Name = "Country")]
        public Country Country { get; set; }
    }
}
