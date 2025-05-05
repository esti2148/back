using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    
    public class CustomersService:ICustomers
    {
        dbcontext data;

        public CustomersService(dbcontext data)
        { 
            this.data = data;
        }
        public List<Customer> GetAll()
        {
           return data.Customers.Include(x=> x.Orders).ThenInclude(y=>y.ItemOreders).ToList();
        }
        public Customer GetById(int id)
        { 
            return data.Customers.Include(x=>x.Orders).ThenInclude(v=> v.ItemOreders).ToList().Find(x => x.InstituteId == id);
        }
        public Customer GetByName(string name) 
        {
            return data.Customers.ToList().Find(x => x.InstituteName == name);
        }
        public Customer GetByNameAndId(string name, int id)
        {
            return data.Customers.Include(x => x.Orders).ThenInclude(v => v.ItemOreders).ToList().Find(x =>  x.InstituteName == name && x.InstituteId == id);
        }


        public void Add(Customer customer) 
        {
            data.Customers.Add(customer);
            data.SaveChanges();
            data.Customers.Max(x=>x.InstituteId);
        }
        public void Update(Customer customer,int id) 
        {
          
            Customer c=data.Customers.Find(id);
            if (c!=null) { 
                c.InstituteName=customer.InstituteName;
                c.Email=customer.Email;
                c.Phone=customer.Phone;
                c.Address=customer.Address;
                c.OverPluseDebt=customer.OverPluseDebt;
                c.SellingPlace=customer.SellingPlace;
                }

            data.SaveChanges();  
        }
        public void Remove(int id)
        {
            var f = GetById(id);
            if (f != null) 
            {
              //  data.Customers.ToList().Remove(GetById(id)) ;  
                data.Customers.Remove(f);
            }
            
            data.SaveChanges();   
        }
    }
}
