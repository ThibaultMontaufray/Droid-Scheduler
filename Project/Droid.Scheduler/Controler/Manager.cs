namespace Droid.Scheduler.Core.Controler
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Owner of the list of task, launch it and give the status
    /// </summary>
    public static class Manager
    {
        #region Attributes
        private static readonly string CONFIG_PATH = @"C:\Users\Thib\Documents\scheduler.config";
        private static List<Box> _tasks;
        #endregion

        #region Properties
        public static List<Box> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
        #endregion

        #region Methods public
        public static void Init()
        {

        }
        #endregion

        #region Methods private
        private static void LoadConfigFIle()
        {
            using (StreamReader sr = new StreamReader(CONFIG_PATH))
            {

            }
        }
        #endregion
    }
}
