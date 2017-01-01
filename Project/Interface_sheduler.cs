namespace Droid_scheduler
{
    using System;
    using System.Windows.Forms;
    using Tools4Libraries;

    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural langage.
    /// </summary>            
    public class Interface_sheduler
    {
        #region Constructor
        #endregion

        #region Methods public
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
        #endregion
    }
}
