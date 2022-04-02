namespace SchoolModel;

public class WrongPersonTypeException : Exception
{
    public WrongPersonTypeException(string message) : base(message)
    {

    }
}