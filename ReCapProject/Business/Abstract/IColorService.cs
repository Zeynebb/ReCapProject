using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IDataResult<List<Color>> GetAll();

        IDataResult<List<Color>> GetAllByColorId(int colorId);
    }
}
