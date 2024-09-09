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
    public class UserManager
    {
        IUserDal _UserDal;

        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _UserDal.Add(user);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_UserDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_UserDal.Get(p => p.UserId == userId));
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
