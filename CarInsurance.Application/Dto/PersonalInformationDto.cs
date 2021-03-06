using CarInsurance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Application.Dto_s
{
    public class PersonalInformationDto
    {
        public int PersonalInformationId { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        //public List<CarInformationDto> CarInformations { get; set; }
    }
}
