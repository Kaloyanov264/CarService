using CarService.Models.Responses;

namespace CarService.BL.Interfaces
{
    public interface ISellCar
    {
        SellCarResult Sell(Guid carId, Guid customerId);
    }
}