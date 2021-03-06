using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Application.Dto_s
{
    public class CarBrandDto
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public List<CarVariantDto> Variants { get; set; }
    }
}
