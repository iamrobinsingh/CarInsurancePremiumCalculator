using CarInsurance.Core.Entities;
using CarInsurance.Core.Interface;
using CarInsurance.Infrastructure.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.Infrastructure.Repository
{
    public class CarInformationRepository : ICarInformationRepository
    {
        public IEnumerable<CarInformation> GetAll()
        {
            JsonReadWrite readWrite = new JsonReadWrite();
            var carInformations = JsonConvert.DeserializeObject<List<CarInformation>>(readWrite.Read("CarInformations.json"));
            return carInformations;

        }
        public CarInformation Save(CarInformation carInfo)
        {
            var response = new CarInformation();
            int maxId = 0;
            List<CarInformation> information = new List<CarInformation>();

            var data = GetAll();
            if (data != null)
            {
                maxId = data.Select(x => x.CarInformationId).Max();
                carInfo.CarInformationId = maxId + 1;
                information.AddRange(data);
            }
            else
            {
                carInfo.CarInformationId = maxId + 1;
            }
            information.Add(carInfo);

            var jsonData = JsonConvert.SerializeObject(information);
            JsonReadWrite readWrite = new JsonReadWrite();
            readWrite.Write("CarInformations.json", jsonData);
            response = GetAll().FirstOrDefault(x => x.CarInformationId == carInfo.CarInformationId);
            return response;
        }
    }
}