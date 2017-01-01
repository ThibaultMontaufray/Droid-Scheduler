using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Droid_scheduler
{
    public partial class CalendarForm : Form
    {
        #region Attribute
        private string _country;
        private HolidayCalculator _hc;
        private bool _calModification = false;
        #endregion

        #region Constructor
        public CalendarForm()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            TestRamadan();
            _country = "France";
            comboBoxCountry.Text = _country;
            comboBoxCountry.SelectedValueChanged += new EventHandler(comboBoxCountry_SelectedValueChanged);

            NumUpDownYear.Text = DateTime.Now.Year.ToString();
            NumUpDownYear.ValueChanged += new EventHandler(NumUpDownYear_ValueChanged);

            NumUpDownMonth.Text = DateTime.Now.Month.ToString();
            NumUpDownMonth.ValueChanged += new EventHandler(NumUpDownMonth_ValueChanged);

            Assembly ass = Assembly.GetExecutingAssembly();
            _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysFrance);
            _country = comboBoxCountry.Text;

            BuildHolidaysList();

            trackBarOpenDay.Maximum = Calendar.GetMaxNbOpenDay(_hc,  int.Parse(NumUpDownMonth.Text), int.Parse(NumUpDownYear.Text));
            trackBarOpenDay.ValueChanged += new EventHandler(trackBarOpenDay_ValueChanged);

            monthCalendar.DateSelected += new DateRangeEventHandler(monthCalendar_DateSelected);
        }
        private void RefreshCalendar()
        {
            monthCalendar.Enabled = true;
            DateTime val = Calendar.GetDayOfOpenNum(_hc, (int)trackBarOpenDay.Value, (int)NumUpDownMonth.Value, (int)NumUpDownYear.Value);
            if (val != DateTime.MinValue) monthCalendar.SetDate(val);
            else monthCalendar.Enabled = false;
        }
        private void BuildHolidaysList()
        {
            textBoxHolidaysList.Clear();
            foreach (Holiday h in _hc.Orderedholidays)
            {
                if (h.Date.Year == NumUpDownYear.Value) textBoxHolidaysList.AppendText(h.Date.ToShortDateString() + "\t" + h.LocalName + " (" + h.Name + ")" + "\r\n");
            }
        }
        #endregion

        #region Event
        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            _calModification = true;
            trackBarOpenDay.Value = Calendar.GetNumOfOpenDay(_hc, monthCalendar.SelectionRange.Start);
            NumUpDownMonth.Value = monthCalendar.SelectionRange.Start.Month;
            NumUpDownYear.Value = monthCalendar.SelectionRange.Start.Year;
            _calModification = false;
        }
        private void NumUpDownMonth_ValueChanged(object sender, EventArgs e)
        {
            int maxVal = Calendar.GetMaxNbOpenDay(_hc, (int)NumUpDownMonth.Value, (int)NumUpDownYear.Value);
            if (trackBarOpenDay.Value > maxVal) trackBarOpenDay.Value = maxVal;
            trackBarOpenDay.Maximum = maxVal;
            if (!_calModification) RefreshCalendar();
        }
        private void NumUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            if (!_calModification) RefreshCalendar();
            BuildHolidaysList();
        }
        private void comboBoxCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            _hc.Orderedholidays.Clear();
            _country = comboBoxCountry.SelectedItem.ToString();
            Assembly ass = Assembly.GetExecutingAssembly();
            switch (comboBoxCountry.Text)
            {
                case "Allemagne":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysAllemagne);
                    break;
                case "France":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysFrance);
                    break;
                case "Belgique":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysBelgique);
                    break;
                case "Bolivie":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysBolivia);
                    break;
                case "India":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysIndia);
                    break;
                case "Irland":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysIrland);
                    break;
                case "Canada":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysCanada);
                    break;
                case "Royaumes Unis":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysRoyaumeUnis);
                    break;
                case "Etats Unis":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysUnitedStates);
                    break;
                case "Russie":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysRusse);
                    break;
                case "Togo":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysTogo);
                    break;
                case "Tunisie":
                    _hc = new HolidayCalculator(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), Resource.HolidaysTunisie);
                    break;
            }
            RefreshCalendar();
            BuildHolidaysList();         
        }
        private void trackBarOpenDay_ValueChanged(object sender, EventArgs e)
        { 
            labelOpenDay.Text = "Open day        : " + trackBarOpenDay.Value;
            if (!_calModification) RefreshCalendar();
        }
        private void TestRamadan()
        {
            System.Globalization.HijriCalendar hc = new System.Globalization.HijriCalendar();
            object o = hc.GetEra(DateTime.Now);
        }
        #endregion
    }
}
