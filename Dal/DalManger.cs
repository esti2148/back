using Dal.Api;
using Dal.Models;
using Dal.Services;

namespace Dal
{
    public class DalManger : IDal
    {
        public ICustomers Customers { get; }

        public IItemOrders ItemOreders { get; }

        public IOrders Orders { get; }

        public IProducts Products { get; }

        public IPurveyors Purveyors { get; }

        public DalManger()
        {
           dbcontext data = new dbcontext();

            Customers =new CustomersService(data);
            ItemOreders = new ItemOrdersService(data);
            Orders = new OrdersService(data); 
            Products = new ProductsService(data);
            Purveyors=new PurveryorsService(data);  
        }

       
    }
}