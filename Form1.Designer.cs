
namespace C969_PA_Worun_Sukhtipyaroge
{
    partial class Form1
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
            this.AppointmentGrid = new System.Windows.Forms.DataGridView();
            this.CustomerDataGrid = new System.Windows.Forms.DataGridView();
            this.CustIDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddCustButton = new System.Windows.Forms.Button();
            this.UpdateCustButton = new System.Windows.Forms.Button();
            this.DeleteCustButton = new System.Windows.Forms.Button();
            this.AddApptButton = new System.Windows.Forms.Button();
            this.DeleteApptButton = new System.Windows.Forms.Button();
            this.UpdateApptButton = new System.Windows.Forms.Button();
            this.CustLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AllRadio = new System.Windows.Forms.RadioButton();
            this.MonthRadio = new System.Windows.Forms.RadioButton();
            this.WeekRadio = new System.Windows.Forms.RadioButton();
            this.AllUserCheck = new System.Windows.Forms.CheckBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ReportChoices = new System.Windows.Forms.ComboBox();
            this.GenerateReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AppointmentGrid
            // 
            this.AppointmentGrid.AllowUserToAddRows = false;
            this.AppointmentGrid.AllowUserToDeleteRows = false;
            this.AppointmentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppointmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentGrid.Location = new System.Drawing.Point(460, 174);
            this.AppointmentGrid.MultiSelect = false;
            this.AppointmentGrid.Name = "AppointmentGrid";
            this.AppointmentGrid.ReadOnly = true;
            this.AppointmentGrid.RowHeadersVisible = false;
            this.AppointmentGrid.RowHeadersWidth = 62;
            this.AppointmentGrid.RowTemplate.Height = 28;
            this.AppointmentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppointmentGrid.Size = new System.Drawing.Size(1158, 282);
            this.AppointmentGrid.TabIndex = 2;
            // 
            // CustomerDataGrid
            // 
            this.CustomerDataGrid.AllowUserToAddRows = false;
            this.CustomerDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustIDCol,
            this.CustNameCol});
            this.CustomerDataGrid.Location = new System.Drawing.Point(43, 174);
            this.CustomerDataGrid.MultiSelect = false;
            this.CustomerDataGrid.Name = "CustomerDataGrid";
            this.CustomerDataGrid.ReadOnly = true;
            this.CustomerDataGrid.RowHeadersVisible = false;
            this.CustomerDataGrid.RowHeadersWidth = 62;
            this.CustomerDataGrid.RowTemplate.Height = 28;
            this.CustomerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerDataGrid.Size = new System.Drawing.Size(360, 282);
            this.CustomerDataGrid.TabIndex = 3;
            // 
            // CustIDCol
            // 
            this.CustIDCol.HeaderText = "Cust. ID";
            this.CustIDCol.MinimumWidth = 8;
            this.CustIDCol.Name = "CustIDCol";
            this.CustIDCol.ReadOnly = true;
            // 
            // CustNameCol
            // 
            this.CustNameCol.HeaderText = "Name";
            this.CustNameCol.MinimumWidth = 8;
            this.CustNameCol.Name = "CustNameCol";
            this.CustNameCol.ReadOnly = true;
            // 
            // AddCustButton
            // 
            this.AddCustButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustButton.Location = new System.Drawing.Point(43, 477);
            this.AddCustButton.Name = "AddCustButton";
            this.AddCustButton.Size = new System.Drawing.Size(105, 69);
            this.AddCustButton.TabIndex = 4;
            this.AddCustButton.Text = "ADD";
            this.AddCustButton.UseVisualStyleBackColor = true;
            this.AddCustButton.Click += new System.EventHandler(this.AddCustButton_Click);
            // 
            // UpdateCustButton
            // 
            this.UpdateCustButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateCustButton.Location = new System.Drawing.Point(170, 477);
            this.UpdateCustButton.Name = "UpdateCustButton";
            this.UpdateCustButton.Size = new System.Drawing.Size(105, 69);
            this.UpdateCustButton.TabIndex = 5;
            this.UpdateCustButton.Text = "UPDATE";
            this.UpdateCustButton.UseVisualStyleBackColor = true;
            this.UpdateCustButton.Click += new System.EventHandler(this.UpdateCustButton_Click);
            // 
            // DeleteCustButton
            // 
            this.DeleteCustButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCustButton.Location = new System.Drawing.Point(298, 477);
            this.DeleteCustButton.Name = "DeleteCustButton";
            this.DeleteCustButton.Size = new System.Drawing.Size(105, 69);
            this.DeleteCustButton.TabIndex = 6;
            this.DeleteCustButton.Text = "DELETE";
            this.DeleteCustButton.UseVisualStyleBackColor = true;
            this.DeleteCustButton.Click += new System.EventHandler(this.DeleteCustButton_Click);
            // 
            // AddApptButton
            // 
            this.AddApptButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddApptButton.Location = new System.Drawing.Point(1224, 477);
            this.AddApptButton.Name = "AddApptButton";
            this.AddApptButton.Size = new System.Drawing.Size(105, 69);
            this.AddApptButton.TabIndex = 7;
            this.AddApptButton.Text = "ADD";
            this.AddApptButton.UseVisualStyleBackColor = true;
            this.AddApptButton.Click += new System.EventHandler(this.AddApptButton_Click);
            // 
            // DeleteApptButton
            // 
            this.DeleteApptButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteApptButton.Location = new System.Drawing.Point(1513, 477);
            this.DeleteApptButton.Name = "DeleteApptButton";
            this.DeleteApptButton.Size = new System.Drawing.Size(105, 69);
            this.DeleteApptButton.TabIndex = 8;
            this.DeleteApptButton.Text = "DELETE";
            this.DeleteApptButton.UseVisualStyleBackColor = true;
            this.DeleteApptButton.Click += new System.EventHandler(this.DeleteApptButton_Click);
            // 
            // UpdateApptButton
            // 
            this.UpdateApptButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateApptButton.Location = new System.Drawing.Point(1370, 477);
            this.UpdateApptButton.Name = "UpdateApptButton";
            this.UpdateApptButton.Size = new System.Drawing.Size(105, 69);
            this.UpdateApptButton.TabIndex = 9;
            this.UpdateApptButton.Text = "UPDATE";
            this.UpdateApptButton.UseVisualStyleBackColor = true;
            this.UpdateApptButton.Click += new System.EventHandler(this.UpdateApptButton_Click);
            // 
            // CustLabel
            // 
            this.CustLabel.AutoSize = true;
            this.CustLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustLabel.Location = new System.Drawing.Point(36, 80);
            this.CustLabel.Name = "CustLabel";
            this.CustLabel.Size = new System.Drawing.Size(210, 39);
            this.CustLabel.TabIndex = 10;
            this.CustLabel.Text = "Customer List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Appointments";
            // 
            // AllRadio
            // 
            this.AllRadio.AutoSize = true;
            this.AllRadio.Checked = true;
            this.AllRadio.Location = new System.Drawing.Point(465, 126);
            this.AllRadio.Name = "AllRadio";
            this.AllRadio.Size = new System.Drawing.Size(62, 33);
            this.AllRadio.TabIndex = 12;
            this.AllRadio.TabStop = true;
            this.AllRadio.Text = "All";
            this.AllRadio.UseVisualStyleBackColor = true;
            this.AllRadio.CheckedChanged += new System.EventHandler(this.AllRadio_CheckedChanged);
            // 
            // MonthRadio
            // 
            this.MonthRadio.AutoSize = true;
            this.MonthRadio.Location = new System.Drawing.Point(567, 126);
            this.MonthRadio.Name = "MonthRadio";
            this.MonthRadio.Size = new System.Drawing.Size(155, 33);
            this.MonthRadio.TabIndex = 13;
            this.MonthRadio.Text = "This Month";
            this.MonthRadio.UseVisualStyleBackColor = true;
            this.MonthRadio.CheckedChanged += new System.EventHandler(this.MonthRadio_CheckedChanged);
            // 
            // WeekRadio
            // 
            this.WeekRadio.AutoSize = true;
            this.WeekRadio.Location = new System.Drawing.Point(764, 126);
            this.WeekRadio.Name = "WeekRadio";
            this.WeekRadio.Size = new System.Drawing.Size(149, 33);
            this.WeekRadio.TabIndex = 14;
            this.WeekRadio.Text = "This Week";
            this.WeekRadio.UseVisualStyleBackColor = true;
            this.WeekRadio.CheckedChanged += new System.EventHandler(this.WeekRadio_CheckedChanged);
            // 
            // AllUserCheck
            // 
            this.AllUserCheck.AutoSize = true;
            this.AllUserCheck.Location = new System.Drawing.Point(1487, 126);
            this.AllUserCheck.Name = "AllUserCheck";
            this.AllUserCheck.Size = new System.Drawing.Size(131, 33);
            this.AllUserCheck.TabIndex = 15;
            this.AllUserCheck.Text = "All Users";
            this.AllUserCheck.UseVisualStyleBackColor = true;
            this.AllUserCheck.CheckedChanged += new System.EventHandler(this.AllUserCheck_CheckedChanged);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(1391, 693);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(227, 117);
            this.LogoutButton.TabIndex = 16;
            this.LogoutButton.Text = "LOG OUT";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ReportChoices
            // 
            this.ReportChoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReportChoices.FormattingEnabled = true;
            this.ReportChoices.Location = new System.Drawing.Point(460, 627);
            this.ReportChoices.Name = "ReportChoices";
            this.ReportChoices.Size = new System.Drawing.Size(227, 37);
            this.ReportChoices.TabIndex = 17;
            // 
            // GenerateReport
            // 
            this.GenerateReport.Location = new System.Drawing.Point(460, 693);
            this.GenerateReport.Name = "GenerateReport";
            this.GenerateReport.Size = new System.Drawing.Size(227, 117);
            this.GenerateReport.TabIndex = 18;
            this.GenerateReport.Text = "Generate";
            this.GenerateReport.UseVisualStyleBackColor = true;
            this.GenerateReport.Click += new System.EventHandler(this.GenerateReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(453, 559);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 39);
            this.label2.TabIndex = 19;
            this.label2.Text = "Reports";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1655, 899);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GenerateReport);
            this.Controls.Add(this.ReportChoices);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.AllUserCheck);
            this.Controls.Add(this.WeekRadio);
            this.Controls.Add(this.MonthRadio);
            this.Controls.Add(this.AllRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustLabel);
            this.Controls.Add(this.UpdateApptButton);
            this.Controls.Add(this.DeleteApptButton);
            this.Controls.Add(this.AddApptButton);
            this.Controls.Add(this.DeleteCustButton);
            this.Controls.Add(this.UpdateCustButton);
            this.Controls.Add(this.AddCustButton);
            this.Controls.Add(this.CustomerDataGrid);
            this.Controls.Add(this.AppointmentGrid);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView AppointmentGrid;
        private System.Windows.Forms.DataGridView CustomerDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustIDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustNameCol;
        private System.Windows.Forms.Button AddCustButton;
        private System.Windows.Forms.Button UpdateCustButton;
        private System.Windows.Forms.Button DeleteCustButton;
        private System.Windows.Forms.Button AddApptButton;
        private System.Windows.Forms.Button DeleteApptButton;
        private System.Windows.Forms.Button UpdateApptButton;
        private System.Windows.Forms.Label CustLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton AllRadio;
        private System.Windows.Forms.RadioButton MonthRadio;
        private System.Windows.Forms.RadioButton WeekRadio;
        private System.Windows.Forms.CheckBox AllUserCheck;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.ComboBox ReportChoices;
        private System.Windows.Forms.Button GenerateReport;
        private System.Windows.Forms.Label label2;
    }
}

