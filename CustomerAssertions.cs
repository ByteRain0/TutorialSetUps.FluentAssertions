using FluentAssertions;
using FluentAssertionsSetup.CustomAssertions;

namespace FluentAssertionsSetup.CustomAssertions;

public class CustomerAssertions
{
    private readonly Customer customer;

    public CustomerAssertions(Customer customer)
    {
        this.customer = customer;
    }

    [CustomAssertion]
    public void BeActive(string because = "", params object[] becauseArgs)
    {
        customer.Active.Should().BeTrue(because, becauseArgs);
    }
}
