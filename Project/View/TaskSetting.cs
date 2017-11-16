namespace Droid_scheduler
{
    using Droid_Database;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Tools4Libraries;

    public delegate void TaskSettingEventHandler(string requestValue); 
    public partial class TaskSetting : UserControl
    {
        #region Attribute
        public event TaskSettingEventHandler RequestHappen;
        public event TaskSettingEventHandler CancelRequested;

        private List<string[]> _tasks;
        private Task _currentTask;
        private HolidayCalculator _holidays;
        #endregion

        #region Properties
        public List<string[]> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
        #endregion

        #region Constructor
        public TaskSetting()
        {
            _currentTask = new Task();
            _tasks = new List<string[]>();
            InitializeComponent();
            dataGridViewException.CellClick += dataGridViewException_CellClick;
            dataGridViewManualExecution.CellClick += dataGridViewManualExecution_CellClick;
            comboBoxReferencedCalendar.SelectedIndex = comboBoxReferencedCalendar.Items.IndexOf("France");
            comboBoxMulitInstance.SelectedIndex = 0;
            comboBoxErrorMode.SelectedIndex = 0;
            LoadDayPreview();
            LoadTaskList();
            LoadRegions();
        }
        #endregion

        #region Methods Public
        #endregion

        #region Methods Protected
        protected void OnRequestHappen(string action)
        {
            if (RequestHappen != null) RequestHappen(action);
        }
        protected void OnCancelRequested()
        {
            if (CancelRequested != null) CancelRequested(string.Empty);
        }
        #endregion

        #region Methods Private
        private void LoadRegions()
        {
            checkedComboBoxRegions.Items.Clear();
            checkedComboBoxRegions.Items.Add("All regions");
            checkedComboBoxRegions.SetItemChecked(checkedComboBoxRegions.Items.IndexOf("All regions"), true);

            switch (_currentTask.CalendarCountry.ToLower())
            {
                case "canada":
                    checkedComboBoxRegions.Items.Add("MB"); 
                    checkedComboBoxRegions.Items.Add("PE"); 
                    checkedComboBoxRegions.Items.Add("AB"); 
                    checkedComboBoxRegions.Items.Add("BC"); 
                    checkedComboBoxRegions.Items.Add("ON");
                    checkedComboBoxRegions.Items.Add("SK");
                    break;
                case "france":
                case "india":
                case "ireland":
                case "russia":
                case "usa":
                case "togo":
                case "great britain":
                case "germany":
                default:
                    break;
            }
        }
        private void LoadTaskList()
        {
            comboBoxJobSelection.Items.Clear();
            _tasks = Task.GetListTask();
            foreach (var item in _tasks)
            {
                comboBoxJobSelection.Items.Add(item[2]);
            }
        }
        private Task GetTask(string taskName)
        {
            if (string.IsNullOrEmpty(taskName)) return null;
            Task t = new Task();
            t.Load(taskName);
            _currentTask = t;
            return t;
        }
        private void LoadTask()
        {
            if (_currentTask == null) return;
            textBoxSettingJobName.Text = _currentTask.Name;
            textBoxSettingProgramPath.Text = _currentTask.ProgramPath;
            radioButtonRunCyclique.Checked = _currentTask.Cyclic;
            dateTimePickerJobOnceStart.Value = _currentTask.StartDate;
            dateTimePickerJobOnceMaxStart.Value = _currentTask.MaxStartDate;
            radioButtonRunCyclique.Checked = _currentTask.Cyclic;
            textBoxPersonnalCalendarPath.Text = _currentTask.CalendarPath;
            _currentTask.CalendarCountry = comboBoxReferencedCalendar.Text;
            switch (_currentTask.CalType)
            {
                case Task.CalendarType.REFERENCED: radioButtonAppliCalendar.Checked = true; break;
                case Task.CalendarType.PERSO: radioButtonCreateCalendar.Checked = true; break;
                case Task.CalendarType.NOCALENDAR: radioButtonNoCalendar.Checked = true; break;
                case Task.CalendarType.UNKNOW: break;
            }
            checkBoxMonday.Checked = _currentTask.RunMonday;
            checkBoxThuesday.Checked = _currentTask.RunThuesday;
            checkBoxWednesday.Checked = _currentTask.RunWednesday;
            checkBoxThursday.Checked = _currentTask.RunThursday;
            checkBoxFriday.Checked = _currentTask.RunFriday;
            checkBoxSaturday.Checked = _currentTask.RunSaturday;
            checkBoxSunday.Checked = _currentTask.RunSunday;
            numericUpDownTimeSecond.Value = _currentTask.RunSecond;
            numericUpDownTimeMinute.Value = _currentTask.RunMinute;
            numericUpDownTimeHours.Value = _currentTask.RunHour;
            numericUpDownDelayHours.Value = _currentTask.ExecuteInterval;
            switch (_currentTask.ModeError)
            {
                case Task.ErrorMode.NONE: comboBoxErrorMode.Text = "No particular action when job failled"; break;
                case Task.ErrorMode.ONCE: comboBoxErrorMode.Text = "If failled, relaunch once the job"; break;
                case Task.ErrorMode.EACH_1_MIN: comboBoxErrorMode.Text = "If failled wait 1 minute, and relaunch once the job"; break;
                case Task.ErrorMode.EACH_5_MIN: comboBoxErrorMode.Text = "If failled wait 5 minute, and relaunch once the job"; break;
                case Task.ErrorMode.EACH_10_MIN: comboBoxErrorMode.Text = "If failled wait 10 minute, and relaunch once the job"; break;
            }
            switch (_currentTask.ModeMultiInstance)
            {
                case Task.MultiInstanceMode.ONCE: comboBoxMulitInstance.Text = "[ONCE]       Don't launch program if already running"; break;
                case Task.MultiInstanceMode.MULTI: comboBoxMulitInstance.Text = "[MULTI]      Launch program even if the previews still running"; break;
                case Task.MultiInstanceMode.QUEUED: comboBoxMulitInstance.Text = "[QUEUED]   Waiting the end of the current program to launch it"; break;
            }
            comboBoxDelayHoursUnit.Text = _currentTask.ExecuteIntervalTimeUnit.ToString().ToLower();
            //switch (task.ExecuteIntervalTimeUnit)
            //{
            //    case Task.TimeUnit.DAY : comboBoxDelayHoursUnit.Text = "day"; break;
            //    case Task.TimeUnit.HOUR : comboBoxDelayHoursUnit.Text = "hour"; break;
            //    case Task.TimeUnit.MILLISECOND : comboBoxDelayHoursUnit.Text = ""; break;
            //    case Task.TimeUnit.MINUTE : comboBoxDelayHoursUnit.Text = ""; break;
            //    case Task.TimeUnit.MONTH : comboBoxDelayHoursUnit.Text = ""; break;
            //    case Task.TimeUnit.SECONDE : comboBoxDelayHoursUnit.Text = ""; break;
            //    case Task.TimeUnit.WEEK : comboBoxDelayHoursUnit.Text = ""; break;
            //    case Task.TimeUnit.YEAR : comboBoxDelayHoursUnit.Text = ""; break;
            //}
            foreach (ExecutionException ee in _currentTask.Exclusion)
            {
                dataGridViewException.Rows.Add();
                dataGridViewException.Rows[dataGridViewException.Rows.Count - 1].Cells[0].Value = ee.StartDate.ToString("dd/MM/yyyy hh:mm:ss") + " -> " + ee.MaxStartDate.ToString("dd/MM/yyyy hh:mm:ss");
            }
        }
        private void SaveTask()
        {
            Task task = new Task();
            task.Name = textBoxSettingJobName.Text;
            task.ProgramPath = textBoxSettingProgramPath.Text;
            task.Cyclic = radioButtonRunCyclique.Checked;
            if (!task.Cyclic)
            {
                task.StartDate = dateTimePickerJobOnceStart.Value;
                task.MaxStartDate = dateTimePickerJobOnceMaxStart.Value;
                foreach (DataGridViewRow row in dataGridViewManualExecution.Rows)
                {
                    task.AddManualExecution(row.Cells[1].Value.ToString());
                }
            }
            else
            {
                task.CalendarPath = textBoxPersonnalCalendarPath.Text;
                if (radioButtonAppliCalendar.Checked)
                {
                    task.CalType = Task.CalendarType.REFERENCED;
                    task.CalendarCountry = comboBoxReferencedCalendar.Text;
                }
                else if (radioButtonPersonnalCalendar.Checked)
                {
                    task.CalType = Task.CalendarType.PERSO;
                }
                else
                {
                    task.CalType = Task.CalendarType.NOCALENDAR;
                }
                task.RunMonday = checkBoxMonday.Checked;
                task.RunThuesday = checkBoxThuesday.Checked;
                task.RunWednesday = checkBoxWednesday.Checked;
                task.RunThursday = checkBoxThursday.Checked;
                task.RunFriday = checkBoxFriday.Checked;
                task.RunSaturday = checkBoxSaturday.Checked;
                task.RunSunday = checkBoxSunday.Checked;
                
                task.RunSecond = (int)numericUpDownTimeSecond.Value;
                task.RunMinute = (int)numericUpDownTimeMinute.Value;
                task.RunHour = (int)numericUpDownTimeHours.Value;
                task.ExecuteInterval = (int)numericUpDownDelayHours.Value;
                task.ExecuteOnDelay = radioButtonDelayHours.Checked;

                task.MaxRunSecond = (int)numericUpDownMaxDateSecond.Value;
                task.MaxRunMinute = (int)numericUpDownMaxDateMinute.Value;
                task.MaxRunHour = (int)numericUpDownMaxDateHours.Value;
                task.NoMaxStartDate = radioButtonMaxStartAlways.Checked;

                if (comboBoxErrorMode.SelectedItem.ToString().Equals("No particular action when job failled")) task.ModeError = Task.ErrorMode.NONE;
                else if (comboBoxErrorMode.SelectedItem.ToString().Equals("If failled, relaunch once the job")) task.ModeError = Task.ErrorMode.ONCE;
                else if (comboBoxErrorMode.SelectedItem.ToString().Equals("If failled wait 1 minute, and relaunch once the job")) task.ModeError = Task.ErrorMode.EACH_1_MIN;
                else if (comboBoxErrorMode.SelectedItem.ToString().Equals("If failled wait 5 minute, and relaunch once the job")) task.ModeError = Task.ErrorMode.EACH_5_MIN;
                else if (comboBoxErrorMode.SelectedItem.ToString().Equals("If failled wait 10 minute, and relaunch once the job")) task.ModeError = Task.ErrorMode.EACH_10_MIN;

                if (comboBoxMulitInstance.SelectedItem.ToString().Equals("[ONCE]       Don't launch program if already running")) task.ModeMultiInstance = Task.MultiInstanceMode.ONCE;
                else if (comboBoxMulitInstance.SelectedItem.ToString().Equals("[MULTI]      Launch program even if the previews still running")) task.ModeMultiInstance = Task.MultiInstanceMode.MULTI;
                else if (comboBoxMulitInstance.SelectedItem.ToString().Equals("[QUEUED]   Waiting the end of the current program to launch it")) task.ModeMultiInstance = Task.MultiInstanceMode.QUEUED;

                if (!string.IsNullOrEmpty(comboBoxDelayHoursUnit.SelectedText)) task.ExecuteIntervalTimeUnit = (Task.TimeUnit)Enum.Parse(typeof(Task.TimeUnit), comboBoxDelayHoursUnit.SelectedText);
            }
            foreach (DataGridViewRow row in dataGridViewException.Rows)
            {
                ExecutionException ee = new ExecutionException(row.Cells[0].Value.ToString());
                task.Exclusion.Add(ee);
            }
            if (Task.Exist(task)) task.Update();
            else task.Save();
        }
        private void EnableCyclicGroups()
        {
            groupBoxStartDate.Visible = true;
            groupBoxRunningHours.Visible = true;
            groupBoxDay.Visible = true;
            groupBoxExceptions.Visible = true;
            groupBoxJobOnce.Visible = false;
            panelManualList.Visible = false;
        }
        private void EnableOneRunGroups()
        {
            groupBoxStartDate.Visible = false;
            groupBoxRunningHours.Visible = false;
            groupBoxDay.Visible = false;
            groupBoxExceptions.Visible = false;
            groupBoxJobOnce.Visible = true;
            panelManualList.Visible = true;
        }
        private void EnableJobDelay()
        {
            comboBoxDelayHoursUnit.Enabled = true;
            numericUpDownDelayHours.Enabled = true;
            numericUpDownTimeHours.Enabled = false;
            numericUpDownTimeMinute.Enabled = false;
            numericUpDownTimeSecond.Enabled = false;
        }
        private void EnableJobFixedHours()
        {
            comboBoxDelayHoursUnit.Enabled = false;
            numericUpDownDelayHours.Enabled = false;
            numericUpDownTimeHours.Enabled = true;
            numericUpDownTimeMinute.Enabled = true;
            numericUpDownTimeSecond.Enabled = true;
        }
        private void LoadDayPreview()
        {
            //dataGridViewTimePreview.Rows.Clear();
            //for (int i = 0; i < 24; i++)
            //{
            //    dataGridViewTimePreview.Rows.Add();
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[0].Value = i < 10 ? "0" + i.ToString() : i.ToString();
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[0].Style.Font = new Font("Calibri", 7, FontStyle.Regular);
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[1].Value = "...";
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[1].Style.Font = new Font("Calibri", 7, FontStyle.Regular);
            //}
        }
        private void LoadHourPreview()
        {
            //dataGridViewTimePreview.Rows.Clear();
            //for (int i = 0; i < 60; i++)
            //{
            //    dataGridViewTimePreview.Rows.Add();
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[0].Value = i < 10 ? "0" + i.ToString() : i.ToString();
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[0].Style.Font = new Font("Calibri", 7, FontStyle.Regular);
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[1].Value = "...";
            //    dataGridViewTimePreview.Rows[dataGridViewTimePreview.Rows.Count - 1].Cells[1].Style.Font = new Font("Calibri", 7, FontStyle.Regular);
            //}
        }
        private void AddException()
        {
            dataGridViewException.Rows.Add();
            dataGridViewException.Rows[dataGridViewException.Rows.Count - 1].Cells[0].Value =
                dateTimePickerStart.Value.ToShortDateString() + " " + numericUpDownAtStartHour.Text + ":" + numericUpDownAtStartMinutes.Text + ":" + numericUpDownAtStartSeconds.Text + " -> " +
                dateTimePickerEnd.Value.ToShortDateString() + " " + numericUpDownAtEndHours.Text + ":" + numericUpDownAtEndMinutes.Text + ":" + numericUpDownAtEndSeconds.Text;
        }
        private void UpdateHourMinute()
        {
            //if (comboBoxHourMinute.Text == "Day")
            //{
            //    numericUpDownHourDetail.Enabled = false;
            //    LoadDayPreview();
            //}
            //else
            //{
            //    numericUpDownHourDetail.Enabled = true;
            //    LoadHourPreview();
            //}
        }
        private void AddManualExecution()
        {
            string valDate = string.Format("{0} {1} - {2} {3}", dateTimePickerJobOnceStart.Value.ToString("dd/MM/yyyy"), dateTimePickerJobOnceStartTime.Value.ToString("HH:mm:ss tt"), dateTimePickerJobOnceMaxStart.Value.ToString("dd/MM/yyyy"), dateTimePickerJobOnceMaxStartTime.Value.ToString("HH:mm:ss tt"));
            
            object[] dtab = new object[3];
            dtab[0] = DateTime.Parse(dateTimePickerJobOnceStart.Value.ToString("dd/MM/yyyy ") + dateTimePickerJobOnceStartTime.Value.ToString("HH:mm:ss tt"));
            dtab[1] = DateTime.Parse(dateTimePickerJobOnceMaxStart.Value.ToString("dd/MM/yyyy ") + dateTimePickerJobOnceMaxStartTime.Value.ToString("HH:mm:ss tt"));
            dtab[2] = valDate;
            _currentTask.ManualExecution.Add(dtab);

            dataGridViewManualExecution.Rows.Add();
            dataGridViewManualExecution.Rows[dataGridViewManualExecution.Rows.Count - 1].Cells[1].Value = valDate;
        }
        private void RemoveManualExecution(int index)
        {
            DateTime[] dtab = new DateTime[2];
            dtab[0] = dateTimePickerJobOnceStart.Value;
            dtab[1] = dateTimePickerJobOnceMaxStart.Value;

            _currentTask.ManualExecution.RemoveAll(x => x[2].ToString().Equals(dataGridViewManualExecution.Rows[index].Cells[1].Value.ToString()));
            dataGridViewManualExecution.Rows.Remove(dataGridViewManualExecution.Rows[index]);
        }
        private void SeeCalendar()
        {
            Window formMonth = new Window();
            formMonth.Height = 560;
            formMonth.Width = 625;
            formMonth.StartPosition = FormStartPosition.CenterParent;
            formMonth.Text = "Calendar " + DateTime.Now.Year;

            HolidayCalculator hc = GetCalendar();
            CalendarView cv = new CalendarView(DateTime.Now.Year, hc);
            cv.Dock = DockStyle.Fill;
            if (_currentTask != null) cv.ExecutionDates = _currentTask.GetListExecution(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year + 1, 1, 1), hc);

            formMonth.AddControl(cv);
            formMonth.ShowDialog();
        }
        private void LoadCalendarDayPreview()
        {
            Window formDay = new Window();
            formDay.Height = 592;
            formDay.Width = 380;
            formDay.StartPosition = FormStartPosition.CenterParent;
            formDay.Text = "Calendar daily";

            _holidays = GetCalendar();
            DayView dv = new DayView(DateTime.Now);
            dv.Dock = DockStyle.Fill;
            if (_currentTask != null) dv.Refresh(_currentTask.GetListExecutionTime(DateTime.Now, _holidays));
            dv.DayChanged += dv_DayChanged;

            formDay.AddControl(dv);
            formDay.ShowDialog();
        }
        private HolidayCalculator GetCalendar()
        {
            switch (_currentTask.CalType)
            {
                case Task.CalendarType.REFERENCED:
                    return HolidayCalculator.GetCalendar(_currentTask.CalendarCountry.ToLower());
                case Task.CalendarType.PERSO:
                    MessageBox.Show("TODO !");
                    return new HolidayCalculator();
                case Task.CalendarType.UNKNOW:
                case Task.CalendarType.NOCALENDAR:
                default:
                    return new HolidayCalculator();
            }
        }
        #endregion

        #region Event
        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveTask();               
        }
        private void buttonRevert_Click(object sender, EventArgs e)
        {
            OnCancelRequested();
        }
        private void dataGridViewException_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dataGridViewException.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void dataGridViewManualExecution_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                RemoveManualExecution(e.RowIndex);
            }
        }
        private void comboBoxHourMinute_TextChanged(object sender, EventArgs e)
        {
            UpdateHourMinute();
        }
        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxSettingConfig.Text = ofd.FileName;
            }
        }
        private void buttonBrowsePersonnalCalendar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxPersonnalCalendarPath.Text = ofd.FileName;
            }
        }
        private void radioButtonModeCyclique_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRunCyclique.Checked)
            {
                EnableCyclicGroups();
            }
            else
            {
                EnableOneRunGroups();
            }
        }
        private void radioButtonTimeEach_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTimeEach.Checked)
            {
                numericUpDownTimeSecond.Enabled = true;
                numericUpDownTimeMinute.Enabled = true;
                numericUpDownTimeHours.Enabled = true;
            }
            else
            {
                numericUpDownTimeSecond.Enabled = false;
                numericUpDownTimeMinute.Enabled = false;
                numericUpDownTimeHours.Enabled = false;
            }
        }
        private void radioButtonDelayHours_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDelayHours.Checked)
            {
                numericUpDownDelayHours.Enabled = true;
                comboBoxDelayHoursUnit.Enabled = true;
            }
            else
            {
                numericUpDownDelayHours.Enabled = false;
                comboBoxDelayHoursUnit.Enabled = false;
            }
        }
        private void radioButtonRunCyclique_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRunCyclique.Checked) EnableCyclicGroups();
            else EnableOneRunGroups();
            _currentTask.Cyclic = radioButtonRunCyclique.Checked;
        }
        private void checkBoxNewJob_CheckedChanged(object sender, EventArgs e)
        {
            labelJobSelection.Enabled = !checkBoxNewJob.Checked;
            comboBoxJobSelection.Enabled = !checkBoxNewJob.Checked;
            LoadTask();
        }
        private void buttonProgram_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxSettingProgramPath.Text = fd.FileName;
            }
        }
        private void buttonSettingLoadConfig_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxSettingConfig.Text = fd.FileName;
            }
        }
        private void radioButtonDelayHours_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonDelayHours.Checked) EnableJobDelay();
            else EnableJobFixedHours();
        }
        private void buttonExceptionAdd_Click(object sender, EventArgs e)
        {
            AddException();
        }
        private void comboBoxJobSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentTask = GetTask(comboBoxJobSelection.Text);
            LoadTask();
        }
        private void radioButtonMaxStartDelay_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxDateSecond.Enabled = radioButtonMaxStartDelay.Checked;
            numericUpDownMaxDateMinute.Enabled = radioButtonMaxStartDelay.Checked;
            numericUpDownMaxDateHours.Enabled = radioButtonMaxStartDelay.Checked;
        }
        private void buttonAddManualExecution_Click(object sender, EventArgs e)
        {
            AddManualExecution();
        }
        private void buttonSeeInCalendar_Click(object sender, EventArgs e)
        {
            SeeCalendar();
        }
        private void comboBoxReferencedCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonAppliCalendar.Checked)
            {
                int index = imageListCountry.Images.IndexOfKey(comboBoxReferencedCalendar.Text.Replace(' ', '_'));
                if (index != -1)
                {
                    pictureBoxCountry.Image = imageListCountry.Images[index];
                    _currentTask.CalendarCountry = comboBoxReferencedCalendar.Text;
                    _currentTask.CalType = Task.CalendarType.REFERENCED;
                    LoadRegions();
                }
                else
                {
                    pictureBoxCountry.Image = imageListCountry.Images[imageListCountry.Images.IndexOfKey("NewCalendar")];
                    _currentTask.CalType = Task.CalendarType.PERSO;
                }
            }
        }
        private void radioButtonPersonnalCalendar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPersonnalCalendar.Checked)
            {
                pictureBoxCountry.Image = imageListCountry.Images[imageListCountry.Images.IndexOfKey("PersoCalendar")];
                _currentTask.CalType = Task.CalendarType.PERSO;
            }
        }
        private void radioButtonNoCalendar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNoCalendar.Checked)
            {
                pictureBoxCountry.Image = imageListCountry.Images[imageListCountry.Images.IndexOfKey("NoCalendar")];
                _currentTask.CalType = Task.CalendarType.NOCALENDAR;
            }
        }
        private void radioButtonCreateCalendar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCreateCalendar.Checked)
            {
                pictureBoxCountry.Image = imageListCountry.Images[imageListCountry.Images.IndexOfKey("NewCalendar")];
                _currentTask.CalType = Task.CalendarType.PERSO;
                OnRequestHappen("NewPersonnalCalendar");
            }
        }
        private void radioButtonAppliCalendar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAppliCalendar.Checked)
            {
                comboBoxReferencedCalendar.Enabled = true;
                int index = imageListCountry.Images.IndexOfKey(comboBoxReferencedCalendar.Text);
                if (index != -1)
                {
                    pictureBoxCountry.Image = imageListCountry.Images[index];
                    _currentTask.CalendarCountry = comboBoxReferencedCalendar.Text;
                    _currentTask.CalType = Task.CalendarType.REFERENCED;
                }
                else pictureBoxCountry.Image = imageListCountry.Images[imageListCountry.Images.IndexOfKey("NewCalendar")];
            }
            else
            {
                comboBoxReferencedCalendar.Enabled = false;
            }
        }
        private void checkBoxOpenDay_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            int num = int.Parse(cb.Name.Replace("checkBoxOpenDay", string.Empty));
            if (num > 90) num = (num - 90) * -1;
            if (cb.Checked)
            {
                _currentTask.RunOpenDaysList.Add(num);
            }
            else
            {
                _currentTask.RunOpenDaysList.Remove(num);
            }
        }
        private void checkBoxDayNum_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            int num = int.Parse(cb.Name.Replace("checkBoxDayNum", string.Empty));
            if (cb.Checked)
            {
                _currentTask.RunDaysList.Add(num);
            }
            else
            {
                _currentTask.RunDaysList.Remove(num);
            }
        }
        private void checkBoxCalendarAllNonOpenDays_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunNonOpenDays = checkBoxCalendarAllNonOpenDays.Checked;
        }
        private void checkBoxCalendarAllOpenDay_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunOpenDays = checkBoxCalendarAllOpenDay.Checked;
        }
        private void checkBoxSunday_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunSunday = checkBoxSunday.Checked;
        }
        private void checkBoxThursday_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunThursday = checkBoxThursday.Checked;
        }
        private void checkBoxWednesday_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunWednesday = checkBoxWednesday.Checked;
        }
        private void checkBoxThuesday_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunThuesday = checkBoxThuesday.Checked;
        }
        private void checkBoxSaturday_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunSaturday = checkBoxSaturday.Checked;
        }
        private void checkBoxFriday_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunFriday = checkBoxFriday.Checked;
        }
        private void checkBoxMonday_CheckedChanged(object sender, EventArgs e)
        {   
            _currentTask.RunMonday = checkBoxMonday.Checked;
        }
        private void buttonDayPreview_Click(object sender, EventArgs e)
        {
            LoadCalendarDayPreview();
        }
        private void dv_DayChanged(DayView dv, DateTime dt)
        {
            if (_currentTask != null) dv.Refresh(_currentTask.GetListExecutionTime(dt, _holidays));
        }
        private void checkBoxRunHour_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunHourEnabled = checkBoxRunHour.Checked;
        }
        private void checkBoxRunMinute_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunMinuteEnabled = checkBoxRunMinute.Checked;
        }
        private void checkBoxRunSecond_CheckedChanged(object sender, EventArgs e)
        {
            _currentTask.RunSecondEnabled = checkBoxRunSecond.Checked;
        }
        #endregion
    }
}
