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
    public class BLProductsService : IBlProducts  
    {
        IProducts data;
        IPurveyors suppliers;
  
        IBlItemOrders _blitemOrdersService;
        

        public BLProductsService(IDal datad,IBlItemOrders itBl)
        {
            this.data = datad.Products;
            _blitemOrdersService = itBl;
            suppliers = datad.Purveyors;
           
        }
            public void Add(BlProduct product)=>
                   data.Add(castingToDal(product));
        

        public List<BlProduct> GetAllSimple()=>
                    castingListToBl(data.GetAll(false));
        
        public List<BlProduct> GetAllFull()=>
                     castingListToBl(data.GetAll(true));
        

        public BlProduct GetById(int Id)=>
                    castingToBl(data.GetById(Id) ?? throw new Exception("מוצר לא קיים"));
        

        public BlProduct GetByName(string productName)=>
                    castingToBl (data.GetByName(productName) ?? throw new Exception("מוצר לא קיים"));
        

        public void Remove(int Id)=>
                    data.Remove(Id);    
        

        public void Update(BlProduct product, int Id)=>
        
            data.Update(castingToDal(product), Id);   
     

        public void Inventory_calculation_and_update(int? qty,int id)
        {
            
            Product prod = data.GetById(id);
            if (prod.Stock - qty > 0)
                prod.Stock -= qty;   
        }

        public List<BlProduct> OrderProduct()
        {
            List<BlProduct> ProductsToOrder = new List<BlProduct>();
            GetAllSimple().ForEach( x => { if (x.Stock <= 30) ProductsToOrder.Add(x); } ) ;

            return ProductsToOrder;                       
        }


        #region "cast"
        private BlProduct castingToBl(Product dalproduct)
        {
            List<BlItemOreder> itmOrdr = ((BLItemOrdersService)_blitemOrdersService).castingListToBl(dalproduct.ItemOreders.ToList());
            return new BlProduct()
            {
                Price= dalproduct.Price,
                Size = dalproduct.Size,
                IdPurveyor = dalproduct.IdPurveyor,
                NamePurveyor=suppliers.GetById(dalproduct.IdPurveyor).Name,
                ProductName = dalproduct.ProductName,
                Dscribe=dalproduct.Dscribe,
                Id=dalproduct.Id,
                Stock=dalproduct.Stock,
                ItemOreders=itmOrdr,
            };
        }
        public List<BlProduct> castingListToBl(List<Product> dalproduct)
        {
            List<BlProduct> castBlPro = new List<BlProduct>();
            dalproduct.ForEach(x => castBlPro.Add(castingToBl(x)));
            return castBlPro;
        }
        public Product castingToDal(BlProduct Blproduct)
        {
            return new Product()
            {
                Price = Blproduct.Price,
                Size = Blproduct.Size,
                IdPurveyor = Blproduct.IdPurveyor,
                ProductName = Blproduct.ProductName,
                Dscribe = Blproduct.Dscribe,
                Id = Blproduct.Id,
                Stock = Blproduct.Stock,
            };
        }
        public List<Product> castingListToDal(List<BlProduct> BlProducts)
        {
            List<Product> castDalProd = new List<Product>();
            BlProducts.ForEach(x => castDalProd.Add(castingToDal(x)));
            return castDalProd;
        }
        #endregion 
    }
}
