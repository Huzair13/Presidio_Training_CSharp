using RequestTrackerAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RequestTrackerDALLibrary;
namespace RequestTrackerBLLibrary
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

    }
}
