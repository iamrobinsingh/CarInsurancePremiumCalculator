using CarInsurance.Application.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInsurance.Web.ViewModels
{
    public class CarInsuranceViewModel
    {
        public List<CarBrandDto> CarBrands { get; set; }
    }
}
