using CarService.Models.Responses;

namespace CarService.BL.Interfaces
{
    public interface ISellCar
    {
        Task<SellCarResult> Sell(Guid carId, Guid customerId);
    }
}