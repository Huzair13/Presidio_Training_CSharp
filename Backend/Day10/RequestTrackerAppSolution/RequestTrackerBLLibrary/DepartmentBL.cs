using RequestTrackerAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RequestTrackerBLLibrary.CustomException;
using RequestTrackerDALLibrary;
namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            //_departmentRepository = new DepartmentRepository();//Tight coupling
            _departmentRepository = departmentRepository;//Loose coupling
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var department = _departmentRepository.GetAll().Find(d => d.Name == departmentOldName);
            if(department != null)
            {
                department.Name = departmentNewName;
                _departmentRepository.Update(department);
                return department;
            }
            throw new DepartmentNotFoundException();

        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if(department!=null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }

        //public Department GetDepartmentByName(string departmentName)
        //{
        //    var department = _departmentRepository.GetAll().Find(d => d.Name == departmentName);
        //    if(department != null )
        //    {
        //        return department;
        //    }
        //    throw new DepartmentNotFoundException();
        //}

        public Department GetDepartmentByName(string departmentName)
        {
            var departments = _departmentRepository.GetAll();
            for (int i = 0; i < departments.Count; i++)
                if (departments[i].Name == departmentName)
                    return departments[i];
            throw new DepartmentNotFoundException();
        }


        public int GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            if(department != null)
            {
                return department.Department_Head;
            }
            throw new DepartmentNotFoundException();
        }

        public List<Department> GetDepartmentList()
        {
            return _departmentRepository.GetAll();
        }
    }
}
