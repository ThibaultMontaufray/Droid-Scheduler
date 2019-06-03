using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Droid.Scheduler.Core;

namespace Droid.Scheduler.UI
{
    public partial class CalendarView : UserControl
    {
        #region Attribute
        private List<DateTime> _executionDates;
        private HolidayCalculator _holidays;
        private int _year;
        #endregion

        #region Properties
        public HolidayCalculator NonWorkingDays
        {
            get { return _holidays; }
            set { _holidays = value; }
        }
        public List<DateTime> ExecutionDates
        {
            get { return _executionDates; }
            set 
            { 
                _executionDates = value; 
                RefreshMonth();
            }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        #endregion

        #region Constructor
        public CalendarView(int year)
        {
            _year = year;
            SuspendLayout();
            InitializeComponent();
            Init();
            ResumeLayout();
        }
        public CalendarView(int year, HolidayCalculator holidays)
        {
            _year = year;
            _holidays = holidays;

            SuspendLayout();
            InitializeComponent();
            Init();
            RefreshMonth();
            ResumeLayout();
        }
        #endregion

        #region Methods public
        #endregion

        #region Mehtods private
        public void Init()
        {
            if (_holidays == null) _holidays = new HolidayCalculator();
            if (_executionDates == null) _executionDates = new List<DateTime>();
        }
        private void RefreshMonth()
        {
            SuspendLayout();

            SetMonth(_year, _month1, "January");
            SetMonth(_year, _month2, "February");
            SetMonth(_year, _month3, "March");
            SetMonth(_year, _month4, "April");
            SetMonth(_year, _month5, "May");
            SetMonth(_year, _month6, "June");
            SetMonth(_year, _month7, "July");
            SetMonth(_year, _month8, "August");
            SetMonth(_year, _month9, "September");
            SetMonth(_year, _month10, "October");
            SetMonth(_year, _month11, "November");
            SetMonth(_year, _month12, "December");

            foreach (DateTime date in _executionDates)
            {
                switch (date.Month)
                {
                    case 1:SetMonthSpeDate(_month1, date);break;
                    case 2:SetMonthSpeDate(_month2, date);break;
                    case 3:SetMonthSpeDate(_month3, date);break;
                    case 4:SetMonthSpeDate(_month4, date);break;
                    case 5:SetMonthSpeDate(_month5, date);break;
                    case 6:SetMonthSpeDate(_month6, date);break;
                    case 7:SetMonthSpeDate(_month7, date);break;
                    case 8:SetMonthSpeDate(_month8, date);break;
                    case 9:SetMonthSpeDate(_month9, date);break;
                    case 10:SetMonthSpeDate(_month10, date);break;
                    case 11:SetMonthSpeDate(_month11, date);break;
                    case 12:SetMonthSpeDate(_month12, date);break;
                }
            }
            ResumeLayout();
        }
        private void SetMonth(int year, Month m, string name)
        {
            m.Year = year;
            m.Name = name;
            m.NonWorkingDays = _holidays;
            m.RefreshMonth();
        }
        private void SetMonthSpeDate(Month m, DateTime date)
        {
            m.SpecificDates.Add(date);
            m.NonWorkingDays = _holidays;
            m.RefreshMonth();
        }
        #endregion
    }
}
