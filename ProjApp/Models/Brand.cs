using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjApp.Models
{
    public class Brand
    {
        public string BrandId { get; set; }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
