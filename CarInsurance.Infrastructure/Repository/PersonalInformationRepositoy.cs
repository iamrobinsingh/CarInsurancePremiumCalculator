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
    public class PersonalInformationRepositoy : IPersonalInfomationRepository
    {
        public IEnumerable<PersonalInformation> GetAll()
        {
            JsonReadWrite readWrite = new JsonReadWrite();
            var personalInformations = JsonConvert.DeserializeObject<List<PersonalInformation>>(readWrite.Read("PersonalInformations.json"));
            return personalInformations;
        }

        public PersonalInformation Save(PersonalInformation personalInfo)
        {
            var response = new PersonalInformation();
            int maxId = 0;
            List<PersonalInformation> information = new List<PersonalInformation>();

            var data = GetAll();
            if (data != null)
            {
                maxId = data.Select(x => x.PersonalInformationId).Max();
                personalInfo.PersonalInformationId = maxId + 1;
                information.AddRange(data);
            }
            else
            {
                personalInfo.PersonalInformationId = maxId + 1;
            }
            information.Add(personalInfo);

            var jsonData = JsonConvert.SerializeObject(information);
            JsonReadWrite readWrite = new JsonReadWrite();
            readWrite.Write("PersonalInformations.json", jsonData);
            response = GetAll().FirstOrDefault(x=> x.PersonalInformationId == personalInfo.PersonalInformationId);
            return response;
        }
    }
}