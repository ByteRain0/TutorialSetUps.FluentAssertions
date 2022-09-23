namespace FluentAssertionsSetup.CustomAssertions;

public static class CustomerAssertionExtensions
{
    public static CustomerAssertions Should(this Customer instance)
    {
        return new CustomerAssertions(instance);
    }
}