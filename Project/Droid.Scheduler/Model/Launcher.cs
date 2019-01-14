namespace Droid.Scheduler
{
    using System.Collections.Generic;

    public class Launcher
    {
        #region Attribute
        private Task _parent;
        private List<Job> _jobs;
        #endregion

        #region Properties
        public Task Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        public List<Job> Jobs
        {
            get { return _jobs; }
            set { _jobs = value; }
        }
        #endregion

        #region Constructor
        public Launcher(Task parent)
        {
            _jobs = new List<Job>();
            _parent = parent;
            CalculateNextExecution();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void CalculateNextExecution()
        {

        }
        #endregion
    }
}
