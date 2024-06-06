using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
namespace ClinicAppointmentBLLibrary
{
    public class DoctorBL
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBL()
        {
            _doctorRepository=new DoctorRepository();
        }
    }
}
