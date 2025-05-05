using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;

namespace Bl.Services
{
    public class BLOrdersService : IBlOrders
    {
        IBlItemOrders dataItem;
    
        IOrders data;
        //IItemOrders dataorders;
        public BLOrdersService(IDal datad, IItemOrders item, IBlItemOrders bl)
        {
            this.data = datad.Orders;
            dataItem = bl;
        }
     
        public List<BlOrder> GetAll()=>
             castingListToBl(data.GetAll());
        

        public BlOrder GetById(int id)=>
       
            CastToBl(data.GetById(id) ?? throw new Exception("הזמנה לא קיים"));
        

        public List<BlOrder> GetByDate(DateOnly OrderDate)=>
           castingListToBl(data.GetByDate(OrderDate) ?? throw new Exception("הזמנה לא קיים"));
       

        public List<BlOrder> giveMyAllOrders(int id)
        {
            List<BlOrder> myOrders =castingListToBl( data.GetAll().FindAll(x=> x.InstituteId==id));

            return myOrders;

        }

        public int Add(BlOrder order)
        {
            int id= data.Add(CastTodal(order));
            order.ItemOreders.ForEach(x => { x.OrderId = id; dataItem.Add(x); });
            ;
            return id;
        }

        public void Remove(int orderId)
        {
            Order order = data.GetById(orderId);
            dataItem.Remove(orderId); 
            data.Remove(orderId);
        }
        public void Update(BlOrder order, int orderId)=>
                   data.Update(CastTodal(order), orderId);
       

        public int Calculation_of_days_from_today_to_sale(DateTime SupplyDate, DateTime OrderDate)
        {
            //int f= SupplyDate.DayOfYear- OrderDate.DayOfYear;
            TimeSpan difference = SupplyDate - OrderDate;
            // המרה למספר ימים 
            int totalDays = difference.Days;        
            return totalDays;
        }



        #region "cast"
        public Order CastTodal(BlOrder bl)
        {
            return new()
            {
                ToatlSum = bl.ToatlSum,
                OrderDate = bl.OrderDate,
                SupplyDate = bl.SupplyDate,
                InstituteId = bl.InstituteId
            };
        }
        public BlOrder CastToBl(Order order)
        {
            List<BlItemOreder> blItemOreder = new List<BlItemOreder>();
            if (order.ItemOreders.Count > 0)
            {
                blItemOreder = ((BLItemOrdersService)dataItem).castingListToBl(order?.ItemOreders.ToList());
            }


            BlOrder bl = new()
            {
                OrderId = order.OrderId,
                ToatlSum = order.ToatlSum,
                ItemOreders = blItemOreder,
                OrderDate = order.OrderDate,
                SupplyDate = order.SupplyDate,
                InstituteId = order.InstituteId,

            };

            return bl;
        }
        public List<BlOrder> castingListToBl(List<Order> dalOrder)
        {
            List<BlOrder> castBlitem = new List<BlOrder>();
            dalOrder.ForEach(x => castBlitem.Add(CastToBl(x)));
            return castBlitem;
        }

        BlOrder IBlOrders.CastToBl(Order order)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
