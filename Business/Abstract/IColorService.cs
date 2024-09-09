using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetById(int id);
        IResult Add(Color color);
        IResult Remove(Color color);
        IResult Update (Color color);   

    }
}
