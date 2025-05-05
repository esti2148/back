using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBl
    {
        IBlCustomer Customer { get; }
         
        IBlItemOrders ItemOreders { get; }

        IBlOrders Orders { get; }

        IBlProducts Products { get; }
        IBlPurveryors Purveryors { get; }
       
    }
}
