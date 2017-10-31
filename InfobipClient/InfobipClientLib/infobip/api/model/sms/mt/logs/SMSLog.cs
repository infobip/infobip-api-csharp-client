using System.Collections.Generic;
using InfobipClient.infobip.api.model;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSLog
    {
        [JsonProperty("doneAt")]
        public DateTimeOffset DoneAt { get; set; }

        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("mccMnc")]
        public string MccMnc { get; set; }

        [JsonProperty("smsCount")]
        public int? SmsCount { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("sentAt")]
        public DateTimeOffset SentAt { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as SMSLog;
            return thisClass != null &&
                EqualityComparer<DateTimeOffset>.Default.Equals(DoneAt, thisClass.DoneAt) &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<string>.Default.Equals(MccMnc, thisClass.MccMnc) &&
                EqualityComparer<int?>.Default.Equals(SmsCount, thisClass.SmsCount) &&
                EqualityComparer<Price>.Default.Equals(Price, thisClass.Price) &&
                EqualityComparer<string>.Default.Equals(MessageId, thisClass.MessageId) &&
                EqualityComparer<string>.Default.Equals(From, thisClass.From) &&
                EqualityComparer<string>.Default.Equals(To, thisClass.To) &&
                EqualityComparer<string>.Default.Equals(Text, thisClass.Text) &&
                EqualityComparer<DateTimeOffset>.Default.Equals(SentAt, thisClass.SentAt) &&
                EqualityComparer<Error>.Default.Equals(Error, thisClass.Error) &&
                EqualityComparer<Status>.Default.Equals(Status, thisClass.Status);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<DateTimeOffset>.Default.GetHashCode(DoneAt);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(MccMnc);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(SmsCount);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Price>.Default.GetHashCode(Price);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(MessageId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(From);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(To);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 +  EqualityComparer<DateTimeOffset>.Default.GetHashCode(SentAt);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Error>.Default.GetHashCode(Error);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Status>.Default.GetHashCode(Status);
            return hashCode;
        }
    }
}