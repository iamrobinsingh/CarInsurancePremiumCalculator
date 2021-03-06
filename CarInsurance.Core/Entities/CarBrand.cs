using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Core.Entities
{
    public class CarBrand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public List<CarVariant> Variants { get; set; }
    }
}
