using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Droid.Scheduler
{
    public class HolidayCalculator : ICloneable
    {
        #region Attributes
        private List<Holiday> _orderedholidays;
        private XmlDocument _xholidays;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private DateTime _tmpDate;
        private readonly CultureInfo CULTINFOHIJRI = CultureInfo.CreateSpecificCulture("ar-SA");
        private readonly CultureInfo CULTINFOGREGORIAN = CultureInfo.CreateSpecificCulture("fr-FR");
        #endregion

        #region Properties
        /// <summary>
        /// The holidays occuring after StartDate listed in
        /// chronological order;
        /// </summary>
        public List<Holiday> Orderedholidays
        {
            get { return this._orderedholidays; }
        }
        public DateTime StartDate
        {
            get { return _dateStart; }
        }
        public DateTime EndDate
        {
            get { return _dateEnd; }
        }
        #endregion

        #region Constructor
        public HolidayCalculator()
        {
            this._dateStart = new DateTime(DateTime.Now.Year, 1, 1);
            this._dateEnd = new DateTime(DateTime.Now.Year, 12, 31);
            _orderedholidays = new List<Holiday>();
            _xholidays = new XmlDocument();
        }
        /// <summary>
        /// Returns all of the holidays occuring in the year following the
        /// date that is passed in the constructor. holidays are defined in
        /// an XML file.
        /// </summary>

        /// <param name="startDate">The starting date for
        /// returning holidays. All holidays for one year after this date
        /// are returned.</param>
        /// <param name="xmlStream">The path to the XML file
        /// that contains the Holiday definitions.</param>
        public HolidayCalculator(DateTime startDate, DateTime endDate, string xmlStr)
        {
            this._dateStart = startDate;
            this._dateEnd = endDate;
            _orderedholidays = new List<Holiday>();
            _xholidays = new XmlDocument();
            _xholidays.LoadXml(xmlStr);
            this.processXML();
        }
        public HolidayCalculator(string xmlStr)
        {
            this._dateStart = new DateTime(DateTime.Now.Year, 1, 1);
            this._dateEnd = new DateTime(DateTime.Now.Year, 12, 31);
            _orderedholidays = new List<Holiday>();
            _xholidays = new XmlDocument();
            _xholidays.LoadXml(xmlStr);
            this.processXML();
        }
        #endregion

        #region Methods public
        public object Clone()
        {
            HolidayCalculator hc = new HolidayCalculator();
            hc._orderedholidays = _orderedholidays;
            hc._xholidays = _xholidays;
            hc._dateStart = _dateStart;
            return hc;
        }
        public bool Contains(DateTime dt)
        {
            foreach (Holiday h in _orderedholidays)
            {
                if (h.Date.Equals(dt)) return true;
            }
            return false;
        }
        public bool IsNonWorkingDay(DateTime dt, string region = null)
        {
            if (_orderedholidays != null)
            {
                foreach (Holiday h in _orderedholidays)
                {
                    if (h.Date.Equals(dt))
                    {
                        if (!string.IsNullOrEmpty(region) && !region.ToLower().Equals("all regions") && !h.Region.Contains(region)) return false;
                        return !h.IsOpenDay;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public static int HijriMonthStringToInt(string month)
        {
            switch (month)
            {
                case "Muharram":
                    return 1;
                case "Safar":
                    return 2;
                case "Rabi Al-Awwal":
                    return 3;
                case "Rabi Al-Akhar":
                    return 4;
                case "Jumada Al-Awwal":
                    return 5;
                case "Jumada Al-Akhirah":
                    return 6;
                case "Rajab":
                    return 7;
                case "Shaban":
                    return 8;
                case "Ramadan":
                    return 9;
                case "Shawwal":
                    return 10;
                case "Dhul-Qadah":
                    return 11;
                case "Dhul-Hijjah":
                    return 12;
                default:
                    return 0;
            }
        }
        public static string HijriMonthIntToStrin(int month)
        {
            switch (month)
            {
                case 1:
                    return "Muharram";
                case 2:
                    return "Safar";
                case 3:
                    return "Rabi Al-Awwal";
                case 4:
                    return "Rabi Al-Akhar";
                case 5:
                    return "Jumada Al-Awwal";
                case 6:
                    return "Jumada Al-Akhirah";
                case 7:
                    return "Rajab";
                case 8:
                    return "Shaban";
                case 9:
                    return "Ramadan";
                case 10:
                    return "Shawwal";
                case 11:
                    return "Dhul-Qadah";
                case 12:
                    return "Dhul-Hijjah";
                default:
                    return string.Empty;
            }
        }
        public static HolidayCalculator GetCalendar(string calendarCountry)
        {
            switch (calendarCountry)
            {
                case "france":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_france);
                case "india":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_india);
                case "ireland":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_irland);
                case "canada":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_canada);
                case "germany":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_germany);
                case "japan":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_japan);
                case "russia":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_russia);
                case "togo":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_togo);
                case "great britain":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_united_kingdom);
                case "usa":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_united_state);
                case "mali":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_mali);
                case "kenya":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_kenya);
                case "guine":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_guine);
                case "republique centrafrique":
                    return new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), Resources.holidays_republique_centrafrique);
                default:
                    return new HolidayCalculator();
            }
        }
        #endregion

        #region Methods Private
        /// <summary>
		/// Loops through the holidays defined in the XML configuration file, and adds the next occurance into the Orderholidays collection if it occurs within one year.
		/// </summary>
		private void processXML()
        {
            foreach (XmlNode n in _xholidays.SelectNodes("/notablesdays/notableday"))
            {
                for (int i = 0; i <= (_dateEnd.Year - _dateStart.Year); i++)
                {
                    Holiday h = this.processNode(n, _dateStart.AddYears(i));
                    if (h != null && h.Date.Year > 1) this._orderedholidays.Add(h);
                }
            }
            // TODO Fix the sort
            //_orderedholidays.Sort(x => x.Date);
        }
        /// <summary>
        /// Processes a Holiday node from the XML configuration file.
        /// </summary>
        /// <param name="n">The Holdiay node to process.</param>
        /// <returns></returns>
        private Holiday processNode(XmlNode n, DateTime date)
        {
            try
            {
                if (n != null)
                {
                    Holiday h = new Holiday();
                    h.Name = n.Attributes["name"].Value.ToString();
                    h.IsOpenDay = n.Attributes["openday"].Value.ToString().ToLower().Equals("true") ? true : false;
                    ArrayList childNodes = new ArrayList();
                    foreach (XmlNode node in n.ChildNodes)
                    {
                        switch (node.Name.ToLower())
                        {
                            case "calendar":
                                h.Calendar = node.InnerText.ToLower();
                                break;
                            case "localname":
                                h.LocalName = node.Attributes["value"].Value.ToString();
                                break;
                            case "region":
                                h.Region = node.Attributes["value"].Value.ToString();
                                break;
                            case "weekofmonth":
                                h.Date = this.getDateBymonthWeekWeekday(Int32.Parse(n.SelectSingleNode("./month").InnerXml.ToString()),
                                                                        Int32.Parse(n.SelectSingleNode("./weekofmonth").InnerXml.ToString()),
                                                                        Int32.Parse(n.SelectSingleNode("./dayofweek").InnerXml.ToString()),
                                                                        date);
                                break;
                            case "weekdayinmonth":
                                h.Date = this.getDateByWeekDayInMonth(Int32.Parse(n.SelectSingleNode("./weekdayinmonth/weekday").InnerXml.ToString()),
                                                                        Int32.Parse(n.SelectSingleNode("./weekdayinmonth/weekdaynum").InnerXml.ToString()),
                                                                        Int32.Parse(n.SelectSingleNode("./weekdayinmonth/month").InnerXml.ToString()),
                                                                        date);
                                break;
                            case "dayofweekonorafter":
                                int dowa = Int32.Parse(n.SelectSingleNode("./dayofweekonorafter/dayofweek").InnerXml.ToString());
                                if (dowa > 6 || dowa < 0) throw new Exception("DOWA is greater than 6");
                                h.Date = this.getDateByweekdayonorafter(dowa,
                                                                        Int32.Parse(n.SelectSingleNode("./dayofweekonorafter/month").InnerXml.ToString()),
                                                                        Int32.Parse(n.SelectSingleNode("./dayofweekonorafter/day").InnerXml.ToString()),
                                                                        date);
                                break;
                            case "dayofweekonorbefore":
                                int dowb = Int32.Parse(n.SelectSingleNode("./dayofweekonorbefore/dayofweek").InnerXml.ToString());
                                if (dowb > 6 || dowb < 0) throw new Exception("DOWB is greater than 6");
                                h.Date = this.getDateByweekdayonorbefore(dowb,
                                                                        Int32.Parse(n.SelectSingleNode("./dayofweekonorbefore/month").InnerXml.ToString()),
                                                                        Int32.Parse(n.SelectSingleNode("./dayofweekonorbefore/day").InnerXml.ToString()),
                                                                        date);
                                break;
                            case "weekdayonorafter":
                                _tmpDate = new DateTime(date.Year,
                                                  Int32.Parse(n.SelectSingleNode("./weekdayonorafter/month").InnerXml.ToString()),
                                                  Int32.Parse(n.SelectSingleNode("./weekdayonorafter/day").InnerXml.ToString()));

                                if (_tmpDate < date) _tmpDate = _tmpDate.AddYears(1);
                                while (_tmpDate.DayOfWeek.Equals(DayOfWeek.Saturday) || _tmpDate.DayOfWeek.Equals(DayOfWeek.Sunday))
                                {
                                    _tmpDate = _tmpDate.AddDays(1);
                                }
                                h.Date = _tmpDate;
                                break;
                            case "lastfullweekofmonth":
                                int weekday = Int32.Parse(n.SelectSingleNode("./lastfullweekofmonth/dayofweek").InnerXml.ToString());
                                _tmpDate = this.getDateBymonthWeekWeekday(Int32.Parse(n.SelectSingleNode("./lastfullweekofmonth/month").InnerXml.ToString()), 5, weekday, date);
                                if (_tmpDate.AddDays(6 - weekday).Month == Int32.Parse(n.SelectSingleNode("./lastfullweekofmonth/month").InnerXml.ToString())) h.Date = _tmpDate;
                                else h.Date = _tmpDate.AddDays(-7);
                                break;
                            case "daysafterholiday":
                                XmlNode basisdaysafterholiday = _xholidays.SelectSingleNode("/holidays/holiday[@name='" + n.SelectSingleNode("./daysafterholiday").Attributes["holiday"].Value.ToString() + "']");
                                Holiday bholidayd = this.processNode(basisdaysafterholiday, date);
                                int days = Int32.Parse(n.SelectSingleNode("./daysafterholiday/days").InnerXml.ToString());
                                if (bholidayd != null) h.Date = bholidayd.Date.AddDays(days);
                                break;
                            case "monthsafterholiday":
                                XmlNode basismonthsafterholiday = _xholidays.SelectSingleNode("/holidays/holiday[@name='" + n.SelectSingleNode("./monthsafterholiday").Attributes["holiday"].Value.ToString() + "']");
                                Holiday bholidaym = this.processNode(basismonthsafterholiday, date);
                                int months = Int32.Parse(n.SelectSingleNode("./monthsafterholiday/days").InnerXml.ToString());
                                if (bholidaym != null) h.Date = bholidaym.Date.AddMonths(months);
                                break;
                            case "easter":
                                h.Date = this.easter(date);
                                break;
                            case "month":
                                _tmpDate = getDateFromCalendar(date.Year, n.SelectSingleNode("./month").InnerXml.ToString(), n.SelectSingleNode("./day").InnerXml.ToString(), h.Calendar);
                                if (_tmpDate < date)
                                {
                                    _tmpDate = _tmpDate.AddYears(1);
                                }
                                if (childNodes.Contains("everyxyears"))
                                {
                                    int yearMult = Int32.Parse(n.SelectSingleNode("./everyxyears").InnerXml.ToString());
                                    int startyear = Int32.Parse(n.SelectSingleNode("./startyear").InnerXml.ToString());
                                    if (((_tmpDate.Year - startyear) % yearMult) == 0)
                                    {
                                        h.Date = _tmpDate;
                                    }
                                }
                                else
                                {
                                    h.Date = _tmpDate;
                                }
                                break;
                        }
                    }
                    return h;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return null;
        }
        /// <summary>
        /// Determines the next occurance of Easter (western Christian).
        /// </summary>
        /// <returns></returns>
        private DateTime easter(DateTime date)
        {
            DateTime workDate = this.getFirstdayOfmonth(date);
            int y = workDate.Year;
            if (workDate.Month > 4) y = y + 1;
            return this.easter(y, date);
        }
        /// <summary>
        /// Determines the occurance of Easter in the given year. If the result comes before StartDate, recalculates for the following year.
        /// </summary>
        /// <param name="year">year to check</param>
        /// <returns></returns>
        private DateTime easter(int year, DateTime date)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int eastermonth = (h + l - 7 * m + 114) / 31;
            int p = (h + l - 7 * m + 114) % 31;
            int easterday = p + 1;
            DateTime est = new DateTime(year, eastermonth, easterday);
            if (est < date) return this.easter(year + 1, date);
            else return new DateTime(year, eastermonth, easterday);
        }
        /// <summary>
        /// Gets the next occurance of a weekday after a given month and day in the year after StartDate.
        /// </summary>
        /// <param name="weekday">The day of the week (0=Sunday).</param>
        /// <param name="m">The month</param>
        /// <param name="d">day</param>
        /// <returns></returns>
        private DateTime getDateByweekdayonorafter(int weekday, int m, int d, DateTime startDate)
        {
            DateTime workDate = this.getFirstdayOfmonth(startDate);
            while (workDate.Month != m)
            {
                workDate = workDate.AddMonths(1);
            }
            workDate = workDate.AddDays(d - 1);

            while (weekday != (int)(workDate.DayOfWeek))
            {
                workDate = workDate.AddDays(1);
            }

            //It's possible the resulting date is before
            //the specified starting date.
            //If so we'll calculate again for the next year.
            if (workDate < startDate)
                return this.getDateByweekdayonorafter(weekday, m, d, startDate.AddYears(1));
            else
                return workDate;
        }
        /// <summary>
        /// Gets the previews occurance of a weekday before a given month and day in the year before StartDate.
        /// </summary>
        /// <param name="weekday">The day of the week (0=Sunday).</param>
        /// <param name="m">The month</param>
        /// <param name="d">day</param>
        /// <returns></returns>
        private DateTime getDateByweekdayonorbefore(int weekday, int m, int d, DateTime startDate)
        {
            DateTime workDate = this.getFirstdayOfmonth(startDate);
            while (workDate.Month != m)
            {
                workDate = workDate.AddMonths(1);
            }
            workDate = workDate.AddDays(d - 1);

            while (weekday != (int)(workDate.DayOfWeek))
            {
                workDate = workDate.AddDays(-1);
            }

            if (workDate < startDate)
                return this.getDateByweekdayonorbefore(weekday, m, d, startDate.AddYears(-1));
            else
                return workDate;
        }
        /// <summary>
        /// Gets the n'th instance of a day-of-week
        /// in the given month after StartDate
        /// </summary>
        /// <param name="month">The month the
        /// Holiday falls on.</param>

        /// <param name="week">The instance of
        /// weekday that the holiday
        /// falls on (5=last instance in the month).</param>
        /// <param name="weekday">The day of
        /// the week that the Holiday falls
        /// on.</param>
        /// <returns></returns>
        private DateTime getDateBymonthWeekWeekday(int month, int week, int weekday, DateTime startDate)
        {
            DateTime workDate = this.getFirstdayOfmonth(startDate);
            while (workDate.Month != month)
            {
                workDate = workDate.AddMonths(1);
            }
            while ((int)workDate.DayOfWeek != weekday)
            {
                workDate = workDate.AddDays(1);
            }

            DateTime result;
            if (week == 1)
            {
                result = workDate;
            }
            else
            {
                int adddays = (week * 7) - 7;
                int day = workDate.Day + adddays;
                if (day > DateTime.DaysInMonth(workDate.Year, workDate.Month))
                {
                    day = day - 7;
                }
                result = new DateTime(workDate.Year, workDate.Month, day);
            }

            //It's possible the resulting date is
            //before the specified starting date.
            //If so we'll calculate again for the next year.
            if (result >= startDate)
                return result;
            else
                return this.getDateBymonthWeekWeekday(month, week, weekday, startDate.AddYears(1));
        }
        /// <summary>
        /// Returns the first day of the month for the specified date.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DateTime getFirstdayOfmonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
        /// <summary>
        /// Get the week day in month with your counter
        /// </summary>
        /// <param name="weekDay">day in the week (0 = sunday)</param>
        /// <param name="weeknum">number of the week ex 2 for the second monday, -1 for the last monday in the month</param>
        /// <param name="month">month to check</param>
        /// <param name="startDate">date to stat (to have the month, year)</param>
        /// <returns>your awesome date \o/</returns>
        private DateTime getDateByWeekDayInMonth(int weekDay, int weeknum, int month, DateTime startDate)
        {
            int count = 0;
            DateTime workdate;
            if (weeknum > 0)
            {
                for (int i = 1; i <= DateTime.DaysInMonth(startDate.Year, month); i++)
                {
                    workdate = new DateTime(startDate.Year, month, i);
                    if (weekDay == (int)workdate.DayOfWeek)
                    {
                        count++;
                        if (count == weeknum) return workdate;
                    }
                }
            }
            else
            {
                for (int i = DateTime.DaysInMonth(startDate.Year, month); i > 0; i--)
                {
                    workdate = new DateTime(startDate.Year, month, i);
                    if (weekDay == (int)workdate.DayOfWeek)
                    {
                        count--;
                        if (count == weeknum) return workdate;
                    }
                }
            }
            return DateTime.MinValue;
        }
        private DateTime getDateFromCalendar(int year, string month, string day, string calendar)
        {
            DateTime date = new DateTime(year, Int32.Parse(month), Int32.Parse(day));
            if (calendar == null) { calendar = string.Empty;}
            switch (calendar.ToLower())
            {
                case "hijri":
                    CalendarConvert cc = new CalendarConvert();
                    return cc.HijriToGreg(string.Format("{0}/{1}/{2}", date.ToString("yyyy", CULTINFOHIJRI), month, day));
                case "julian":
                default:
                    return date;
            }
        }
        #endregion
    }
}
