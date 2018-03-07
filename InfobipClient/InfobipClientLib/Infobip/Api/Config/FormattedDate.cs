using System;
using System.Globalization;

namespace Infobip.Api.Config
{
    public class FormattedDate
    {
        public DateTimeOffset date { get; }

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
