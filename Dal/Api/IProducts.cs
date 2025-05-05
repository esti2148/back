using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IProducts
    {
        List<Product> GetAll(bool full=true);
        Product GetById(int Id);
        Product GetByName(string productName);
        void Add(Product product);
        void Update(Product product, int Id);
        void Remove(int Id);
    }
}
