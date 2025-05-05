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
    public class BLCustomerService : IBlCustomer
    {
        ICustomers data;
        IOrders dataOrders;
        IBlOrders _blordersService;
        IBlProducts _blproductsService;
        IBlItemOrders _blitemOrdersService;
        public BLCustomerService(IDal datad,IBlOrders bl, IBlProducts blproductsService,IBlItemOrders itBl)
        {
            this.data = datad.Customers;
            _blordersService = bl;
            dataOrders = datad.Orders;
            _blproductsService = blproductsService;
            _blitemOrdersService = itBl;
      
        }
        public List<BlCustomer> GetAll() =>  castingListToBl(data.GetAll());

        public BlCustomer GetById(int id)
        {
            BlCustomer c = castingToBl(data.GetById(id));
                    c.Orders.ForEach(x => {
                    x.ItemOreders.ForEach(y =>
                {
                    y.ProductName = _blproductsService.GetById(y.ProductId).ProductName;
                    y.TempSum = _blproductsService.GetById(y.ProductId).Price * y.Qty;
                    y.Size = _blproductsService.GetById(y.ProductId).Size;
                    y.Dscribe = _blproductsService.GetById(y.ProductId).Dscribe;
                  
                });
                    }); 
            return c?? throw new Exception("לקוח לא קיים");


                
        }
        public BlCustomer GetByName(string name)=> castingToBl(data.GetByName(name) ?? throw new Exception("לקוח לא קיים"));

        public BlCustomer GetByNameAndId(string name, int id) => castingToBl(data.GetByNameAndId(name, id) ?? throw new Exception("לקוח לא קיים"));
        public void Update(BlCustomer customer,int id)=>
            data.Update(castingToDal(customer),id);
        
        public void Remove(int id) 
        {
            Customer? c = data.GetById(id);
            if (c == null)
            {
                throw new Exception("לקוח לא קיים");
            }
            data.Remove(id);
        }

        public void Add(BlCustomer customer)=>
      
            data.Add(castingToDal(customer));
       
        public void updateOverPluse_debt(int instutId, double totalSumNow)
        {
            Customer c = data.GetById(instutId);
           c.OverPluseDebt += (int)(totalSumNow);
            data.Update(c,instutId);
        }

        public void AddorderToCustomer(BlOrder o, int idCust)
        {
            BlCustomer c = GetById(idCust);
            int idd = _blordersService.Add(o);
            o.ItemOreders.ForEach(x => {
                _blproductsService.Inventory_calculation_and_update(x.Qty, x.ProductId);
                }) ;
            updateOverPluse_debt(c.InstituteId, ((double)_blordersService.GetById(idd).ToatlSum)*-1);
        }

        public void RemoveorderToCustomer(int idCus,int idItemOrder)
        {
            BlCustomer customer = GetById(idCus);
            int? sum = dataOrders.GetAll().Find( x => x.InstituteId == idCus && x.OrderId == idItemOrder).ToatlSum;
            dataOrders.GetAll().Find(x => x.InstituteId == idCus && x.OrderId == idItemOrder).ItemOreders.
                ToList().ForEach(x => _blproductsService.Inventory_calculation_and_update(x.Qty*-1, x.ProductId));
            updateOverPluse_debt(idCus, sum.Value);
            _blordersService.Remove(idItemOrder);

        }
        

        #region "cast"
        private BlCustomer castingToBl(Customer dalCustomer)
        {
            List<BlOrder> orders = ((BLOrdersService)_blordersService).castingListToBl(dalCustomer.Orders.ToList());
            return new BlCustomer()
            {
                Address = dalCustomer.Address,
                Email = dalCustomer.Email,
                InstituteName = dalCustomer.InstituteName,
                InstituteId = dalCustomer.InstituteId,
                OverPluseDebt = dalCustomer.OverPluseDebt,
                Phone = dalCustomer.Phone,
                SellingPlace = dalCustomer.SellingPlace,
                Orders= orders,
            };
        }
        public List<BlCustomer> castingListToBl(List<Customer> dalCustomers)
        {
            List<BlCustomer> castBlCus = new List<BlCustomer>();
            dalCustomers.ForEach(x => castBlCus.Add(castingToBl(x)));
            return castBlCus;
        }
        public Customer castingToDal(BlCustomer BlCustomer)
        {
            return new Customer()
            {
                Address = BlCustomer.Address,
                Email = BlCustomer.Email,
                InstituteName = BlCustomer.InstituteName,
                InstituteId = BlCustomer.InstituteId,
                OverPluseDebt =BlCustomer.OverPluseDebt,
                Phone = BlCustomer.Phone,
                SellingPlace = BlCustomer.SellingPlace,
            };
        }

        public List<Customer> castingListToDal(List<BlCustomer> BlCustomers)
        {
            List<Customer> castDalCus = new List<Customer>();
            BlCustomers.ForEach(x => castDalCus.Add(castingToDal(x)));
            return castDalCus;
        }
        #endregion 

       
    }
}
