namespace PizzaOrderAPI.Exceptions
{
    public class UserAlreadyExistsException :Exception
    {
        string msg;
        public UserAlreadyExistsException()
        {
            msg = "User Already Exists";
        }
        public override string Message => msg;
    }
}
