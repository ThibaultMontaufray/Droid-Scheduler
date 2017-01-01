namespace Droid_scheduler
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.panelScheduler1 = new Droid_scheduler.PanelScheduler();
            this.tabControlScheduler = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.jobSetting1 = new Droid_scheduler.TaskSetting();
            this.tabPageCreatePersonnalCalendar = new System.Windows.Forms.TabPage();
            this.splitContainerPersonnalCalendar = new System.Windows.Forms.SplitContainer();
            this.buttonPersoCalCancel = new System.Windows.Forms.Button();
            this.buttonPersoCalApply = new System.Windows.Forms.Button();
            this.checkBoxDefaultCalendar = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tabPageExecutionView = new System.Windows.Forms.TabPage();
            this.splitContainerExecution = new System.Windows.Forms.SplitContainer();
            this.groupBoxDate = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.groupBoxNames = new System.Windows.Forms.GroupBox();
            this.textBoxJobName = new System.Windows.Forms.TextBox();
            this.labelJobName = new System.Windows.Forms.Label();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxFrozen = new System.Windows.Forms.CheckBox();
            this.checkBoxAborted = new System.Windows.Forms.CheckBox();
            this.checkBoxWaiting = new System.Windows.Forms.CheckBox();
            this.checkBoxIncidented = new System.Windows.Forms.CheckBox();
            this.checkBoxRunning = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelScheduler1.SuspendLayout();
            this.tabControlScheduler.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tabPageCreatePersonnalCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPersonnalCalendar)).BeginInit();
            this.splitContainerPersonnalCalendar.Panel1.SuspendLayout();
            this.splitContainerPersonnalCalendar.Panel2.SuspendLayout();
            this.splitContainerPersonnalCalendar.SuspendLayout();
            this.tabPageExecutionView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExecution)).BeginInit();
            this.splitContainerExecution.Panel1.SuspendLayout();
            this.splitContainerExecution.Panel2.SuspendLayout();
            this.splitContainerExecution.SuspendLayout();
            this.groupBoxDate.SuspendLayout();
            this.groupBoxNames.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Size = new System.Drawing.Size(86, 13);
            this.labelTitle.Text = "Quick Scheduler";
            // 
            // panelScheduler1
            // 
            this.panelScheduler1.BackColor = System.Drawing.Color.Black;
            this.panelScheduler1.Controls.Add(this.tabControlScheduler);
            this.panelScheduler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScheduler1.Location = new System.Drawing.Point(0, 24);
            this.panelScheduler1.Name = "panelScheduler1";
            this.panelScheduler1.Size = new System.Drawing.Size(904, 489);
            this.panelScheduler1.TabIndex = 0;
            // 
            // tabControlScheduler
            // 
            this.tabControlScheduler.Controls.Add(this.tabPageSettings);
            this.tabControlScheduler.Controls.Add(this.tabPageCreatePersonnalCalendar);
            this.tabControlScheduler.Controls.Add(this.tabPageExecutionView);
            this.tabControlScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlScheduler.Location = new System.Drawing.Point(0, 0);
            this.tabControlScheduler.Name = "tabControlScheduler";
            this.tabControlScheduler.SelectedIndex = 0;
            this.tabControlScheduler.Size = new System.Drawing.Size(904, 489);
            this.tabControlScheduler.TabIndex = 1;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.jobSetting1);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(896, 463);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Jobs settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // jobSetting1
            // 
            this.jobSetting1.BackColor = System.Drawing.Color.Gray;
            this.jobSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobSetting1.Location = new System.Drawing.Point(3, 3);
            this.jobSetting1.MinimumSize = new System.Drawing.Size(699, 635);
            this.jobSetting1.Name = "jobSetting1";
            this.jobSetting1.Size = new System.Drawing.Size(890, 635);
            this.jobSetting1.TabIndex = 0;
            this.jobSetting1.Tasks = ((System.Collections.Generic.List<string[]>)(resources.GetObject("jobSetting1.Tasks")));
            // 
            // tabPageCreatePersonnalCalendar
            // 
            this.tabPageCreatePersonnalCalendar.Controls.Add(this.splitContainerPersonnalCalendar);
            this.tabPageCreatePersonnalCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreatePersonnalCalendar.Name = "tabPageCreatePersonnalCalendar";
            this.tabPageCreatePersonnalCalendar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreatePersonnalCalendar.Size = new System.Drawing.Size(896, 463);
            this.tabPageCreatePersonnalCalendar.TabIndex = 2;
            this.tabPageCreatePersonnalCalendar.Text = "Calendar";
            this.tabPageCreatePersonnalCalendar.UseVisualStyleBackColor = true;
            // 
            // splitContainerPersonnalCalendar
            // 
            this.splitContainerPersonnalCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPersonnalCalendar.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerPersonnalCalendar.Location = new System.Drawing.Point(3, 3);
            this.splitContainerPersonnalCalendar.Name = "splitContainerPersonnalCalendar";
            // 
            // splitContainerPersonnalCalendar.Panel1
            // 
            this.splitContainerPersonnalCalendar.Panel1.Controls.Add(this.buttonPersoCalCancel);
            this.splitContainerPersonnalCalendar.Panel1.Controls.Add(this.buttonPersoCalApply);
            this.splitContainerPersonnalCalendar.Panel1.Controls.Add(this.checkBoxDefaultCalendar);
            this.splitContainerPersonnalCalendar.Panel1.Controls.Add(this.comboBox2);
            // 
            // splitContainerPersonnalCalendar.Panel2
            // 
            this.splitContainerPersonnalCalendar.Panel2.Controls.Add(this.monthCalendar1);
            this.splitContainerPersonnalCalendar.Size = new System.Drawing.Size(890, 457);
            this.splitContainerPersonnalCalendar.SplitterDistance = 233;
            this.splitContainerPersonnalCalendar.TabIndex = 0;
            // 
            // buttonPersoCalCancel
            // 
            this.buttonPersoCalCancel.Location = new System.Drawing.Point(117, 56);
            this.buttonPersoCalCancel.Name = "buttonPersoCalCancel";
            this.buttonPersoCalCancel.Size = new System.Drawing.Size(108, 23);
            this.buttonPersoCalCancel.TabIndex = 6;
            this.buttonPersoCalCancel.Text = "Cancel";
            this.buttonPersoCalCancel.UseVisualStyleBackColor = true;
            this.buttonPersoCalCancel.Click += new System.EventHandler(this.buttonPersoCalCancel_Click);
            // 
            // buttonPersoCalApply
            // 
            this.buttonPersoCalApply.Location = new System.Drawing.Point(5, 56);
            this.buttonPersoCalApply.Name = "buttonPersoCalApply";
            this.buttonPersoCalApply.Size = new System.Drawing.Size(108, 23);
            this.buttonPersoCalApply.TabIndex = 5;
            this.buttonPersoCalApply.Text = "Create";
            this.buttonPersoCalApply.UseVisualStyleBackColor = true;
            this.buttonPersoCalApply.Click += new System.EventHandler(this.buttonPersoCalApply_Click);
            // 
            // checkBoxDefaultCalendar
            // 
            this.checkBoxDefaultCalendar.AutoSize = true;
            this.checkBoxDefaultCalendar.Location = new System.Drawing.Point(5, 6);
            this.checkBoxDefaultCalendar.Name = "checkBoxDefaultCalendar";
            this.checkBoxDefaultCalendar.Size = new System.Drawing.Size(133, 17);
            this.checkBoxDefaultCalendar.TabIndex = 4;
            this.checkBoxDefaultCalendar.Text = "Use a default calendar";
            this.checkBoxDefaultCalendar.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(5, 29);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(220, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 3);
            this.monthCalendar1.Location = new System.Drawing.Point(0, 6);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // tabPageExecutionView
            // 
            this.tabPageExecutionView.Controls.Add(this.splitContainerExecution);
            this.tabPageExecutionView.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecutionView.Name = "tabPageExecutionView";
            this.tabPageExecutionView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExecutionView.Size = new System.Drawing.Size(896, 463);
            this.tabPageExecutionView.TabIndex = 1;
            this.tabPageExecutionView.Text = "Executions view";
            this.tabPageExecutionView.UseVisualStyleBackColor = true;
            // 
            // splitContainerExecution
            // 
            this.splitContainerExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerExecution.Location = new System.Drawing.Point(3, 3);
            this.splitContainerExecution.Name = "splitContainerExecution";
            // 
            // splitContainerExecution.Panel1
            // 
            this.splitContainerExecution.Panel1.Controls.Add(this.groupBoxDate);
            this.splitContainerExecution.Panel1.Controls.Add(this.buttonFilter);
            this.splitContainerExecution.Panel1.Controls.Add(this.groupBoxNames);
            this.splitContainerExecution.Panel1.Controls.Add(this.groupBoxStatus);
            this.splitContainerExecution.Panel1MinSize = 275;
            // 
            // splitContainerExecution.Panel2
            // 
            this.splitContainerExecution.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainerExecution.Size = new System.Drawing.Size(890, 457);
            this.splitContainerExecution.SplitterDistance = 348;
            this.splitContainerExecution.TabIndex = 0;
            // 
            // groupBoxDate
            // 
            this.groupBoxDate.Controls.Add(this.dateTimePicker2);
            this.groupBoxDate.Controls.Add(this.label1);
            this.groupBoxDate.Controls.Add(this.dateTimePicker1);
            this.groupBoxDate.Controls.Add(this.labelStartDate);
            this.groupBoxDate.Location = new System.Drawing.Point(6, 149);
            this.groupBoxDate.Name = "groupBoxDate";
            this.groupBoxDate.Size = new System.Drawing.Size(262, 86);
            this.groupBoxDate.TabIndex = 7;
            this.groupBoxDate.TabStop = false;
            this.groupBoxDate.Text = "Jobs names";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(68, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.Value = new System.DateTime(2014, 12, 14, 9, 13, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "End date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(68, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(6, 23);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(53, 13);
            this.labelStartDate.TabIndex = 0;
            this.labelStartDate.Text = "Start date";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(192, 241);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 7;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            // 
            // groupBoxNames
            // 
            this.groupBoxNames.Controls.Add(this.textBoxJobName);
            this.groupBoxNames.Controls.Add(this.labelJobName);
            this.groupBoxNames.Location = new System.Drawing.Point(5, 81);
            this.groupBoxNames.Name = "groupBoxNames";
            this.groupBoxNames.Size = new System.Drawing.Size(262, 62);
            this.groupBoxNames.TabIndex = 6;
            this.groupBoxNames.TabStop = false;
            this.groupBoxNames.Text = "Jobs names";
            // 
            // textBoxJobName
            // 
            this.textBoxJobName.Location = new System.Drawing.Point(68, 19);
            this.textBoxJobName.Name = "textBoxJobName";
            this.textBoxJobName.Size = new System.Drawing.Size(188, 20);
            this.textBoxJobName.TabIndex = 1;
            // 
            // labelJobName
            // 
            this.labelJobName.AutoSize = true;
            this.labelJobName.Location = new System.Drawing.Point(3, 22);
            this.labelJobName.Name = "labelJobName";
            this.labelJobName.Size = new System.Drawing.Size(35, 13);
            this.labelJobName.TabIndex = 0;
            this.labelJobName.Text = "Name";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.checkBox1);
            this.groupBoxStatus.Controls.Add(this.checkBoxFrozen);
            this.groupBoxStatus.Controls.Add(this.checkBoxAborted);
            this.groupBoxStatus.Controls.Add(this.checkBoxWaiting);
            this.groupBoxStatus.Controls.Add(this.checkBoxIncidented);
            this.groupBoxStatus.Controls.Add(this.checkBoxRunning);
            this.groupBoxStatus.Location = new System.Drawing.Point(5, 3);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(262, 72);
            this.groupBoxStatus.TabIndex = 1;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(166, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Terminated";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBoxFrozen
            // 
            this.checkBoxFrozen.AutoSize = true;
            this.checkBoxFrozen.Location = new System.Drawing.Point(166, 19);
            this.checkBoxFrozen.Name = "checkBoxFrozen";
            this.checkBoxFrozen.Size = new System.Drawing.Size(58, 17);
            this.checkBoxFrozen.TabIndex = 4;
            this.checkBoxFrozen.Text = "Frozen";
            this.checkBoxFrozen.UseVisualStyleBackColor = true;
            // 
            // checkBoxAborted
            // 
            this.checkBoxAborted.AutoSize = true;
            this.checkBoxAborted.Location = new System.Drawing.Point(93, 42);
            this.checkBoxAborted.Name = "checkBoxAborted";
            this.checkBoxAborted.Size = new System.Drawing.Size(63, 17);
            this.checkBoxAborted.TabIndex = 3;
            this.checkBoxAborted.Text = "Aborted";
            this.checkBoxAborted.UseVisualStyleBackColor = true;
            // 
            // checkBoxWaiting
            // 
            this.checkBoxWaiting.AutoSize = true;
            this.checkBoxWaiting.Location = new System.Drawing.Point(93, 19);
            this.checkBoxWaiting.Name = "checkBoxWaiting";
            this.checkBoxWaiting.Size = new System.Drawing.Size(62, 17);
            this.checkBoxWaiting.TabIndex = 2;
            this.checkBoxWaiting.Text = "Waiting";
            this.checkBoxWaiting.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncidented
            // 
            this.checkBoxIncidented.AutoSize = true;
            this.checkBoxIncidented.Location = new System.Drawing.Point(6, 42);
            this.checkBoxIncidented.Name = "checkBoxIncidented";
            this.checkBoxIncidented.Size = new System.Drawing.Size(76, 17);
            this.checkBoxIncidented.TabIndex = 1;
            this.checkBoxIncidented.Text = "Incidented";
            this.checkBoxIncidented.UseVisualStyleBackColor = true;
            // 
            // checkBoxRunning
            // 
            this.checkBoxRunning.AutoSize = true;
            this.checkBoxRunning.Location = new System.Drawing.Point(6, 19);
            this.checkBoxRunning.Name = "checkBoxRunning";
            this.checkBoxRunning.Size = new System.Drawing.Size(66, 17);
            this.checkBoxRunning.TabIndex = 0;
            this.checkBoxRunning.Text = "Running";
            this.checkBoxRunning.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(538, 457);
            this.dataGridView1.TabIndex = 0;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 513);
            this.Controls.Add(this.panelScheduler1);
            this.MaximumSize = new System.Drawing.Size(904, 513);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Scheduler";
            this.Controls.SetChildIndex(this.panelScheduler1, 0);
            this.panelScheduler1.ResumeLayout(false);
            this.tabControlScheduler.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageCreatePersonnalCalendar.ResumeLayout(false);
            this.splitContainerPersonnalCalendar.Panel1.ResumeLayout(false);
            this.splitContainerPersonnalCalendar.Panel1.PerformLayout();
            this.splitContainerPersonnalCalendar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPersonnalCalendar)).EndInit();
            this.splitContainerPersonnalCalendar.ResumeLayout(false);
            this.tabPageExecutionView.ResumeLayout(false);
            this.splitContainerExecution.Panel1.ResumeLayout(false);
            this.splitContainerExecution.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExecution)).EndInit();
            this.splitContainerExecution.ResumeLayout(false);
            this.groupBoxDate.ResumeLayout(false);
            this.groupBoxDate.PerformLayout();
            this.groupBoxNames.ResumeLayout(false);
            this.groupBoxNames.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelScheduler panelScheduler1;
        private System.Windows.Forms.TabControl tabControlScheduler;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageCreatePersonnalCalendar;
        private System.Windows.Forms.SplitContainer splitContainerPersonnalCalendar;
        private System.Windows.Forms.Button buttonPersoCalCancel;
        private System.Windows.Forms.Button buttonPersoCalApply;
        private System.Windows.Forms.CheckBox checkBoxDefaultCalendar;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TabPage tabPageExecutionView;
        private System.Windows.Forms.SplitContainer splitContainerExecution;
        private System.Windows.Forms.GroupBox groupBoxDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.GroupBox groupBoxNames;
        private System.Windows.Forms.TextBox textBoxJobName;
        private System.Windows.Forms.Label labelJobName;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxFrozen;
        private System.Windows.Forms.CheckBox checkBoxAborted;
        private System.Windows.Forms.CheckBox checkBoxWaiting;
        private System.Windows.Forms.CheckBox checkBoxIncidented;
        private System.Windows.Forms.CheckBox checkBoxRunning;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TaskSetting jobSetting1;
    }
}