using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Core.Entities
{
    public class CarVariant
    {
        public int BrandId { get; set; }
        public int VariantId { get; set; }
        public string VariantName { get; set; }
        public double OnRoadPrice { get; set; }
        public int ManufacturedYear { get; set; }
    }
}
