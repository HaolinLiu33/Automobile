using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Models
{
    public class product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string country_of_origin { get; set; }
        public int automobile_brandId { get; set; }
        public automobile_brand automobile_brand { get; set; }
    }
}
