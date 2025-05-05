using Bl.Api;
using Dal.Api;
using Dal;
using Bl.Services;

namespace Bl
{
    public class BlManeger : IBl
         
    {
       
        public IBlCustomer Customer  { get; }

        public IBlItemOrders ItemOreders { get; }


        public IBlOrders Orders  { get; }

        public IBlProducts Products  { get; }

        public IBlPurveryors Purveryors  { get; }

        
        public BlManeger() 
        {
            IDal dal = new DalManger();
        
            ItemOreders = new BLItemOrdersService(dal);
            Products= new BLProductsService(dal,ItemOreders);
            Orders =new BLOrdersService(dal,dal.ItemOreders, ItemOreders); 
            Customer = new BLCustomerService(dal,Orders,Products,ItemOreders);
            Purveryors = new BLPurveryorsService(dal,Products);
       


            /*
              ServiceCollection services = new ServiceCollection();

                        //services.AddSingleton<IDal, DalManager>();
                        services.AddSingleton<IBlItemOrders, BLItemOrdersService>();
                        services.AddSingleton<IBlOrders, BLOrdersService>();

                        // ... 
                        // הגדרת ספק לאוסף הסרוויסים
                        ServiceProvider serviceProvider = services.BuildServiceProvider();
                        ItemOreders = serviceProvider.GetRequiredService<IBlItemOrders>();
                        Orders = serviceProvider.GetRequiredService<IBlOrders>();

             */
        }
    } 
}