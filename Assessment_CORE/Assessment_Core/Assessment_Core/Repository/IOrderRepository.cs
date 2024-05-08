using Assessment_Core.Models;

namespace Assessment_Core.Repository
{
    public interface IOrderRepository
    {
        Task<Models.Order> GetOrderById(int id);

    }
}
