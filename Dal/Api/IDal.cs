using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        public ICustomers Customers { get; }
        public IItemOrders ItemOreders { get; }
        public IOrders Orders { get; }
        public IProducts Products { get; }  
        public IPurveyors Purveyors { get; }
    }
}
