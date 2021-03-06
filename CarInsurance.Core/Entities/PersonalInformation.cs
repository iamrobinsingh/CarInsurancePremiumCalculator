using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Core.Entities
{
    public class PersonalInformation
    {
        public int PersonalInformationId { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        //public List<CarInformation> CarInformations { get; set; }
    }
}
