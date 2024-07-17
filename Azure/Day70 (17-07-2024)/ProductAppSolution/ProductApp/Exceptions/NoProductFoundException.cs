namespace ProductApp.Exceptions
{
    public class NoProductFoundException :Exception
    {
        string msg;
        public NoProductFoundException()
        {
            msg = "No Products are Found";
        }
        public override string Message => msg;
    }
}
