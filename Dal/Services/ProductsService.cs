using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class ProductsService : IProducts
    {
        dbcontext data;
        public ProductsService(dbcontext data) 
        {
            this.data = data;
        }

        public void Add(Product product)
        {
            data.Products.Add(product);
            data.SaveChanges();
        }

        public List<Product> GetAll(bool full)
        {
            if (full)
               return data.Products.Include(x=>x.ItemOreders).ToList();
            return data.Products.ToList();

        }

        public Product GetById(int Id)
        {
            return data.Products.Include(x => x.ItemOreders).ToList().Find(x => x.Id == Id);
        }

        public Product GetByName(string productName)
        {
            return data.Products.Include(x => x.ItemOreders).ToList().Find(x => x.ProductName.Equals(productName));
        }

        public void Remove(int Id)
        {
            var f = data.Products.ToList().Find(x => x.Id == Id);
            if(f != null) 
            {
                data.Remove(Id);
            }
            data.Remove(Id);
            data.SaveChanges();
        }

        public void Update(Product product, int Id)
        {

            Product p = data.Products.Find(Id);
            if (p != null)
            {
                p.Price=product.Price;
                p.IdPurveyor=product.IdPurveyor;
                p.Dscribe=product.Dscribe;
                p.Size=product.Size;
                p.Stock=product.Stock;
                p.IdPurveyorNavigation=product.IdPurveyorNavigation;
                p.ProductName=product.ProductName;
            }

            data.SaveChanges();
        }
    }
}
