using CarInsurance.Application.Dto;
using CarInsurance.Application.Dto_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.Application.Interfaces
{
    public interface ICarInformationService
    {
        Task<List<CarBrandDto>> GetAllCarBrands();
        CarInsurancePremiumResponseDto CalculateIDVandPremium(CalculateIDVObjectDto dto);
    }
}
