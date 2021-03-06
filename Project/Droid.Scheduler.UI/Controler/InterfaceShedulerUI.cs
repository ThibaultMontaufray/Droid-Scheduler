﻿namespace Droid.Scheduler.UI
{
    using Droid.Scheduler.Core;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Tools.Utilities.UI;

    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural langage.
    /// </summary>            
    public class Interface_sheduler : GPInterfaceUI
    {
        #region Attributes
        private new ToolStripMenuSCH _tsm;
        private ViewScheduler _viewScheduler;
        #endregion

        #region Properties
        public ToolStripMenuSCH Tsm
        {
            get { return _tsm; }
            set { _tsm = value as ToolStripMenuSCH; }
        }
        #endregion

        #region Constructor
        public Interface_sheduler()
        {
            Init();
        }
        #endregion

        #region Methods public
        [Description("french[afficher.calendrier(pays)];english[display.calendar(country)]")]
        public static void ACTION_130_afficher_calendrier(string pays)
        {
            Window formCalendar = new Window();
            formCalendar.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            formCalendar.Height = 575;
            formCalendar.Width = 640;
            formCalendar.StartPosition = FormStartPosition.CenterParent;
            formCalendar.Text = "Calendar " + DateTime.Now.Year;

            CalendarView cv = new CalendarView(DateTime.Now.Year, HolidayCalculator.GetCalendar(pays));
            cv.Dock = DockStyle.Fill;

            formCalendar.Controls.Add(cv);
            formCalendar.ShowDialog();
        }
        public static void ACTION_131_planifier_programme()
        {
            Window formPlanJob = new Window();
            formPlanJob.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            formPlanJob.Height = 510;
            formPlanJob.Width = 915;
            formPlanJob.StartPosition = FormStartPosition.CenterParent;
            formPlanJob.Text = "Planifier job";

            TaskSetting ts = new TaskSetting();
            ts.Dock = DockStyle.Fill;

            formPlanJob.Controls.Add(ts);
            formPlanJob.ShowDialog();
        }

        public override void GoAction(string action)
        {
            switch (action)
            {
                case "Home":
                    break;
                default:
                    break;
            }
        }
        public System.Windows.Forms.RibbonTab BuildToolBar()
        {
            _tsm = new ToolStripMenuSCH(this);
            _tsm.ActionAppened += GlobalAction;
            return _tsm;
        }
        #endregion

        #region Methods private
        private void Init()
        {
            BuildToolBar();
            LaunchWelcome();
        }
        private void LaunchWelcome()
        {
            if (_viewScheduler == null) { _viewScheduler = new ViewScheduler(); }
            LaunchSheet(_viewScheduler);
        }
        #endregion

        #region Event
        #endregion
    }
}
