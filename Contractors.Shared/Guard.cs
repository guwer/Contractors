using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractors.Shared
{
    public static class Guard
    {
        /// <summary>
        /// Throws ArgumentNullException if passed value is null.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void ThrowIfArgumentIsNull(object value, string name)
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }
    }
}
