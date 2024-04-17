using RequestTrackerAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RequestTrackerDALLibrary;
;
namespace RequestTrackerBLLibrary
{
    public interface IDepartmentService
    {
        int AddDepartment(DepartmentBL department);
        DepartmentBL ChangeDepartmentName(string departmentOldName, string departmentNewName);
        DepartmentBL GetDepartmentById(int id);
        DepartmentBL GetDepartmentByName(string departmentName);
        int GetDepartmentHeadId(int departmentId);


    }
}
