using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BLItemOrdersService : IBlItemOrders
    {
        
        IItemOrders data;
        IOrders dataOrder;
        IProducts dataProducts;
       
        public BLItemOrdersService(IDal datad)
        {
            this.data = datad.ItemOreders;
            dataOrder = datad.Orders;
            dataProducts = datad.Products;
          
        }

        public List<BlItemOreder> GetAll()=>
            castingListToBl(data.GetAll());
        

        public void Add(BlItemOreder itemorder)
        {
            double? totalsum = 0;
       
            data.Add(castingToDal(itemorder));
            data.GetAll().ForEach(x =>
            {
                if (x.OrderId == itemorder.OrderId && x.ProductId==itemorder.ProductId)
                {
                    totalsum = x.Product.Price * x.Qty;
                    
                }
               
            });
            
            Order order= dataOrder.GetById(itemorder.OrderId);
          
           
            order.ToatlSum += ((int)(totalsum));
            dataOrder.Update(order,order.OrderId);
        }

        public List<BlItemOreder> GetAllOrderByProductCode(int codeProduct)
        {
            return castingListToBl(data.GetAllOrderByProductCode(codeProduct));
        }

        public List<BlItemOreder> GetAllProudactInOrder(int numOrder)
        {
            return castingListToBl(data.GetAll().FindAll(x => x.OrderId == numOrder));
        }


        public void Remove(int codeOrder)
        {
            List<BlItemOreder> prodlist = GetAllProudactInOrder(codeOrder);
            prodlist.ForEach(x => data.Remove(codeOrder, x.ProductId) );
        }
        public void Remove(int orderCode,int productCode)
        {
            Order order = dataOrder.GetById(orderCode);
            data.GetAll().ForEach(x =>
            {
                if (x.OrderId == orderCode && x.ProductId == productCode)
                    order.ToatlSum -= (int)(x.Product.Price * x.Qty);
            });
            data.Remove(orderCode, productCode);
            if (order != null)
            {
                if (order.ToatlSum == 0)
                    dataOrder.Remove(orderCode);
            }
        }


        
        #region "cast"
        public BlItemOreder castingToBl(ItemOreder dalItemOrder)
        {
            return new BlItemOreder()
            {
                OrderId = dalItemOrder.OrderId,
                ProductId = dalItemOrder.ProductId,
                ProductName=dataProducts.GetById(dalItemOrder.ProductId).ProductName,
                Dscribe=dataProducts.GetById(dalItemOrder.ProductId).Dscribe,
                Size=dataProducts.GetById(dalItemOrder.ProductId).Size,
                Qty = dalItemOrder.Qty,
                
            };
        }
        public List<BlItemOreder> castingListToBl(List<ItemOreder> dalItemOrder)
        {
            List<BlItemOreder> castBlitem = new List<BlItemOreder>();
            dalItemOrder.ForEach(x => castBlitem.Add(castingToBl(x)));
            return castBlitem;
        }
        public ItemOreder castingToDal(BlItemOreder BlItemOreder)
        {
            return new ItemOreder()
            {
                OrderId = BlItemOreder.OrderId,
                ProductId = BlItemOreder.ProductId,
                Qty = BlItemOreder.Qty   
            };
        }
        #endregion



    }
}
