using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public static class InvoiceRules
    {
        public static bool ExistsForCurrentMonth<T>(
            IEnumerable<T> invoices,
            DateTime now,
            Func<T, int> getMonth,  
            Func<T, int> getYear)   
        {
            int m = now.Month;
            int y = now.Year;
            return invoices.Any(i => getMonth(i) == m && getYear(i) == y);
        }
    }
}
