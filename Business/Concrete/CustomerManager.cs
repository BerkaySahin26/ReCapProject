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
    public class CustomerManager
    {
        ICustomerDal _CustomerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _CustomerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _CustomerDal.Add(customer);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Customer Customer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_CustomerDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Customer> GetById(int UserId)
        {
            return new SuccessDataResult<Customer>(_CustomerDal.Get(p => p.UserId == UserId));
        }

        public IResult Update(Customer Customer)
        {
            throw new NotImplementedException();
        }
    }
}
