using Infobip.Api.Client;

namespace ApiClient.Tests;

[TestClass]
public class ConfigurationTest
{
    [TestMethod]
    public void ShouldThrowArgumentExceptionForNullBasePath()
    {
        var configuration = new Configuration();

        Assert.ThrowsExactly<ArgumentException>(() => configuration.BasePath = null!);
    }

    [TestMethod]
    public void ShouldThrowArgumentExceptionForEmptyBasePath()
    {
        var configuration = new Configuration();

        Assert.ThrowsExactly<ArgumentException>(() => configuration.BasePath = "");
    }

    [TestMethod]
    public void ShouldThrowArgumentExceptionForWhitespaceOnlyBasePath()
    {
        var configuration = new Configuration();

        Assert.ThrowsExactly<ArgumentException>(() => configuration.BasePath = "   ");
    }

    [TestMethod]
    public void ShouldThrowArgumentExceptionForHttpScheme()
    {
        var configuration = new Configuration();

        var exception = Assert.ThrowsExactly<ArgumentException>(() => configuration.BasePath = "http://api.infobip.com"
        );

        StringAssert.Contains(exception.Message, "HTTP is not allowed. Use HTTPS.");
    }

    [TestMethod]
    public void ShouldThrowArgumentExceptionForMalformedUrl()
    {
        var configuration = new Configuration();

        Assert.ThrowsExactly<ArgumentException>(() => configuration.BasePath = "malformed:url");
    }

    [TestMethod]
    public void ShouldAcceptHttpsBasePath()
    {
        // given
        var givenBasePath = "https://api.infobip.com";

        // when
        var configuration = new Configuration { BasePath = givenBasePath };

        // then
        Assert.AreEqual(givenBasePath, configuration.BasePath);
    }

    [TestMethod]
    public void ShouldAcceptPersonalizedHttpsBasePath()
    {
        // given
        var givenBasePath = "https://abcdef.api.infobip.com";

        // when
        var configuration = new Configuration { BasePath = givenBasePath };

        // then
        Assert.AreEqual(givenBasePath, configuration.BasePath);
    }

    [TestMethod]
    public void ShouldAutomaticallyAddHttpsSchemeWhenNoSchemeProvided()
    {
        // given
        var givenBasePath = "api.infobip.com";

        // when
        var configuration = new Configuration { BasePath = givenBasePath };

        // then
        Assert.AreEqual("https://api.infobip.com", configuration.BasePath);
    }

    [TestMethod]
    public void ShouldAddHttpsSchemeForProtocolRelativeUrl()
    {
        // given
        var givenBasePath = "//api.infobip.com";

        // when
        var configuration = new Configuration { BasePath = givenBasePath };

        // then
        Assert.AreEqual("https://api.infobip.com", configuration.BasePath);
    }

    [TestMethod]
    public void ShouldTrimWhitespaceFromBasePath()
    {
        // given
        var givenBasePath = "  https://api.infobip.com  ";

        // when
        var configuration = new Configuration { BasePath = givenBasePath };

        // then
        Assert.AreEqual("https://api.infobip.com", configuration.BasePath);
    }

    [TestMethod]
    public void ShouldAllowHttpSchemeForLocalhost()
    {
        // given
        var givenBasePath = "http://localhost:8080";

        // when
        var configuration = new Configuration { BasePath = givenBasePath };

        // then
        Assert.AreEqual(givenBasePath, configuration.BasePath);
    }

    [TestMethod]
    public void ShouldAllowHttpSchemeFor127001()
    {
        // given
        var givenBasePath = "http://127.0.0.1:9090";

        // when
        var configuration = new Configuration { BasePath = givenBasePath };

        // then
        Assert.AreEqual(givenBasePath, configuration.BasePath);
    }
}