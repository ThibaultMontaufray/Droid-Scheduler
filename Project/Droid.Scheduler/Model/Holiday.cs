
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Droid.Scheduler.Core
{
    public class Holiday
    {
        #region Attributes
        public DateTime Date;
        public string Name;
        public string LocalName;
        public string Region;
        public bool IsOpenDay;
        public string Calendar;
        #endregion

        #region Method public
        public int CompareTo(object obj)
        {
            if (obj is Holiday)
            {
                Holiday h = (Holiday)obj;
                return this.Date.CompareTo(h.Date);
            }
            throw new ArgumentException("Object is not a holiday");
        }
        #endregion
    }
}
