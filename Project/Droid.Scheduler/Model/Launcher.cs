namespace Droid.Scheduler.Core
{
    using System.Collections.Generic;

    public class Launcher
    {
        #region Attribute
        private Box _parent;
        private List<Job> _jobs;
        #endregion

        #region Properties
        public Box Parent
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
        public Launcher(Box parent)
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
