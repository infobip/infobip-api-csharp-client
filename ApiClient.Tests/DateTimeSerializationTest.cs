using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ApiClient.Tests
{
    [TestClass]
    public class DateTimeSerializationTest
    {
        internal static readonly DateTimeOffset[] DateTimeValues = new[] {
            new DateTimeOffset(2035, 8, 18, 12, 8, 42, 777, new TimeSpan(0, 0, 0)),
            new DateTimeOffset(2035, 8, 18, 13, 8, 42, 777, new TimeSpan(1, 0, 0)),
            new DateTimeOffset(2035, 8, 18, 11, 8, 42, 777, new TimeSpan(-1, 0, 0)),
            new DateTimeOffset(2035, 8, 18, 17, 8, 42, 777, new TimeSpan(5, 0, 0)),
            new DateTimeOffset(2035, 8, 18, 7, 8, 42, 777, new TimeSpan(-5, 0, 0)),
            new DateTimeOffset(2035, 8, 18, 13, 38, 42, 777, new TimeSpan(1, 30, 0)),
            new DateTimeOffset(2035, 8, 18, 10, 38, 42, 777, new TimeSpan(-1, -30, 0)),
            new DateTimeOffset(2035, 8, 18, 17, 38, 42, 777, new TimeSpan(5, 30, 0)),
            new DateTimeOffset(2035, 8, 18, 6, 38, 42, 777, new TimeSpan(-5, -30, 0))
        };

        const string EXPECTED_DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffzzzz";
        const string EXPECTED_DATE_FORMAT = "yyyy-MM-dd";
        const string EXPECTED_DATE = "2035-08-18";
        const long EXPECTED_TICKS = 642066048000000000;

        [DataRow("2035-08-18T12:08:42.777+0000", 0)]
        [DataRow("2035-08-18T13:08:42.777+0100", 1)]
        [DataRow("2035-08-18T11:08:42.777-0100", 2)]
        [DataRow("2035-08-18T17:08:42.777+0500", 3)]
        [DataRow("2035-08-18T07:08:42.777-0500", 4)]
        [DataRow("2035-08-18T13:38:42.777+0130", 5)]
        [DataRow("2035-08-18T10:38:42.777-0130", 6)]
        [DataRow("2035-08-18T17:38:42.777+0530", 7)]
        [DataRow("2035-08-18T06:38:42.777-0530", 8)]
        [DataTestMethod]
        public void DateTimeFormatDeserializationTest(string dateString, int dateValueIndex)
        {
            // ARRANGE
            DateTimeOffset expected = DateTimeValues[dateValueIndex];

            string jsonDate = $"{{\"date\":\"{dateString}\"}}";

            // ACT
            TestObject actual = JsonConvert.DeserializeObject<TestObject>(jsonDate);

            // ASSERT
            Assert.AreEqual(expected, actual.Date);
            Assert.AreEqual(expected.Ticks, actual.Date.Ticks);
            Assert.AreEqual(expected.Offset, actual.Date.Offset);
            Assert.AreEqual(EXPECTED_DATE, actual.Date.ToString(EXPECTED_DATE_FORMAT));
            Assert.AreEqual(EXPECTED_TICKS, actual.Date.Date.Ticks);
            Assert.AreEqual(expected.ToString(), actual.Date.ToString());
            Assert.AreEqual(expected.ToString(EXPECTED_DATETIME_FORMAT), actual.Date.ToString(EXPECTED_DATETIME_FORMAT));
        }

        [DataRow(0, "2035-08-18T12:08:42.777+00:00")]
        [DataRow(1, "2035-08-18T13:08:42.777+01:00")]
        [DataRow(2, "2035-08-18T11:08:42.777-01:00")]
        [DataRow(3, "2035-08-18T17:08:42.777+05:00")]
        [DataRow(4, "2035-08-18T07:08:42.777-05:00")]
        [DataRow(5, "2035-08-18T13:38:42.777+01:30")]
        [DataRow(6, "2035-08-18T10:38:42.777-01:30")]
        [DataRow(7, "2035-08-18T17:38:42.777+05:30")]
        [DataRow(8, "2035-08-18T06:38:42.777-05:30")]
        [DataTestMethod]
        public void DateTimeFormatSerializationTest(int dateValueIndex, string expected)
        {
            // ARRANGE
            DateTimeOffset initialDate = DateTimeValues[dateValueIndex];

            // ACT
            string actual = JsonConvert.SerializeObject(initialDate);

            // ASSERT
            Assert.AreEqual($"\"{expected}\"", actual);
        }

        public class TestObject
        {
            public DateTimeOffset Date { get; set; }
        }
    }
}
