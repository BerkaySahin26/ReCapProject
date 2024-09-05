using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Net.Http.Headers;

CarManager carManager = new CarManager(new EfCarDal());
var result = carManager.GetCarDetails();
if(result.Success == true)
{
    foreach(var car in result.Data)
    {
        Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName);
    }
}
else
{
    Console.WriteLine(result.Message);
}


