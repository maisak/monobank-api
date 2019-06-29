using System;

namespace Monobank.Core.Extensions
{
    public static class Int64Extensions
    {
        public static DateTime ToDateTime(this long seconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds);
        }
    }
}
