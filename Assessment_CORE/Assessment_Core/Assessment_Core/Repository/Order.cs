using Assessment_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Assessment_Core.Repository

{
    public class Order : IOrderRepository
    {
        private readonly NwContext context;

        public Order(NwContext context)
        {
            this.context = context;
        }
        public Task<Models.Order> GetOrderById(int id)
        {
            var order = context.Orders.FirstOrDefault(a => a.OrderId == id);
            return Task.FromResult(order);
        }
    }
}

