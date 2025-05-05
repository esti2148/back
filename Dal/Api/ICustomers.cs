using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface ICustomers
    {
        List<Customer> GetAll(); 
        Customer GetById(int id); 
        Customer GetByName(string name);
        Customer GetByNameAndId(string name, int id);
        void Add(Customer customer);
        void Update(Customer customer, int id);
        void Remove(int id);
    }
}
