using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjApp.Models
{
    public class Country
    {
        public string CountryId { get; set; }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
