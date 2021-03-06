using CarInsurance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.Core.Interface
{
    public interface ICarBrandRepository
    {
        Task<IEnumerable<CarBrand>> GetAll();
    }
}
