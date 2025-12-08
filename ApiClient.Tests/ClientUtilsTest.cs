using System.Runtime.Serialization;
using Infobip.Api.Client;

namespace ApiClient.Tests;

[TestClass]
public class ClientUtilsTest
{

    private enum TestEnum
    {
        [EnumMember(Value = "OK")] Ok = 1,

        [EnumMember(Value = "ALSO_OK")] AlsoOk = 2,
    }

    [TestMethod]
    public void ParameterToStringTest()
    {
        var dateTime = new DateTime(2025, 12, 1, 15, 30, 45, DateTimeKind.Utc);
        var dateTimeOffset = new DateTimeOffset(dateTime);
        var booleanValue = true;
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        var enumValue = TestEnum.AlsoOk;
        var randomNumber = 5;
        var randomString = "axT3!er_hOp7&";

        Assert.AreEqual("2025-12-01T15:30:45.000+00:00", ClientUtils.ParameterToString(dateTime));
        Assert.AreEqual( "2025-12-01T15:30:45.000+00:00", ClientUtils.ParameterToString(dateTimeOffset));
        Assert.AreEqual("true", ClientUtils.ParameterToString(booleanValue));
        Assert.AreEqual("1,2,3,4,5,6,7,8,9,10,11,12", ClientUtils.ParameterToString(list));
        Assert.AreEqual("ALSO_OK", ClientUtils.ParameterToString(enumValue));
        Assert.AreEqual("5", ClientUtils.ParameterToString(randomNumber));
        Assert.AreEqual("axT3!er_hOp7&", ClientUtils.ParameterToString(randomString));
    }
}