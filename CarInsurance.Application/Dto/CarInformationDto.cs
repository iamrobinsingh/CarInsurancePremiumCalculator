using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Application.Dto_s
{
    public class CarInformationDto
    {
        public int CarInformationId { get; set; }

        public CarVariantDto Variant { get; set; }
        public int PersonalInformationId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegisteredDate { get; set; }
        /// <summary>
        /// IDV = Insured Declared Value
        /// </summary>
        public double IDV { get; set; }
        public string RegistrationCity { get; set; }
        public double Premium { get; set; }
    }
}
