using CarInsurance.Application.Dto_s;
using CarInsurance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Application.Interfaces
{
    public interface IPersonalInformationService
    {
        PersonalInformation SavePersonalInformation(PersonalInformationDto dto);
    }
}
