using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlCustomer
    {
        List<BlCustomer> GetAll();
        BlCustomer GetById(int id);
        BlCustomer GetByName(string name);
        BlCustomer GetByNameAndId(string name,int id);
        void Add(BlCustomer customer);
        void Update(BlCustomer customer, int id);
        public void updateOverPluse_debt(int instutId, double totalSumNow);
        void Remove(int id);
    }
}
