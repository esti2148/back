using Dal.Models;

namespace Dal.Api
{
    public interface IOrders
    {
        List<Order> GetAll();
        List<Order> GetByDate(DateOnly OrderDate);
        Order GetById(int id);
        int Add(Order order);
        void Update(Order order, int orderId);
        void Remove(int orderId);
    }
}
