namespace Droid.Scheduler.UI
{
    partial class Month
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMonthName = new System.Windows.Forms.Label();
            this._dataGridViewCalendar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMonthName
            // 
            this.labelMonthName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelMonthName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMonthName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonthName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelMonthName.Location = new System.Drawing.Point(0, 0);
            this.labelMonthName.Name = "labelMonthName";
            this.labelMonthName.Size = new System.Drawing.Size(150, 23);
            this.labelMonthName.TabIndex = 0;
            this.labelMonthName.Text = "Month";
            this.labelMonthName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _dataGridViewCalendar
            // 
            this._dataGridViewCalendar.AllowUserToAddRows = false;
            this._dataGridViewCalendar.AllowUserToDeleteRows = false;
            this._dataGridViewCalendar.AllowUserToOrderColumns = true;
            this._dataGridViewCalendar.AllowUserToResizeColumns = false;
            this._dataGridViewCalendar.AllowUserToResizeRows = false;
            this._dataGridViewCalendar.BackgroundColor = System.Drawing.Color.Gray;
            this._dataGridViewCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewCalendar.GridColor = System.Drawing.Color.Gray;
            this._dataGridViewCalendar.Location = new System.Drawing.Point(0, 23);
            this._dataGridViewCalendar.Name = "_dataGridViewCalendar";
            this._dataGridViewCalendar.RowHeadersVisible = false;
            this._dataGridViewCalendar.Size = new System.Drawing.Size(150, 146);
            this._dataGridViewCalendar.TabIndex = 1;
            // 
            // Month
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dataGridViewCalendar);
            this.Controls.Add(this.labelMonthName);
            this.Name = "Month";
            this.Size = new System.Drawing.Size(150, 169);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCalendar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMonthName;
        private System.Windows.Forms.DataGridView _dataGridViewCalendar;
    }
}
