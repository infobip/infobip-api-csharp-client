using System.Runtime.Serialization;
using System.Text.Json;
using Infobip.Api.Client;

namespace ApiClient.Tests;

[TestClass]
public class JsonStringEnumMemberConverterTests
{
    public enum TestEnum
    {
        [EnumMember(Value = "VALUE_A")]
        A = 1,
        [EnumMember(Value = "VALUE_B")]
        B = 2,
        C = 3
    }
    
    private JsonSerializerOptions _options;
    
    [TestInitialize]
    public void Setup()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new JsonStringEnumMemberConverter<TestEnum>());
    }
    
    [TestMethod]
    [DataRow("\"VALUE_A\"", TestEnum.A)]
    [DataRow("\"VALUE_B\"", TestEnum.B)]
    [DataRow("\"C\"", TestEnum.C)]
    public void DeserializesProperValues(string json, TestEnum expected)
    {
        var actual = JsonSerializer.Deserialize<TestEnum>(json, _options);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(TestEnum.A, "\"VALUE_A\"")]
    [DataRow(TestEnum.B, "\"VALUE_B\"")]
    [DataRow(TestEnum.C, "\"C\"")]
    public void SerializesProperValues(TestEnum value, string expectedJson)
    {
        var actualJson = JsonSerializer.Serialize(value, _options);
        Assert.AreEqual(expectedJson, actualJson);
    }

    [TestMethod]
    public void DeserializesIgnoresCase()
    {
        var actual = JsonSerializer.Deserialize<TestEnum>("\"value_b\"", _options);
        Assert.AreEqual(TestEnum.B, actual);
    }

    [TestMethod]
    public void DeserializesThrowsOnUnknownValue()
    {
        Assert.ThrowsExactly<JsonException>(() =>
        {
            JsonSerializer.Deserialize<TestEnum>("\"does_not_exist\"", _options);
        });
    }

    [TestMethod]
    public void DeserializesThrowsOnNonString()
    {
        Assert.ThrowsExactly<JsonException>(() =>
        {
            JsonSerializer.Deserialize<TestEnum>("123", _options);
        });
    }
}