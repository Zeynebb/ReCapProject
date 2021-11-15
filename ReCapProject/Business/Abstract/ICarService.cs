using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        List<Car> GetAll();

        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByColorId(int id);
    }
}
