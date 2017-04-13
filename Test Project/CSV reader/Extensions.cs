using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader
{
    /// <summary>
    /// extensions for common types
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// convert a string value to provided type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ToType(this string value, Type type)
        {
            return Convert.ChangeType(value, type);
        }
    }
}
