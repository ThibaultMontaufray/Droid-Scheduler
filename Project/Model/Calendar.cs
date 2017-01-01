using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Droid_scheduler
{
    public static class Calendar
    {
        /// <summary>
        /// Get the Week number of the year
        /// (In the range 1..53)
        /// This conforms to ISO 8601 specification for week number.
        /// </summary>
        /// <param name="date">date to check</param>
        /// <returns>Week of year</returns>
        public static int WeekOfYear(this DateTime date)
        {
            // Offsets to move the day of the year on a week, allowing for the current year Jan 1st day of week, and the Sun/Mon week start difference between ISO 8601 and Microsoft
            int[] moveByDays = { 6, 7, 8, 9, 10, 4, 5 };
            DateTime startOfYear = new DateTime(date.Year, 1, 1);
            DateTime endOfYear = new DateTime(date.Year, 12, 31);
            // ISO 8601 weeks start with Monday The first week of a year includes the first Thursday This means that Jan 1st could be in week 51, 52, or 53 of the previous year...
            int numberDays = date.Subtract(startOfYear).Days + moveByDays[(int)startOfYear.DayOfWeek];
            int weekNumber = numberDays / 7;
            switch (weekNumber)
            {
                case 0:
                    // Before start of first week of this year - in last week of previous year
                    weekNumber = WeekOfYear(startOfYear.AddDays(-1));
                    break;
                case 53:
                    // In first week of next year.
                    if (endOfYear.DayOfWeek < DayOfWeek.Thursday) weekNumber = 1;
                    break;
            }
            return weekNumber;
        }
        /// <summary>
        /// Calculate the date for an open day requested
        /// </summary>
        /// <param name="holidays">holidays calendar for your region</param>
        /// <param name="openDay">open day number requested</param>
        /// <param name="month">month of your open day</param>
        /// <param name="year">year of you open day</param>
        /// <returns>the date of you requested open day</returns>
        public static DateTime GetDayOfOpenNum(HolidayCalculator holidays, int openDay, int month, int year)
        {
            if (month == 0 || month > 12) return DateTime.MinValue;
            DateTime checkDate;
            int count = 0;
            if (openDay > 0)
            {
                for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
                {
                    checkDate = new DateTime(year, month, i);
                    if (checkDate.DayOfWeek != DayOfWeek.Saturday && checkDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (!holidays.IsNonWorkingDay(checkDate))
                        {
                            count++;
                            if (count == openDay) return new DateTime(year, month, checkDate.Day);
                        }
                    }
                }
            }
            else
            {
                DateTime startDate = (new DateTime(year, month, 1)).AddMonths(-1);
                for (int i = DateTime.DaysInMonth(startDate.Year, startDate.Month); i > 0; i--)
                {
                    checkDate = new DateTime(startDate.Year, startDate.Month, i);
                    if (checkDate.DayOfWeek != DayOfWeek.Saturday && checkDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (!holidays.IsNonWorkingDay(checkDate))
                        {
                            count++;
                            if (count == openDay * -1) return new DateTime(checkDate.Year, checkDate.Month, checkDate.Day);
                        }
                    }
                }
            }
            return DateTime.MinValue;
        }
        /// <summary>
        /// Calculate the open day number for a given date
        /// </summary>
        /// <param name="holidays">holidays calendar for your region</param>
        /// <param name="dt">date to check</param>
        /// <returns>open day number</returns>
        public static int GetNumOfOpenDay(HolidayCalculator holidays, DateTime dt)
        {
            DateTime checkDate;
            int count = 0;
            for (int i = 1; i < DateTime.DaysInMonth(dt.Year, dt.Month); i++)
            {
                checkDate = new DateTime(dt.Year, dt.Month, i);
                if (checkDate.DayOfWeek != DayOfWeek.Saturday && checkDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (!holidays.IsNonWorkingDay(checkDate))
                    {
                        count++;
                    }
                }
                if (dt.Equals(checkDate)) break;
            }
            return count;
        }
        /// <summary>
        /// Calculate if the given day is working or not
        /// </summary>
        /// <param name="holidays">holidays calendar for your region</param>
        /// <param name="dt">date to check</param>
        /// <returns>true if the day is working day</returns>
        public static int IsOpenDay(HolidayCalculator holidays, DateTime dt)
        {
            // first holidays 'cause its more important
            if (holidays.IsNonWorkingDay(dt)) return 2;
            if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) return 1;
            return 0;
        }
        /// <summary>
        /// Maximum number of open day in a given month depending of your holidays calendar
        /// </summary>
        /// <param name="holidays">holidays calendar for your region</param>
        /// <param name="month">month to check</param>
        /// <param name="Year">year to check</param>
        /// <returns>number of yourking day depending of your calendar</returns>
        public static int GetMaxNbOpenDay(HolidayCalculator holidays, int month, int Year)
        {
            return 30;
        }
        /// <summary>
        /// Give the age of a personn (in years)
        /// </summary>
        /// <param name="dateOfBirth">birth day</param>
        /// <returns>age in years</returns>
        public static int Age(this DateTime dateOfBirth)
        {
            if (DateTime.Today.Month < dateOfBirth.Month || DateTime.Today.Month == dateOfBirth.Month && DateTime.Today.Day < dateOfBirth.Day)
                return DateTime.Today.Year - dateOfBirth.Year - 1;
            else
                return DateTime.Today.Year - dateOfBirth.Year;
        }
        /// <summary>
        /// Check if a date is between two other one
        /// </summary>
        /// <param name="dt">date to check</param>
        /// <param name="startDate">start date</param>
        /// <param name="endDate">end date</param>
        /// <param name="compareTime">compare whith time</param>
        /// <returns>true if date is between two other ones</returns>
        public static Boolean IsBetween(this DateTime dt, DateTime startDate, DateTime endDate, Boolean compareTime = false)
        {
            return compareTime ?
               dt >= startDate && dt <= endDate :
               dt.Date >= startDate.Date && dt.Date <= endDate.Date;
        }
        /// <summary>
        /// Converts a regular DateTime to a RFC822 date string.
        /// </summary>
        /// <returns>The specified date formatted as a RFC822 date string.</returns>
        public static string ToRFC822DateString(this DateTime date)
        {
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            string timeZone = "+" + offset.ToString().PadLeft(2, '0');
            if (offset < 0)
            {
                int i = offset * -1;
                timeZone = "-" + i.ToString().PadLeft(2, '0');
            }
            return date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }
        /// <summary>
        /// Give the name of an integer month in julian calendar
        /// </summary>
        /// <param name="dt">the date you need the month</param>
        /// <returns>the name of the month</returns>
        public static string MonthNameInJulianCalendar(DateTime dt)
        {
            switch (dt.Month)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default : return string.Empty;
            }
        }
    }
}
