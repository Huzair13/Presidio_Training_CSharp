namespace PizzaOrderAPI.Exceptions
{
    public class NoPizzasFoundException:Exception
    {
        string msg;
        public NoPizzasFoundException()
        {
            msg = "No Pizzas are Found";
        }
        public override string Message => msg;
    }
}
