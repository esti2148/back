using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlPurveryors
    {
        List<BlPurveyor> GetAll();
        BlPurveyor GetById(int Id);
        BlPurveyor GetByName(string purveyorName);
        void Add(BlPurveyor purveyor);
        void Update(BlPurveyor purveyor, int Id);
        void Remove(int Id);
    }
}
