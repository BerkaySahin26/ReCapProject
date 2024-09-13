using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public class IRentalDal : IEntityRepository<Rental>
    {
        public void Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public Rental Get(Expression<Func<Rental, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
