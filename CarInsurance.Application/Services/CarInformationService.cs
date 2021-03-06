using AutoMapper;
using CarInsurance.Application.Dto;
using CarInsurance.Application.Dto_s;
using CarInsurance.Application.Interfaces;
using CarInsurance.Core.Entities;
using CarInsurance.Core.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.Application.Services
{
    public class CarInformationService: ICarInformationService
    {
        private readonly ICarBrandRepository _carBrandRepository;
        private readonly IMapper _mapper;
        private readonly IPersonalInformationService _personalInformationService;
        private readonly ICarInformationRepository _carInformationRepository;
        private readonly ICarVariantRepository _carVariantRepository;
        public CarInformationService(ICarBrandRepository carBrandRepository, IMapper mapper, IPersonalInformationService personalInformationService, ICarInformationRepository carInformationRepository, ICarVariantRepository carVariantRepository)
        {
            _carBrandRepository = carBrandRepository;
            _mapper = mapper;
            _personalInformationService = personalInformationService;
            _carInformationRepository = carInformationRepository;
            _carVariantRepository = carVariantRepository;
        }
        public async Task<List<CarBrandDto>> GetAllCarBrands()
        {
            var brands = await _carBrandRepository.GetAll();
            var brandDtos = _mapper.Map<List<CarBrand>, List<CarBrandDto>>(brands.ToList());
            return brandDtos;
        }

        public CarInsurancePremiumResponseDto CalculateIDVandPremium(CalculateIDVObjectDto dto)
        {
            var response = new CarInsurancePremiumResponseDto();
            var personalInformationDto = new PersonalInformationDto();

            personalInformationDto.Mobile = dto.PhoneNumber;
            personalInformationDto.Name = dto.PersonName;
            personalInformationDto.EmailAddress = dto.EMail;

            var personalInfo = _personalInformationService.SavePersonalInformation(personalInformationDto);

            var carInformation = new CarInformation();
            carInformation.Variant = _carVariantRepository.GetAll().FirstOrDefault(x => x.VariantId == dto.CarVariantId);
            carInformation.RegistrationCity = dto.RegisteredCity;
            carInformation.RegistrationNumber = dto.RegistrationNumber;
            DateTime dt;
            if (DateTime.TryParseExact(dto.RegisteredYear, "yyyy-MM", CultureInfo.InvariantCulture,
                          DateTimeStyles.None, out dt))
            {
                carInformation.RegisteredDate = dt;
            }
            else
            {
                carInformation.RegisteredDate = DateTime.Now;

            }
            carInformation.PersonalInformationId = personalInfo.PersonalInformationId;
            carInformation.IDV = CalculateIDV(carInformation);
            carInformation.Premium = CalculatePremium(carInformation.IDV);
            carInformation = _carInformationRepository.Save(carInformation);
            response.IDV = carInformation.IDV;
            response.Premium = carInformation.Premium;
            response.RegistrationNumber = carInformation.RegistrationNumber;
            return response;
        }

        private double CalculateIDV(CarInformation carInformation)
        {
            double depreciationRate = 0.00;
            double ageOfVehicle = (DateTime.Now- carInformation.RegisteredDate).TotalDays;
            if (ageOfVehicle <= 72)
            {
                depreciationRate = 0.05;
            }
            else if (ageOfVehicle > 72 && ageOfVehicle <= 365)
            {
                depreciationRate = 0.15;
            }
            else if (ageOfVehicle > 365 && ageOfVehicle <= (365*2))
            {
                depreciationRate = 0.20;
            }
            else if (ageOfVehicle > (365 * 2) && ageOfVehicle <= (365 * 3))
            {
                depreciationRate = 0.30;
            }
            else if (ageOfVehicle > (365 * 3) && ageOfVehicle <= (365 * 4))
            {
                depreciationRate = 0.40;
            }
            else if (ageOfVehicle > (365 * 4) && ageOfVehicle <= (365 * 5))
            {
                depreciationRate = 0.50;
            }
            else
            {
                depreciationRate = 1;
            }

            double IDV = carInformation.Variant.OnRoadPrice - (carInformation.Variant.OnRoadPrice* depreciationRate);
            return IDV;
        }
        private double CalculatePremium(double IDV, double avgOdRate = 0.0197, double noClaimBonusDiscPercent = 0.20)
        {
            double ownDamagePremium = (IDV * avgOdRate);
            double noClaimBonusDiscount = (noClaimBonusDiscPercent * ownDamagePremium);

            double totalOwnDamagePremium = (ownDamagePremium - noClaimBonusDiscount);
            int personalAccidentCover = 100;

            int legalLiabilityPaidToDriver = 50;
            int compulsoryThirdPartyCover = 1100;

            double netPremium = totalOwnDamagePremium + personalAccidentCover + legalLiabilityPaidToDriver + compulsoryThirdPartyCover;
            double gst = netPremium * 0.18;

            return (gst + netPremium);
        }
    }
}
