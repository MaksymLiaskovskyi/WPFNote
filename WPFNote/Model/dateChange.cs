using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNote.Model
{
    static class dateChange
    {
        static DateTime now = DateTime.Now;
        static DateTime currentDate = DateTime.Now;
        static public DateTime monthChange(bool type)
        {
            if (type)
            {
                currentDate = currentDate.AddMonths(1);
                return currentDate;
            }
            else
            {
                currentDate = currentDate.AddMonths(-1);
                return currentDate;
            }
        }
    }
}
