using Bl.Models;
using Bl.Services;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlItemOrders
    {
        List<BlItemOreder> GetAll();
        List<BlItemOreder> GetAllProudactInOrder(int numOrder);
        List<BlItemOreder> GetAllOrderByProductCode(int codeProduct);
         ItemOreder castingToDal(BlItemOreder BlItemOreder);
        void Add(BlItemOreder itemoreder);
        void Remove(int codeOrder);
        public void Remove(int orderCode, int productCode);
        //BLItemOrdersService castingListToBl(List<ItemOreder> itemOreders);
    }
}
