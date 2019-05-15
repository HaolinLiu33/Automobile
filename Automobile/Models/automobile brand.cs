using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Models
{
    public class automobile_brand
    {
        public int automobile_brandId { get; set; }
        public string Name { get; set; }
        public List<product> products { get; set; }
    }
}
