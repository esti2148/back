using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IPurveyors
    {
        List<Purveyor> GetAll();
        Purveyor GetById(int Id);
        Purveyor GetByName(string purveyorName);
        void Add(Purveyor purveyor);
        void Update(Purveyor purveyor, int Id);
        void Remove(int Id);
    }
}
