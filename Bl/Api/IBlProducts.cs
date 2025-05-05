using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlProducts
    {
        List<BlProduct> GetAllFull();
        List<BlProduct> GetAllSimple();
        BlProduct GetById(int Id);
        BlProduct GetByName(string productName);
        void Add(BlProduct product);
        void Update(BlProduct product, int Id);
        void Remove(int Id);
        void Inventory_calculation_and_update(int? qty, int id);
        public List<BlProduct> OrderProduct();
    }

}



