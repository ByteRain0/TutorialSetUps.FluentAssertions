using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using FluentAssertionsSetup.CustomAssertions;
using System.Net;

namespace FluentAssertionsSetup;

/// <summary>
/// Tips and tricks:https://fluentassertions.com/tips/#general-tips
/// </summary>
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void OldApproach()
    {
        // Arrange
        var number1 = 10;
        var number2 = 20;

        // Act
        var number3 = number1 + number2;

        // Assert
        Assert.That(number3, Is.EqualTo(30));
    }

    /// <summary>
    /// https://fluentassertions.com/strings/
    /// </summary>
    [Test]
    public void Strings()
    {
        // Simple demo of the extension methods for strings.
        string actual = "ABCDEFGHI";
        actual.Should()
            .StartWith("AB")
            .And.EndWith("HI")
            .And.Contain("EF")
            .And.HaveLength(9);

        string theString = "";
        theString.Should().NotBeNull();
        theString.Should().BeNull();
        theString.Should().BeEmpty();
        theString.Should().NotBeEmpty("because the string is not empty");
        theString.Should().HaveLength(0);
        theString.Should().BeNullOrWhiteSpace(); // either null, empty or whitespace only
        theString.Should().NotBeNullOrWhiteSpace();
    }

    /// <summary>
    /// https://fluentassertions.com/collections/
    /// </summary>
    [Test]
    public void Collections()
    {
        // Work with collections.
        IEnumerable<int> collection = new[] { 1, 2, 5, 8 };
        collection.Should()
            .NotBeEmpty()
            .And.HaveCount(4, "because we thought we put four items in the collection")
            .And.ContainInOrder(new[] { 2, 5 })
            .And.OnlyContain(n => n > 0)
            .And.ContainItemsAssignableTo<int>();
    }

    [Test]
    public void CustomAssertions() 
    {
        // Creating custom assertions.
        var client = new Customer();
        client.Should().BeActive();
    }

    /// <summary>
    /// https://fluentassertions.com/nullabletypes/
    /// </summary>
    
    [Test]
    public void Nullable()
    {
        // Nullable types
        
        int? theInt = 3;
        theInt.Should().HaveValue();
        theInt.Should().NotBeNull();
    }

    /// <summary>
    /// https://fluentassertions.com/datetimespans/
    /// </summary>
    [Test]
    public void DateTime()
    {
        // Date Time
        var theDatetime = 1.March(2010).At(22, 15).AsLocal();
        theDatetime.Should().Be(1.March(2010).At(22, 15));
        theDatetime.Should().BeAfter(1.February(2010));
        theDatetime.Should().BeBefore(2.March(2010));
        theDatetime.Should().BeOnOrAfter(1.March(2010));
        theDatetime.Should().BeOnOrBefore(1.March(2010));
        theDatetime.Should().BeSameDateAs(1.March(2010).At(22, 16));
        theDatetime.Should().BeIn(DateTimeKind.Local);
    }

    /// <summary>
    /// https://fluentassertions.com/exceptions/
    /// </summary>
    [Test]
    public void Exceptions()
    {
        // Creating custom assertions.
        var client = new Customer();
        client.Should().BeActive();

        client.Invoking(x => x.Test(10))
           .Should().Throw<InvalidOperationException>()
           .WithMessage("SomeException");

        // If you prefer the AAA style then you could use it like this as well.
        Action act = () => client.Test(10);

        act.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("SomeException");

    }

    /// <summary>
    /// https://fluentassertions.com/httpresponsemessages/
    /// </summary>
    [Test]
    public void WorkingWithHttp()
    {
        // Working with HTTP.
        var successfulResponse = new HttpResponseMessage(HttpStatusCode.OK);
        successfulResponse.Should().BeSuccessful("it's set to OK"); // (HttpStatusCode = 2xx)

        var redirectResponse = new HttpResponseMessage(HttpStatusCode.Moved);
        redirectResponse.Should().BeRedirection("it's set to Moved"); // (HttpStatusCode = 3xx)

        var clientErrorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest);
        clientErrorResponse.Should().HaveClientError("it's set to BadRequest"); // (HttpStatusCode = 4xx)
        clientErrorResponse.Should().HaveError("it's set to BadRequest"); // (HttpStatusCode = 4xx or 5xx)
    }

    [Test]
    public void AssertionScope()
    {
        int number = 10;
        using (new AssertionScope())
        {
            number.Should().BeGreaterThan(100);
            number.Should().BeLessThanOrEqualTo(9);
        }
    }
}