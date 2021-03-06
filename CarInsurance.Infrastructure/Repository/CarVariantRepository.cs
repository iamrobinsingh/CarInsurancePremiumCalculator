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
    public class CarVariantRepository : ICarVariantRepository
    {
        public IEnumerable<CarVariant> GetAll()
        {
            JsonReadWrite readWrite = new JsonReadWrite();
            var variants = JsonConvert.DeserializeObject<List<CarVariant>>(readWrite.Read("CarVariants.json"));
            return variants;
        }
    }
}