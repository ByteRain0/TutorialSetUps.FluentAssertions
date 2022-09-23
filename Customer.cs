namespace FluentAssertionsSetup.CustomAssertions;

public class Customer
{
    public bool Active { get; set; }

    public int Test(int value)
    {
        if(value > 0) throw new InvalidOperationException("SomeMessage");

        return value;
    }
}