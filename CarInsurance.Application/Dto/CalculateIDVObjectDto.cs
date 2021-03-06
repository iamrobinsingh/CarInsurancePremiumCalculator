using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Application.Dto
{
    public class CalculateIDVObjectDto
    {
        public string PhoneNumber { get; set; }
        public string PersonName { get; set; }
        public string EMail { get; set; }
        public int CarBrandId { get; set; }
        public int CarVariantId { get; set; }
        public string RegisteredYear { get; set; }
        public string RegisteredCity { get; set; }
        public string RegistrationNumber { get; set; }
    }
}