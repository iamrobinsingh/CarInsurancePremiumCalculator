using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Core.Entities
{
    public class CarInformation
    {
        public int CarInformationId { get; set; }
        public CarVariant Variant { get; set; }
        public int PersonalInformationId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegisteredDate { get; set; }
        public double IDV { get; set; }
        public double Premium { get; set; }
        public string RegistrationCity { get; set; }
    }
}
