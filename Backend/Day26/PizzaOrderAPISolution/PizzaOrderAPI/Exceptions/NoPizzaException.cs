namespace PizzaOrderAPI.Exceptions
{
    public class NoPizzaException :Exception
    {
        string msg;
        public NoPizzaException()
        {
            msg = "No Pizza Found";
        }
        public override string Message => msg;
    }
}
