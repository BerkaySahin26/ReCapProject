using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager
    {
        IColorDal _ColorDal;


        public ColorManager(IColorDal colorDal)
        {
            _ColorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _ColorDal.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ColorDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_ColorDal.Get(p => p.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
