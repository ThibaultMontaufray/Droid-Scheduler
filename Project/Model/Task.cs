namespace Droid_scheduler
{
    using System;
    using System.Collections.Generic;
    using Droid_Database;

    public class Task
    {
        #region Enum
        public enum CalendarType
        {
            UNKNOW,
            PERSO,
            REFERENCED,
            NOCALENDAR
        }
        public enum TimeUnit
        {
            MILLISECOND,
            SECONDE,
            MINUTE,
            HOUR,
            DAY,
            WEEK,
            MONTH,
            YEAR
        }
        public enum MultiInstanceMode
        {
            ONCE,
            MULTI,
            QUEUED
        }
        public enum ErrorMode
        { 
            NONE,
            ONCE,
            EACH_1_MIN,
            EACH_5_MIN,
            EACH_10_MIN
        }
        #endregion

        #region Attribute
        private string _id;
        private string _name;
        private bool _cyclic;
        private string _programPath;
        
        private DateTime _startDate;
        private DateTime _maxStartDate;
        private List<DateTime> _exceptionWindowStart;
        private List<DateTime> _exceptionWindowEnd;
        private string _calendarPath;
        private CalendarType _calendarType;
        private string _calendarCountry;
        private string _calendarRegions;
        
        private bool _runMonday;
        private bool _runThuesday;
        private bool _runWednesday;
        private bool _runThursday;
        private bool _runFriday;
        private bool _runSaturday;
        private bool _runSunday;
        private bool _runOpenDays;
        private bool _runNonOpenDays;

        private bool _executeOnDelay;
        private int _runSecond;
        private int _runMinute;
        private int _runHour;
        private bool _runHourEnabled;
        private bool _runMinuteEnabled;
        private bool _runSecondEnabled;

        private int _executeInterval;
        private TimeUnit _executeIntervalTimeUnit;
        private List<ExecutionException> _exclusions;
        private ErrorMode _errorMode;
        private MultiInstanceMode _multiInstanceMode;
        private List<int> _runOpenDaysList;
        private List<int> _runDaysList;

        private bool _noMaxStartDate;
        private int _maxRunSecond;
        private int _maxRunMinute;
        private int _maxRunHour;
        private List<object[]> _manualExecution;
        private HolidayCalculator _holidays;
        #endregion

        #region Properties
        public List<int> RunDaysList
        {
            get { return _runDaysList; }
            set { _runDaysList = value; }
        }
        public List<int> RunOpenDaysList
        {
            get { return _runOpenDaysList; }
            set { _runOpenDaysList = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public List<DateTime> ExceptionWindowEnd
        {
            get { return _exceptionWindowEnd; }
            set { _exceptionWindowEnd = value; }
        }
        public List<DateTime> ExceptionWindowStart
        {
            get { return _exceptionWindowStart; }
            set { _exceptionWindowStart = value; }
        }
        public DateTime MaxStartDate
        {
            get { return _maxStartDate; }
            set { _maxStartDate = value; }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public string ProgramPath
        {
            get { return _programPath; }
            set { _programPath = value; }
        }
        public bool Cyclic
        {
            get { return _cyclic; }
            set { _cyclic = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string CalendarPath
        {
            get { return _calendarPath; }
            set { _calendarPath = value; }
        }
        public CalendarType CalType
        {
            get { return _calendarType; }
            set { _calendarType = value; }
        }
        public string CalendarCountry
        {
            get { return _calendarCountry; }
            set { _calendarCountry = value; }
        }
        public string CalendarRegions
        {
            get { return _calendarRegions; }
            set { _calendarRegions = value; }
        }
        public bool RunOpenDays
        {
            get { return _runOpenDays; }
            set { _runOpenDays = value; }
        }
        public bool RunNonOpenDays
        {
            get { return _runNonOpenDays; }
            set { _runNonOpenDays = value; }
        }
        public bool RunSunday
        {
            get { return _runSunday; }
            set { _runSunday = value; }
        }
        public bool RunSaturday
        {
            get { return _runSaturday; }
            set { _runSaturday = value; }
        }
        public bool RunFriday
        {
            get { return _runFriday; }
            set { _runFriday = value; }
        }
        public bool RunThursday
        {
            get { return _runThursday; }
            set { _runThursday = value; }
        }
        public bool RunWednesday
        {
            get { return _runWednesday; }
            set { _runWednesday = value; }
        }
        public bool RunThuesday
        {
            get { return _runThuesday; }
            set { _runThuesday = value; }
        }
        public bool RunMonday
        {
            get { return _runMonday; }
            set { _runMonday = value; }
        }
        public bool ExecuteOnDelay
        {
            get { return _executeOnDelay; }
            set { _executeOnDelay = value; }
        }
        public bool RunSecondEnabled
        {
            get { return _runSecondEnabled; }
            set { _runSecondEnabled = value; }
        }
        public bool RunMinuteEnabled
        {
            get { return _runMinuteEnabled; }
            set { _runMinuteEnabled = value; }
        }
        public bool RunHourEnabled
        {
            get { return _runHourEnabled; }
            set { _runHourEnabled = value; }
        }
        public int RunHour
        {
            get { return _runHour; }
            set { _runHour = value; }
        }
        public int RunMinute
        {
            get { return _runMinute; }
            set { _runMinute = value; }
        }
        public int RunSecond
        {
            get { return _runSecond; }
            set { _runSecond = value; }
        }
        public int ExecuteInterval
        {
            get { return _executeInterval; }
            set { _executeInterval = value; }
        }
        public TimeUnit ExecuteIntervalTimeUnit
        {
            get { return _executeIntervalTimeUnit; }
            set { _executeIntervalTimeUnit = value; }
        }
        public List<ExecutionException> Exclusion
        {
            get { return _exclusions; }
            set { _exclusions = value; }
        }
        public MultiInstanceMode ModeMultiInstance
        {
            get { return _multiInstanceMode; }
            set { _multiInstanceMode = value; }
        }
        public ErrorMode ModeError
        {
            get { return _errorMode; }
            set { _errorMode = value; }
        }
        public bool NoMaxStartDate
        {
            get { return _noMaxStartDate; }
            set { _noMaxStartDate = value; }
        }
        public int MaxRunHour
        {
            get { return _maxRunHour; }
            set { _maxRunHour = value; }
        }
        public int MaxRunMinute
        {
            get { return _maxRunMinute; }
            set { _maxRunMinute = value; }
        }
        public int MaxRunSecond
        {
            get { return _maxRunSecond; }
            set { _maxRunSecond = value; }
        }
        public List<object[]> ManualExecution
        {
            get { return _manualExecution; }
            set { _manualExecution = value; }
        }
        #endregion

        #region Constructor
        public Task()
        {
            Random r = new Random();
            _calendarType = CalendarType.REFERENCED;
            _calendarCountry = "France";
            _id = "-1";// DateTime.Now.Ticks.ToString();
            _exclusions = new List<ExecutionException>();
            _manualExecution = new List<object[]>();
            _runOpenDaysList = new List<int>();
            _runDaysList = new List<int>();
        }
        #endregion

        #region Methods public
        public static bool Exist(Task task)
        {
            if (task.ID == "-1") return false;
            List<string[]> ret = MySqlAdapter.ExecuteReader("select id from s_task where id = " + task.ID);
            return ret.Count > 0;
        }
        public static List<string[]> GetListTask()
        {
            List<string[]> dico = new List<string[]>();
            string query = string.Format(@"SELECT id, name FROM s_task;");

            List<string[]> ret = MySqlAdapter.ExecuteReader(query);

            foreach (string[] row in ret)
            {
                if (row.Length > 1)
                {
                    string[] tabDate = new string[3];
                    tabDate[0] = row[0];
                    tabDate[1] = row[1];
                    tabDate[2] = string.Format("{0} - {1}", row[0], row[1]);
                    dico.Add(tabDate);
                }
            }
            return dico;
        }
        public static List<Task> LoadAllTask()
        {
            List<Task> tasks = new List<Task>();
            string query = string.Format(@"SELECT name FROM s_task;");

            List<string[]> ret = MySqlAdapter.ExecuteReader(query);
            Task t;
            foreach (var result in ret)
            {
                t = new Task();
                t.Load(result[0]);
                tasks.Add(t);
            }
            return tasks;
        }

        public void Process()
        {
        }
        public bool CanBeExecutedOn(DateTime expectedStartDate, DateTime lastExecution)
        {
            if (!_cyclic)
            {
                return !(expectedStartDate < StartDate || expectedStartDate > MaxStartDate);
            }
            else
            {
                if (!CanRunCheckDay(expectedStartDate, lastExecution)) return false;
                else if (!CanRunRunningDelay(expectedStartDate, lastExecution)) return false;
                else if (!CanRunCheckCalendar(expectedStartDate, lastExecution)) return false;
                else if (!CanRunMaxStart(expectedStartDate, lastExecution)) return false;
                else if (!CanRunException(expectedStartDate, lastExecution)) return false;
                return true;
            }
        }
        public DateTime GetNextExecution(DateTime lastExecution)
        {
            if (!_cyclic)
            {
                return _startDate;
            }
            else
            {
                if (_executeOnDelay)
                {
                    bool isAllowedDay = false;
                    if (!isAllowedDay && DateTime.Now.DayOfWeek == DayOfWeek.Monday && _runMonday) isAllowedDay = true;
                    else if (!isAllowedDay && DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && _runThuesday) isAllowedDay = true;
                    else if (!isAllowedDay && DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && _runWednesday) isAllowedDay = true;
                    else if (!isAllowedDay && DateTime.Now.DayOfWeek == DayOfWeek.Thursday && _runThursday) isAllowedDay = true;
                    else if (!isAllowedDay && DateTime.Now.DayOfWeek == DayOfWeek.Friday && _runFriday) isAllowedDay = true;
                    else if (!isAllowedDay && DateTime.Now.DayOfWeek == DayOfWeek.Saturday && _runSaturday) isAllowedDay = true;
                    else if (!isAllowedDay && DateTime.Now.DayOfWeek == DayOfWeek.Sunday && _runSunday) isAllowedDay = true;
                    // TODO : manage the calendar open days
                    if (isAllowedDay)
                    { 
                    }
                }
            }
            return DateTime.Now;
        }
        public List<DateTime> GetListExecution(DateTime minWindow, DateTime maxWindow, HolidayCalculator holidays)
        {
            _holidays = holidays;
            return GetListExecutionDay(minWindow, maxWindow);
            //switch (GetCheckDelay())
            //{
            //    case TimeUnit.DAY: return GetListExecutionDay(minWindow, maxWindow);
            //    case TimeUnit.SECONDE: return GetListExecutionDetail(minWindow, maxWindow);
            //    default : return new List<DateTime>();
            //}
        }
        public List<DateTime> GetListExecutionTime(DateTime date, HolidayCalculator holidays)
        {
            _holidays = holidays;
            //if (!CanBeExecutedOn(date, DateTime.MinValue)) return new List<DateTime>();
            return GetListExecutionTime(date);
        }

        public void Save()
        {
            string query = string.Format("INSERT INTO s_task (id, name, cyclic, programPath, startDate, maxStartDate, calendarPath, calendarCountry, runMonday, runTuesday, runWednesday, runThursday, runFriday, runSaturday, runSunday, executeOnDelay, runSecond, runMinute, runHour, executeInterval, intervalTimeUnit, errorMode, multiInstanceMode, runOnSecond, runOnMinute, runOnHour, maxRunOnSecond, maxRunOnMinute, maxRunOnHour, maxRunSecond, maxRunMinute, maxRunHour, noMaxStartDate, manualJobs) VALUES " +
            "('{0}',{1},'{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},'{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}');",
            DateTime.Now.Ticks.ToString(), _name, _cyclic, _programPath, _startDate, _maxStartDate, _calendarPath, _calendarCountry, _runMonday, _runThuesday, _runWednesday, _runThursday, _runFriday,
            _runSaturday, _runSunday, _executeOnDelay, _runSecond, _runMinute, _runHour, _executeInterval, _executeIntervalTimeUnit, _errorMode, _multiInstanceMode, _maxRunSecond, _maxRunMinute, _maxRunHour, _noMaxStartDate, DumpJobs());

            MySqlAdapter.ExecuteQuery(query);
        }
        public void Update()
        {
            string query = string.Format("UPDATE s_task SET name={0}, cyclic={1}, programPath={2}, startDate={3}, maxStartDate={4}, calendarPath={5}, calendarCountry={6}, runMonday={7}, runTuesday={8}, runWednesday={9}, runThursday={10}, runFriday={11}, runSaturday={12}, runSunday={13}, executeOnDelay={14}, runSecond={15}, runMinute={16}, runHour={17}, executeInterval={18}, intervalTimeUnit ='{19}', errorMode='{20}', multiInstanceMode='{21}'", 
            _name, _cyclic, _programPath, _startDate, _maxStartDate, _calendarPath, _calendarCountry, _runMonday, _runThuesday, _runWednesday, _runThursday, _runFriday,
            _runSaturday, _runSunday, _executeOnDelay, _runSecond, _runMinute, _runHour, _executeInterval, _executeIntervalTimeUnit, _errorMode, _multiInstanceMode);

            MySqlAdapter.ExecuteQuery(query);
        }
        public void Load(string name)
        {
            string query = string.Format(@"SELECT id, name, cyclic, programPath, startDate, maxStartDate, calendarPath, calendarCountry, runMonday, runTuesday, 
            runWednesday, runThursday, runFriday, runSaturday, runSunday, executeOnDelay, runSecond, runMinute, runHour, executeInterval, intervalTimeUnit, errorMode, multiInstanceMode,
            runOnSecond, runOnMinute, runOnHour, maxRunOnSecond, maxRunOnMinute, maxRunOnHour, maxRunSecond, maxRunMinute, maxRunHour, noMaxStartDate, manualJobs
            FROM s_task where name = '{0}';", name);

            List<string[]> ret = MySqlAdapter.ExecuteReader(query);
            if (ret.Count > 0)
            {
                _id = ret[0][0];
                _name = ret[0][1];
                _cyclic = ret[0][2] == "1";
                _programPath = ret[0][3];
                _startDate = DateTime.Parse(ret[0][4]);
                _maxStartDate = DateTime.Parse(ret[0][5]);
                _calendarPath = ret[0][6];
                _calendarCountry = ret[0][7];
                _runMonday = ret[0][8] == "1";
                _runThuesday = ret[0][9] == "1";
                _runWednesday = ret[0][10] == "1";
                _runThursday = ret[0][11] == "1";
                _runFriday = ret[0][12] == "1";
                _runSaturday = ret[0][13] == "1";
                _runSunday = ret[0][14] == "1";
                _executeOnDelay = ret[0][15] == "1";
                _runSecond = int.Parse(ret[0][16]);
                _runMinute = int.Parse(ret[0][17]);
                _runHour = int.Parse(ret[0][18]);
                _executeInterval = int.Parse(ret[0][19]);
                _executeIntervalTimeUnit = (TimeUnit)Enum.Parse(typeof(TimeUnit), ret[0][20]);
                if (!string.IsNullOrEmpty(ret[0][21])) _errorMode = (ErrorMode)Enum.Parse(typeof(ErrorMode), ret[0][21]);
                if (!string.IsNullOrEmpty(ret[0][22])) _multiInstanceMode = (MultiInstanceMode)Enum.Parse(typeof(MultiInstanceMode), ret[0][22]);
                _maxRunSecond = int.Parse(ret[0][30]);
                _maxRunMinute = int.Parse(ret[0][31]);
                _maxRunHour = int.Parse(ret[0][32]);
                _noMaxStartDate = ret[0][33] == "1";
                ParseJob(ret[0][34].ToString());
            }
        }
        public void AddManualExecution(string dump)
        {
            string[] tab = dump.Split('-');
            if (tab.Length > 1)
            {
                try
                {
                    _manualExecution.Add(new object[3] { DateTime.Parse(tab[0].TrimEnd()), DateTime.Parse(tab[1].TrimStart()), DateTime.Parse(tab[0].TrimEnd()) + " - " + DateTime.Parse(tab[1].TrimStart()) });
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error while parsing the task manual date. " + exp.Message);
                }
            }
        }
        #endregion

        #region Method private
        private List<DateTime> GetListExecutionDay(DateTime minWindow, DateTime maxWindow)
        {
            List<DateTime> listDate = new List<DateTime>();
            for (int year = minWindow.Year; year <= maxWindow.Year; year++)
            {
                if (year == minWindow.Year)
                {
                    if (year == maxWindow.Year)
                    {
                        for (int month = minWindow.Month; month <= maxWindow.Month; month++)
                        {
                            GetExecution(listDate, year, month);
                        }
                    }
                    else
                    {
                        for (int month = minWindow.Month; month <= 12; month++)
                        {
                            GetExecution(listDate, year, month);
                        }
                    }
                }
                else if (year == maxWindow.Year)
                {
                    for (int month = 1; month <= maxWindow.Month; month++)
                    {
                        GetExecution(listDate, year, month);
                    }
                }
                else
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        GetExecution(listDate, year, month);
                    }
                }
            }
            return listDate;
        }
        private List<DateTime> GetListExecutionTime(DateTime date)
        {
            List<DateTime> tempLst = new List<DateTime>();
            if (_runSecondEnabled && _runMinuteEnabled && _runHourEnabled)
            {
                tempLst.Add(new DateTime(date.Year, date.Month, date.Day, _runHour, _runMinute, _runSecond));
            }
            else if (_runSecondEnabled && _runMinuteEnabled && !_runHourEnabled)
            {
                for (int i = 0; i < 24; i++)
                {
                    tempLst.Add(new DateTime(date.Year, date.Month, date.Day, i, _runMinute, _runSecond));
                }
            }
            else if (_runSecondEnabled && !_runMinuteEnabled && _runHourEnabled)
            {
                for (int i = 0; i < 60; i++)
                {
                    tempLst.Add(new DateTime(date.Year, date.Month, date.Day, _runHour, i, _runSecond));
                }
            }
            else if (_runSecondEnabled && !_runMinuteEnabled && !_runHourEnabled)
            {
                for (int h = 0; h < 24; h++)
                {
                    for (int m = 0; m < 60; m++)
                    {
                        tempLst.Add(new DateTime(date.Year, date.Month, date.Day, h, m, _runSecond));
                    }
                }
            }
            else if (!_runSecondEnabled && _runMinuteEnabled && _runHourEnabled)
            {
                tempLst.Add(new DateTime(date.Year, date.Month, date.Day, _runHour, _runMinute, 0));
            }
            else if (!_runSecondEnabled && _runMinuteEnabled && !_runHourEnabled)
            {
                for (int h = 0; h < 24; h++)
                {
                    tempLst.Add(new DateTime(date.Year, date.Month, date.Day, h, _runMinute, 0));
                }
            }
            else if (!_runSecondEnabled && !_runMinuteEnabled && _runHourEnabled)
            {
                for (int m = 0; m < 60; m++)
                {
                    tempLst.Add(new DateTime(date.Year, date.Month, date.Day, _runHour, m, 0));
                }
            }
            return tempLst;
        }
        private void GetExecution(List<DateTime> lstDate, int year, int month)
        {
            if (_cyclic)
            {
                GetExecutionDayNum(lstDate, year, month);
                GetExecutionOpenDay(lstDate, year, month);
                GetExecutionWeekDay(lstDate, year, month);
                GetExecutionAllOpenDay(lstDate, year, month);
                GetExecutionAllNonOpenDay(lstDate, year, month);
            }
            else
            {
                DateTime dt;
                foreach (object[] execution in _manualExecution)
                {
                    if (DateTime.TryParse(execution[0].ToString(), out dt))
                    {
                        if (dt.Year == year && dt.Month == month) lstDate.Add(dt);
                    }
                }
            }
        }
        private void GetExecutionDayNum(List<DateTime> lstDate, int year, int month)
        {
            if (_runDaysList.Count > 0)
            {
                DateTime dt;
                foreach (int day in _runDaysList)
                {
                    dt = new DateTime(year, month, day);
                    if (day > 0 && day <= DateTime.DaysInMonth(year, month) && !dt.Equals(DateTime.MinValue) && !lstDate.Contains(dt)) lstDate.Add(new DateTime(year, month, day));
                }
            }
        }
        private void GetExecutionOpenDay(List<DateTime> lstDate, int year, int month)
        {
            if (_runOpenDaysList.Count > 0)
            {
                foreach (int day in _runOpenDaysList)
                {
                    DateTime dt = Calendar.GetDayOfOpenNum(_holidays, day, month, year);
                    if (dt != null && !dt.Equals(DateTime.MinValue) && !lstDate.Contains(dt)) lstDate.Add(dt);
                }
            }
        }
        private void GetExecutionWeekDay(List<DateTime> lstDate, int year, int month)
        {
            DateTime date;
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                date = new DateTime(year, month, day);
                if (!lstDate.Contains(date) && !date.Equals(DateTime.MinValue))
                {
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            if (_runMonday) lstDate.Add(date);
                            break;
                        case DayOfWeek.Tuesday:
                            if (_runThuesday) lstDate.Add(date);
                            break;
                        case DayOfWeek.Wednesday:
                            if (_runWednesday) lstDate.Add(date);
                            break;
                        case DayOfWeek.Thursday:
                            if (_runThursday) lstDate.Add(date);
                            break;
                        case DayOfWeek.Friday:
                            if (_runFriday) lstDate.Add(date);
                            break;
                        case DayOfWeek.Saturday:
                            if (_runSaturday) lstDate.Add(date);
                            break;
                        case DayOfWeek.Sunday:
                            if (_runSunday) lstDate.Add(date);
                            break;
                    }
                }
            }
        }
        private void GetExecutionAllOpenDay(List<DateTime> lstDate, int year, int month)
        {
            if (_runOpenDays)
            {
                for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                {
                    DateTime dt = Calendar.GetDayOfOpenNum(_holidays, day, month, year);
                    if (!_holidays.IsNonWorkingDay(dt))
                    {
                        if (dt != null && !dt.Equals(DateTime.MinValue) && !lstDate.Contains(dt)) lstDate.Add(dt);
                    }
                }
            }
        }
        private void GetExecutionAllNonOpenDay(List<DateTime> lstDate, int year, int month)
        {
            if (_runNonOpenDays)
            {
                for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                {
                    DateTime dt = new DateTime(year, month, day);
                    if (_holidays.IsNonWorkingDay(dt))
                    {
                        if (dt != null && !dt.Equals(DateTime.MinValue) && !lstDate.Contains(dt)) lstDate.Add(dt);
                    }
                }
            }
        }

        private TimeUnit GetCheckDelay()
        {
            if (!_cyclic) return TimeUnit.DAY;
            if (_executeOnDelay) return _executeIntervalTimeUnit;
            //if (_runSecondEnabled) return TimeUnit.SECONDE;
            //if (_runMinuteEnabled) return TimeUnit.MINUTE;
            //if (_runHourEnabled) return TimeUnit.HOUR;
            else return TimeUnit.SECONDE;
        }
        private bool CanRunCheckDay(DateTime expectedStartDate, DateTime lastExecution)
        {
            // TODO : manage the calendar open days
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && !_runMonday) return false;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && !_runThuesday) return false;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && !_runWednesday) return false;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday && !_runThursday) return false;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday && !_runFriday) return false;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && !_runSaturday) return false;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && !_runSunday) return false;

            return true;
        }
        private bool CanRunRunningDelay(DateTime expectedStartDate, DateTime lastExecution)
        {
            if (_executeOnDelay)
            {
                DateTime checkDate = DateTime.MinValue;
                switch (_executeIntervalTimeUnit)
                {
                    case TimeUnit.MILLISECOND: checkDate = lastExecution.AddMilliseconds(_executeInterval); break;
                    case TimeUnit.SECONDE: checkDate = lastExecution.AddSeconds(_executeInterval); break;
                    case TimeUnit.MINUTE: checkDate = lastExecution.AddMinutes(_executeInterval); break;
                    case TimeUnit.HOUR: checkDate = lastExecution.AddHours(_executeInterval); break;
                    case TimeUnit.DAY: checkDate = lastExecution.AddDays(_executeInterval); break;
                    case TimeUnit.WEEK: checkDate = lastExecution.AddDays(_executeInterval * 7); break;
                    case TimeUnit.MONTH: checkDate = lastExecution.AddMonths(_executeInterval); break;
                    case TimeUnit.YEAR: checkDate = lastExecution.AddYears(_executeInterval); break;
                }
                if (expectedStartDate < (checkDate)) return false;
            }
            else
            {
                if (expectedStartDate.Second != _runSecond) return false;
                if (expectedStartDate.Minute != _runMinute) return false;
                if (expectedStartDate.Hour != _runHour) return false;
            }
            return true;
        }
        private bool CanRunCheckCalendar(DateTime expectedStartDate, DateTime lastExecution)
        {
            return true;
        }
        private bool CanRunMaxStart(DateTime expectedStartDate, DateTime lastExecution)
        {
            if (!_noMaxStartDate)
            {
                DateTime checkDate = expectedStartDate;
                checkDate = checkDate.AddSeconds(_maxRunSecond);
                checkDate = checkDate.AddMinutes(_maxRunMinute);
                checkDate = checkDate.AddHours(_maxRunHour);

                return DateTime.Now < checkDate;
            }
            return true;
        }
        private bool CanRunException(DateTime expectedStartDate, DateTime lastExecution)
        {
            if (_exceptionWindowStart.Count == _exceptionWindowEnd.Count)
            {
                for (int i = 0; i < _exceptionWindowStart.Count; i++)
                {
                    if (expectedStartDate > _exceptionWindowStart[i] && expectedStartDate < _exceptionWindowEnd[i]) return false;  
                }
            }
            return true;
        }
        private string DumpJobs()
        {
            string manualJobs = string.Empty;
            foreach (var item in _manualExecution)
            {
                if (!string.IsNullOrEmpty(manualJobs)) manualJobs += '#';
                manualJobs += item[2];
            }
            return manualJobs;
        }
        private void ParseJob(string dump)
        {
            if (_manualExecution != null) _manualExecution.Clear();
            else _manualExecution = new List<object[]>();
            string[] tabJobs = dump.Split('#');
            string[] tabDate;
            foreach (var item in tabJobs)
            {
                tabDate = item.Split('-');
                if (tabDate.Length > 1)
                {
                    _manualExecution.Add(new object[] { DateTime.Parse(tabDate[0]), DateTime.Parse(tabDate[1]), DateTime.Parse(tabDate[0]) + " - " + DateTime.Parse(tabDate[1]) });
                }
            }
        }
        #endregion
    }
}
