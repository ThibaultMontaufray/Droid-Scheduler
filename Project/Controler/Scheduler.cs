namespace Droid_scheduler
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;

    public class Scheduler
    {
        #region Attribute
        private System.Windows.Forms.Timer _timer;
        private bool _timerLock = false;
        private List<Job> _jobs;
        private List<Thread> _threads;
        #endregion

        #region Properties
        public List<Job> Tasks
        {
            get { return _jobs; }
            set { _jobs = value; }
        }
        #endregion

        #region Constructor
        public Scheduler()
        {
            _threads = new List<Thread>();
            _jobs = Job.LoadAllJobs();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
        }
        #endregion

        #region Methods public
        public void Start()
        {
            if ( !_timerLock ) _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
        #endregion

        #region Methods private
        private void CheckJob()
        {
            _timerLock = true;
            _timer.Stop();
            foreach (Job job in _jobs)
            {
                if (job.StartDate >= DateTime.Now) Process(job);
            }
            _timer.Start();
            _timerLock = false;
        }
        private void Process(Job job)
        {
            Thread thread = new Thread(job.Execute);
            thread.Start();
            // TODO check the end of the thread
        }
        #endregion

        #region Event
        private void _timer_Tick(object sender, System.EventArgs e)
        {
            CheckJob();
        }
        #endregion
    }
}
