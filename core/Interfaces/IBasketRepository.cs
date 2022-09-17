using core.Entites;

namespace core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketasync(string BasketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string BasketId);
    }
}