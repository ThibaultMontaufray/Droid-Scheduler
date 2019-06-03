namespace Droid.Scheduler.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Task instance
    /// </summary>
    public class Job
    {
        #region Enum
        public enum StateOfJob
        {
            UNKNOW,
            PENDING,
            WAITING_OTHER_JOB,
            RUNNING,
            SUCCESS,
            ERROR,
            FROZEN
        }
        #endregion

        #region Attribute
        private Box _parent;
        private DateTime _startDate;
        private DateTime _maxStartWindow;
        private StateOfJob _status;
        #endregion

        #region Properties
        public DateTime MaxStartWindow
        {
            get { return _maxStartWindow; }
            set { _maxStartWindow = value; }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public Box Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        public StateOfJob Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

        #region Constructor
        public Job(Box parent)
        {
            _parent = parent;
            _status = StateOfJob.UNKNOW;
        }
        #endregion

        #region Methods public
        public void Execute()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.CreateNoWindow = true;
            psi.FileName = _parent.ProgramPath;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            
            using (Process proc = new Process())
            { 
                proc.StartInfo = psi;
                proc.Start();
                proc.WaitForExit();
            }
        }
        public static List<Job> LoadAllJobs()
        {
            List<Job> jobs = new List<Job>();

            return jobs;
        }
        #endregion

        #region Methods private
        private void GetProperties()
        {
            _startDate = _parent.GetNextExecution(DateTime.MinValue);
        }
        #endregion
    }
}
