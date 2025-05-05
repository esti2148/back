using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class ItemOrdersService:IItemOrders
    {

        dbcontext data;

        public ItemOrdersService(dbcontext data)
        {
            this.data = data;
        }
        
        public void Add(ItemOreder itemoreder)
        {
             data.ItemOreders.Add(itemoreder);
            /*      data.ItemOreders.ToList().Add(itemoreder);*/
            data.SaveChanges();
        }

        public List<ItemOreder> GetAll()
        {
            return data.ItemOreders.Include(x=>x.Product).ToList();
        }

        public List<ItemOreder> GetAllOrderByProductCode(int codeProduct)
        {
            return GetAll().FindAll(x => x.ProductId == codeProduct);    
        }

       
        public void Remove(int codeOrder, int codeProduct)
        {
           var f = GetAllOrderByProductCode(codeProduct).Find(x => x.OrderId == codeOrder);
            if (f != null) 
            { 
                data.ItemOreders.Remove(f);
                data.SaveChanges();
            }

        }
    }
}
