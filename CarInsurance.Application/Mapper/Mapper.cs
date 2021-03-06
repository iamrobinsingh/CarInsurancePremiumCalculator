using AutoMapper;
using CarInsurance.Application.Dto_s;
using CarInsurance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsurance.Application.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<CarVariant, CarVariantDto>();
            CreateMap<CarBrand, CarBrandDto>()/*.ForMember(dest=>dest.Variants,opt=>opt.MapFrom<List<CarVariantDto>,List<CarVariant>>())*/;
            CreateMap<CarInformation, CarInformationDto>();
            CreateMap<PersonalInformation, PersonalInformationDto>();
        }
    }
}
