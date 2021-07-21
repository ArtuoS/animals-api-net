using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Common.Tools
{
    public static class BusinessValidator
    {
        public static bool IsValidId(this long id)
            => id > 0;

        public static bool IsValidString(this string str)
            => string.IsNullOrWhiteSpace(str);
    }
}
