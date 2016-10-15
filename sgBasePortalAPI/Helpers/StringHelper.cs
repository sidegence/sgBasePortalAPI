using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgBasePortalAPI.Helpers
{
    internal static class StringHelper
    {
        internal static string ClearString(string value)
        {
            return
                string.IsNullOrEmpty(value) ? "" : value.Replace("\"", "").Replace("'", "").Trim();
        }

        internal static float ClearFloat(string value)
        {
            return
                string.IsNullOrEmpty(value) ? 0 : float.Parse(value.Replace(".", "").Replace("€", "").Replace(",", ".").Trim(), CultureInfo.InvariantCulture);
        }

        internal static DateTime? ClearDate(string value)
        {
            return
                string.IsNullOrEmpty(value) ? (DateTime?) null : DateTime.Parse(RevertDate(value.Trim()), CultureInfo.InvariantCulture);
        }

        internal static string RevertDate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return
                    string.Empty;
            }

            string[]
                parts = value.Split('-');

            return
                parts[2] + "-" + parts[1] + "-" + parts[0];
        }
    }
}
