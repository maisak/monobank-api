using System;

namespace Monobank.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToUnixTime(this DateTime date)
        {
            return (int) date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
