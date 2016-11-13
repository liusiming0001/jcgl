using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings
{
    public interface ISchedulingManager
    {
        Task SchedulingWork(string BatchNum, string ExtractWorkInfo, string MembraneWorkInfo, string MedicinalName, string Remark, SchedulingType type);
    }
}
