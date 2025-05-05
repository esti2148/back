using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class OrdersService:IOrders
    {
        dbcontext data;

        public OrdersService(dbcontext data)
        {
            this.data = data;
        }
        List<Order> IOrders.GetAll()
        {
            return data.Orders.Include(x => x.ItemOreders).ToList();
        }

        public List<Order> GetByDate(DateOnly Orderdate)
        {
            return data.Orders.Include(x=> x.ItemOreders).ToList().FindAll(a=>a.OrderDate.Equals( Orderdate));
        }
        public Order GetById(int Id)
        {
            return data.Orders.Include(x => x.ItemOreders).ToList().Find(x => x.OrderId == Id);
        }

        public int Add(Order order)
        {
           Order o= data.Orders.Add(order).Entity;
           
            data.SaveChanges(); 
            
        return   order.OrderId;
           
        }

        public void Update(Order order, int orderid)
        {
            Order o = data.Orders.Find(orderid);
            if (o != null)
            {
                o.Institute=order.Institute;
                o.ToatlSum=order.ToatlSum;
                o.InstituteId=order.InstituteId;
                o.OrderDate=order.OrderDate;
                o.SupplyDate=order.SupplyDate;
                o.ItemOreders=order.ItemOreders;
            }

            data.SaveChanges();
        }

        public void Remove(int orderId)
        {
            var f = GetById(orderId);
            if (f !=null) 
            { 
                data.Remove(f);
            }
            data.SaveChanges();
        }
    }
}
