using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IItemOrders
    {
        List<ItemOreder> GetAll();
       
        List<ItemOreder> GetAllOrderByProductCode(int codeProduct);
        void Add(ItemOreder itemoreder);
        void Remove(int codeOrder,int codeProduct);
        
    }
}
