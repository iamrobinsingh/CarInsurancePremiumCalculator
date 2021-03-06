using CarInsurance.Core.Entities;
using CarInsurance.Core.Interface;
using CarInsurance.Infrastructure.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace CarInsurance.Infrastructure.Repository
{
    public class CarBrandRepository : ICarBrandRepository
    {
        public async Task<IEnumerable<CarBrand>> GetAll()
        {
            JsonReadWrite readWrite = new JsonReadWrite();
            var brands = JsonConvert.DeserializeObject<List<CarBrand>>(readWrite.Read("CarBrands.json"));
            return brands;
        }
    }
}