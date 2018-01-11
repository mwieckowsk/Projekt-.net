using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjApp.Models
{
    public class Car
    {
        public string CarId { get; set; }
        public Brand Brand { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Built { get; set; }
        public Country Country { get; set; }
    }
}
