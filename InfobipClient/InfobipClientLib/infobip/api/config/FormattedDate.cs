using System;
using System.Globalization;

namespace InfobipClient.infobip.api.config
{
    public class FormattedDate
    {
        private readonly DateTimeOffset date;

        public FormattedDate(DateTimeOffset date)
        {
            this.date = date;
        }

        public override string ToString()
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture);
        }
    }
}
