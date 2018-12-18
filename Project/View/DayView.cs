using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid.scheduler
{
    public delegate void DayViewEventHandler(DayView dv, DateTime dt);
    public partial class DayView : UserControl
    {
        #region Attribute
        public event DayViewEventHandler DayChanged;
        #endregion

        #region Constructor
        public DayView(DateTime displayDate)
        {
            InitializeComponent();
            dateTimePicker1.Value = displayDate;
        }
        #endregion

        #region Methods public
        public void Refresh(List<DateTime> executions)
        {
            dataGridViewExecutions.Rows.Clear();
            LoadDay();
            LoadExecutions(executions);
        }
        #endregion

        #region Methods private
        private void LoadDay()
        {
            for (int i = 0; i < 24; i++)
			{
			    dataGridViewExecutions.Rows.Add();
                dataGridViewExecutions.Rows[dataGridViewExecutions.Rows.Count - 1].Cells[0].Value = i;
			}
        }
        private void LoadExecutions(List<DateTime> executions)
        {
            foreach (DateTime date in executions)
	        {
		        if (dataGridViewExecutions.Rows[date.Hour].Cells[1].Value != null && !string.IsNullOrEmpty(dataGridViewExecutions.Rows[date.Hour].Cells[1].Value.ToString())) dataGridViewExecutions.Rows[date.Hour].Cells[1].Value += " ";
                dataGridViewExecutions.Rows[date.Hour].Cells[1].Value += string.Format("[ {0}m{1}s ]", date.ToString("mm"), date.ToString("ss"));
	        }
        }
        #endregion

        #region Event
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (DayChanged != null) DayChanged(this, dateTimePicker1.Value);
        }
        #endregion
    }
}
