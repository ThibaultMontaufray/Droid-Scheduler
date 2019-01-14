namespace Droid_calendar
{
    partial class CalendarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.NumUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.NumUpDownMonth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelOpenDay = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.trackBarOpenDay = new System.Windows.Forms.TrackBar();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.textBoxHolidaysList = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpenDay)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NumUpDownYear);
            this.splitContainer1.Panel1.Controls.Add(this.NumUpDownMonth);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar);
            this.splitContainer1.Panel1.Controls.Add(this.labelMonth);
            this.splitContainer1.Panel1.Controls.Add(this.labelOpenDay);
            this.splitContainer1.Panel1.Controls.Add(this.labelYear);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarOpenDay);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxCountry);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxHolidaysList);
            this.splitContainer1.Size = new System.Drawing.Size(663, 313);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            // 
            // NumUpDownYear
            // 
            this.NumUpDownYear.Location = new System.Drawing.Point(87, 61);
            this.NumUpDownYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.NumUpDownYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.NumUpDownYear.Name = "NumUpDownYear";
            this.NumUpDownYear.Size = new System.Drawing.Size(150, 20);
            this.NumUpDownYear.TabIndex = 10;
            this.NumUpDownYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // NumUpDownMonth
            // 
            this.NumUpDownMonth.Location = new System.Drawing.Point(87, 34);
            this.NumUpDownMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.NumUpDownMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownMonth.Name = "NumUpDownMonth";
            this.NumUpDownMonth.Size = new System.Drawing.Size(150, 20);
            this.NumUpDownMonth.TabIndex = 9;
            this.NumUpDownMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Country : ";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(9, 150);
            this.monthCalendar.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowToday = false;
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 8;
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(12, 36);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(46, 13);
            this.labelMonth.TabIndex = 2;
            this.labelMonth.Text = "Month : ";
            // 
            // labelOpenDay
            // 
            this.labelOpenDay.AutoSize = true;
            this.labelOpenDay.Location = new System.Drawing.Point(13, 92);
            this.labelOpenDay.Name = "labelOpenDay";
            this.labelOpenDay.Size = new System.Drawing.Size(89, 13);
            this.labelOpenDay.TabIndex = 7;
            this.labelOpenDay.Text = "Open day        : 1";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(12, 63);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(38, 13);
            this.labelYear.TabIndex = 3;
            this.labelYear.Text = "Year : ";
            // 
            // trackBarOpenDay
            // 
            this.trackBarOpenDay.Location = new System.Drawing.Point(1, 117);
            this.trackBarOpenDay.Minimum = 1;
            this.trackBarOpenDay.Name = "trackBarOpenDay";
            this.trackBarOpenDay.Size = new System.Drawing.Size(236, 45);
            this.trackBarOpenDay.TabIndex = 6;
            this.trackBarOpenDay.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarOpenDay.Value = 1;
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Items.AddRange(new object[] {
            "Allemagne",
            "Belgique",
            "Bolivie",
            "Canada",
            "Etats Unis",
            "France",
            "India",
            "Irland",
            "Tunisie",
            "Royaumes Unis",
            "Russie"});
            this.comboBoxCountry.Location = new System.Drawing.Point(87, 6);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(150, 21);
            this.comboBoxCountry.TabIndex = 4;
            // 
            // textBoxHolidaysList
            // 
            this.textBoxHolidaysList.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxHolidaysList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHolidaysList.Location = new System.Drawing.Point(0, 0);
            this.textBoxHolidaysList.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxHolidaysList.Multiline = true;
            this.textBoxHolidaysList.Name = "textBoxHolidaysList";
            this.textBoxHolidaysList.ReadOnly = true;
            this.textBoxHolidaysList.Size = new System.Drawing.Size(409, 313);
            this.textBoxHolidaysList.TabIndex = 0;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 313);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpenDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.TrackBar trackBarOpenDay;
        private System.Windows.Forms.Label labelOpenDay;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.NumericUpDown NumUpDownMonth;
        private System.Windows.Forms.NumericUpDown NumUpDownYear;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxHolidaysList;
    }
}
