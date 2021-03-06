using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInsurance.Application.Dto;
using CarInsurance.Application.Interfaces;
using CarInsurance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurance.Web.Controllers
{
    public class CarInsuranceController : Controller
    {
        private readonly ICarInformationService _carInformationService;
        public CarInsuranceController(ICarInformationService carInformationService)
        {
            _carInformationService = carInformationService;
        }

        public IActionResult Index()
        {
            var obj = new CarInsuranceViewModel();
            obj.CarBrands = _carInformationService.GetAllCarBrands().Result;
            return View(obj);
        }

        [HttpPost]
        public CarInsurancePremiumResponseDto CalculateIDVandPremium(CalculateIDVObjectDto dto)
        {
            var response = new CarInsurancePremiumResponseDto();
            response = _carInformationService.CalculateIDVandPremium(dto);
            return response;

        }
    }
}