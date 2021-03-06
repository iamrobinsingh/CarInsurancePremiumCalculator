using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Application.Dto
{
    public class CarInsurancePremiumResponseDto
    {
        public double IDV { get; set; }
        public double Premium { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
