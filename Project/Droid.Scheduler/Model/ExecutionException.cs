namespace Droid.Scheduler.Core
{
    using System;

    public class ExecutionException
    {
        #region Attribute
        private DateTime _startDate = DateTime.MinValue;
        private DateTime _endDate = DateTime.MaxValue;
        #endregion

        #region Properties
        public DateTime MaxStartDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        #endregion

        #region Constructor
        public ExecutionException()
        {

        }
        public ExecutionException(string dump)
        {
            string[] tab = dump.Split(' ');
            if (tab.Length > 4)
            {
                try
                {
                    string[] startDate = tab[0].Split('/');
                    string[] startTime = tab[1].Split(':');
                    _startDate = new DateTime(int.Parse(startDate[2]), int.Parse(startDate[1]), int.Parse(startDate[0]), int.Parse(startTime[0]), int.Parse(startTime[1]), int.Parse(startTime[2]));

                    string[] endDate = tab[3].Split('/');
                    string[] endTime = tab[4].Split(':');
                    _endDate = new DateTime(int.Parse(endDate[2]), int.Parse(endDate[1]), int.Parse(endDate[0]), int.Parse(endTime[0]), int.Parse(endTime[1]), int.Parse(endTime[2]));
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Cannot parse the exception date : " + exp.Message);
                }
            }
        }
        #endregion

        #region Methods public
        public bool IsValidDate(DateTime date)
        {
            return (date < _endDate && date > _startDate);
        }
        #endregion

        #region Methods private
        private void ParseDump()
        { 
        }
        #endregion
    }
}
