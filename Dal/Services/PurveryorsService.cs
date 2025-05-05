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
    public class PurveryorsService : IPurveyors
    {
        dbcontext data;
        public PurveryorsService(dbcontext data)
        {
            this.data = data;
        }
        public void Add(Purveyor purveyor)
        {
            data.Purveyors.Add(purveyor);
            data.SaveChanges();
        }

        public List<Purveyor> GetAll()
        {
            return data.Purveyors.Include(x => x.Products).ThenInclude(y => y.ItemOreders).ToList();
        }

        public Purveyor GetById(int Id)
        {
           return GetAll().Find(x=>x.Id==Id);
        }

        public Purveyor GetByName(string purveyorName)
        {
            return GetAll().Find(x => x.Name.Equals(purveyorName));
        }

        public void Remove(int Id)
        {
            var f = data.Purveyors.ToList().Find(x => x.Id == Id);
            if (f != null) 
            {
                data.Remove(Id);
            }
            data.SaveChanges();
        }

        public void Update(Purveyor purveyor, int Id)
        {
            Purveyor p = data.Purveyors.Find(Id);
            if (p != null)
            {
                p.Products=purveyor.Products;
                p.Email=purveyor.Email;
                p.Name=purveyor.Name;
                p.Phone=purveyor.Phone; 
                p.CompanyName=purveyor.CompanyName;
                
            }

            data.SaveChanges();
        }
    }
}
