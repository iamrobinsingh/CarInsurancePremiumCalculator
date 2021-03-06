using CarInsurance.Application.Dto_s;
using CarInsurance.Application.Interfaces;
using CarInsurance.Core.Entities;
using CarInsurance.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarInsurance.Application.Services
{
    public class PersonalInformationService: IPersonalInformationService
    {
        private readonly IPersonalInfomationRepository _personalInfomationRepository;
        public PersonalInformationService(IPersonalInfomationRepository personalInfomationRepository)
        {
            _personalInfomationRepository = personalInfomationRepository;
        }
        public PersonalInformation SavePersonalInformation(PersonalInformationDto dto)
        {
            var personalInfo = new PersonalInformation();
            personalInfo.Mobile = dto.Mobile;
            personalInfo.Name = dto.Name;
            personalInfo.EmailAddress = dto.EmailAddress;
            personalInfo = _personalInfomationRepository.Save(personalInfo);
            return personalInfo;
        }
    }
}
