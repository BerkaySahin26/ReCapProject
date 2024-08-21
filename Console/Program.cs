using Business.Concrete;
using DataAccess.Concrete.InMemory;

CarManager carManager = new CarManager(new InMemorCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}


