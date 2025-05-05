using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlOrders
    {
       // public List<BlOrder> giveMyAllOrders(int id);

        List<BlOrder> GetAll();
        List<BlOrder> GetByDate(DateOnly OrderDate);
        BlOrder GetById(int id);    
        int Add(BlOrder order);
        void Update(BlOrder order, int orderId);
        void Remove(int orderId);
        BlOrder CastToBl(Order order);

    }
}
