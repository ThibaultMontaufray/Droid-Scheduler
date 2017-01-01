using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid_scheduler
{
    public partial class Month : UserControl
    {
        #region Enum
        public enum CalendarType
        {
            JULIAN,
            HINDU,
            ISLAMIC
        }
        #endregion

        #region Attribute
        private CalendarType _type;
        private HolidayCalculator _nonWorkingDays;
        private string _name;
        private List<DateTime> _specificDates;
        private int _year;
        #endregion

        #region Properties
        public new string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                if (labelMonthName != null) labelMonthName.Text = value;
                LoadDays();
            }
        }
        public CalendarType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public HolidayCalculator NonWorkingDays
        {
            get { return _nonWorkingDays; }
            set { _nonWorkingDays = value; }
        }
        public List<DateTime> SpecificDates
        {
            get { return _specificDates; }
            set 
            { 
                _specificDates = value;
                LoadDays();
            }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        #endregion

        #region Constructor
        public Month()
        {
            _specificDates = new List<DateTime>();
            _type = CalendarType.JULIAN;
            //_nonWorkingDays = new HolidayCalculator(new DateTime(DateTime.Now.Year, 1, 1), Droid_scheduler.Properties.Resources.holidays_france);
            _nonWorkingDays = new HolidayCalculator();
            InitializeComponent();
            _name = Droid_scheduler.Calendar.MonthNameInJulianCalendar(DateTime.Now);

            Init();
            LoadDays();
        }
        public Month(CalendarType type, HolidayCalculator holiday, string monthName)
        {
            _specificDates = new List<DateTime>();
            _type = type;
            _nonWorkingDays = holiday;

            Name = monthName;
            InitializeComponent();

            Init();
            LoadDays();
        }
        #endregion

        #region Methods public
        public void RefreshMonth()
        {
            LoadDays();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            labelMonthName.Text = _name;
        }
        private void LoadDays()
        {
            _dataGridViewCalendar.Rows.Clear();
            _dataGridViewCalendar.Columns.Clear();
            labelMonthName.Text = _name;

            switch (_type)
            {
                case CalendarType.JULIAN: LoadJulian(); break;
                case CalendarType.HINDU: LoadHindu(); break;
                case CalendarType.ISLAMIC: LoadIslamic(); break;
            }

            foreach (DateTime date in _specificDates)
            {
                if (date.Year == _year) SetSpecificDay(date);
            }
        }
        private void LoadJulian()
        {
            DateTime dt = DateTime.Now;
            switch (labelMonthName.Text.ToLower())
            {
                case "january":
                    dt = new DateTime(DateTime.Now.Year, 1, 1);
                    break;
                case "february":
                    dt = new DateTime(DateTime.Now.Year, 2, 1);
                    break;
                case "march":
                    dt = new DateTime(DateTime.Now.Year, 3, 1);
                    break;
                case "april":
                    dt = new DateTime(DateTime.Now.Year, 4, 1);
                    break;
                case "may":
                    dt = new DateTime(DateTime.Now.Year, 5, 1);
                    break;
                case "june":
                    dt = new DateTime(DateTime.Now.Year, 6, 1);
                    break;
                case "july":
                    dt = new DateTime(DateTime.Now.Year, 7, 1);
                    break;
                case "august":
                    dt = new DateTime(DateTime.Now.Year, 8, 1);
                    break;
                case "september":
                    dt = new DateTime(DateTime.Now.Year, 9, 1);
                    break;
                case "october":
                    dt = new DateTime(DateTime.Now.Year, 10, 1);
                    break;
                case "november":
                    dt = new DateTime(DateTime.Now.Year, 11, 1);
                    break;
                case "december":
                    dt = new DateTime(DateTime.Now.Year, 12, 1);
                    break;
            }
            SetDays(dt);
        }
        private void SetDays(DateTime dt)
        {
            AddColumn("monday", "MO");
            AddColumn("tuesday", "TU");
            AddColumn("wednesday", "WE");
            AddColumn("thursday", "TH");
            AddColumn("friday", "FR");
            AddColumn("saturday", "SA");
            AddColumn("sunday", "SU");
            _dataGridViewCalendar.Rows.Add();
            _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Height = 18;
            _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Gray;
            _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Gray;

            int cellNum = 0;
            for (int i = 1; i <= DateTime.DaysInMonth(dt.Year, dt.Month); i++)
            {
                switch (new DateTime(dt.Year, dt.Month, i).DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        _dataGridViewCalendar.Rows.Add();
                        cellNum = 0;
                        break;
                    case DayOfWeek.Tuesday:
                        cellNum = 1;
                        break;
                    case DayOfWeek.Wednesday:
                        cellNum = 2;
                        break;
                    case DayOfWeek.Thursday:
                        cellNum = 3;
                        break;
                    case DayOfWeek.Friday:
                        cellNum = 4;
                        break;
                    case DayOfWeek.Saturday:
                        cellNum = 5;
                        break;
                    case DayOfWeek.Sunday:
                        cellNum = 6;
                        break;
                }
                _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Value = i;
                _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.SelectionForeColor = Color.Black;
                switch (Droid_scheduler.Calendar.IsOpenDay(_nonWorkingDays, new DateTime(dt.Year, dt.Month, i)))
                {
                    case 0 :
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.BackColor = Color.WhiteSmoke;
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.SelectionBackColor = Color.WhiteSmoke;
                        break;
                    case 1:
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.BackColor = Color.LightGray;
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.SelectionBackColor = Color.LightGray;
                        break;
                    case 2:
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.BackColor = Color.DarkGray;
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.SelectionBackColor = Color.DarkGray;
                        break;
                    default :
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.BackColor = Color.Gray;
                        _dataGridViewCalendar.Rows[_dataGridViewCalendar.Rows.Count - 1].Cells[cellNum].Style.SelectionBackColor = Color.Gray;
                        break;
                }
            }
        }
        private void SetSpecificDay(DateTime dt)
        {
            foreach (DataGridViewRow row in _dataGridViewCalendar.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Equals(dt.Day.ToString()))
                    {
                        cell.Style.BackColor = Color.DarkOrange;
                        break;
                    }
                }
            }
        }
        private void AddColumn(string header, string name)
        {
            _dataGridViewCalendar.Columns.Add(header, name);
            _dataGridViewCalendar.Columns[_dataGridViewCalendar.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            _dataGridViewCalendar.Columns[_dataGridViewCalendar.Columns.Count - 1].Width = 21;
            _dataGridViewCalendar.Columns[_dataGridViewCalendar.Columns.Count - 1].CellTemplate.Style.Font = Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _dataGridViewCalendar.Columns[_dataGridViewCalendar.Columns.Count - 1].HeaderCell.Style.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _dataGridViewCalendar.Columns[_dataGridViewCalendar.Columns.Count - 1].CellTemplate.Style.BackColor = Color.Gray;
            _dataGridViewCalendar.Columns[_dataGridViewCalendar.Columns.Count - 1].CellTemplate.Style.SelectionForeColor = Color.Gray;
        }
        private void LoadHindu()
        {
        }
        private void LoadIslamic()
        {
        }
        #endregion
    }
}
