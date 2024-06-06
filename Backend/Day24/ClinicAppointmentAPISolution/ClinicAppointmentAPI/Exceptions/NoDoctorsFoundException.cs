namespace ClinicAppointmentAPI.Exceptions
{
    public class NoDoctorsFoundException:Exception
    {
        string msg;
        public NoDoctorsFoundException()
        {
            msg ="No Doctors Found";
        }
        public override string Message => msg;
    }
}
