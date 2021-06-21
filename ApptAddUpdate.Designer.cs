
namespace C969_PA_Worun_Sukhtipyaroge
{
    partial class ApptAddUpdate
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.CustIDLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CustIDBox = new System.Windows.Forms.ComboBox();
            this.NameBox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UserID = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.UserIDBox = new System.Windows.Forms.ComboBox();
            this.UserNameBox = new System.Windows.Forms.ComboBox();
            this.ApptTitle = new System.Windows.Forms.Label();
            this.ApptIDLabel = new System.Windows.Forms.Label();
            this.ApptIDNumber = new System.Windows.Forms.Label();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.currentMeetings = new System.Windows.Forms.DataGridView();
            this.CurrentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currentMeetings)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(580, 829);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(147, 91);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TypeBox
            // 
            this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Location = new System.Drawing.Point(512, 351);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(312, 37);
            this.TypeBox.TabIndex = 9;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(148, 444);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(63, 29);
            this.DateLabel.TabIndex = 10;
            this.DateLabel.Text = "Date";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(507, 444);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(124, 29);
            this.StartLabel.TabIndex = 11;
            this.StartLabel.Text = "Start Time";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(681, 444);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(112, 29);
            this.EndLabel.TabIndex = 12;
            this.EndLabel.Text = "End Time";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(507, 313);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(157, 29);
            this.TypeLabel.TabIndex = 13;
            this.TypeLabel.Text = "Meeting Type";
            // 
            // CustIDLabel
            // 
            this.CustIDLabel.AutoSize = true;
            this.CustIDLabel.Location = new System.Drawing.Point(507, 161);
            this.CustIDLabel.Name = "CustIDLabel";
            this.CustIDLabel.Size = new System.Drawing.Size(99, 29);
            this.CustIDLabel.TabIndex = 14;
            this.CustIDLabel.Text = "Cust. ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Customer Name";
            // 
            // CustIDBox
            // 
            this.CustIDBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustIDBox.FormattingEnabled = true;
            this.CustIDBox.Location = new System.Drawing.Point(512, 217);
            this.CustIDBox.Name = "CustIDBox";
            this.CustIDBox.Size = new System.Drawing.Size(94, 37);
            this.CustIDBox.TabIndex = 20;
            this.CustIDBox.SelectedIndexChanged += new System.EventHandler(this.IDBox_SelectedIndexChanged);
            // 
            // NameBox
            // 
            this.NameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NameBox.FormattingEnabled = true;
            this.NameBox.Location = new System.Drawing.Point(645, 217);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(179, 37);
            this.NameBox.TabIndex = 21;
            this.NameBox.SelectedIndexChanged += new System.EventHandler(this.NameBox_SelectedIndexChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(229, 829);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(147, 91);
            this.SaveButton.TabIndex = 22;
            this.SaveButton.Text = "SAVE";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UserID
            // 
            this.UserID.AutoSize = true;
            this.UserID.Location = new System.Drawing.Point(148, 161);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(95, 29);
            this.UserID.TabIndex = 23;
            this.UserID.Text = "User ID";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(148, 313);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(132, 29);
            this.Username.TabIndex = 24;
            this.Username.Text = "User Name";
            // 
            // UserIDBox
            // 
            this.UserIDBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserIDBox.FormattingEnabled = true;
            this.UserIDBox.Location = new System.Drawing.Point(153, 217);
            this.UserIDBox.Name = "UserIDBox";
            this.UserIDBox.Size = new System.Drawing.Size(121, 37);
            this.UserIDBox.TabIndex = 25;
            this.UserIDBox.SelectedIndexChanged += new System.EventHandler(this.UserIDBox_SelectedIndexChanged);
            // 
            // UserNameBox
            // 
            this.UserNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserNameBox.FormattingEnabled = true;
            this.UserNameBox.Location = new System.Drawing.Point(153, 351);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(312, 37);
            this.UserNameBox.TabIndex = 26;
            this.UserNameBox.SelectedIndexChanged += new System.EventHandler(this.UserNameBox_SelectedIndexChanged);
            // 
            // ApptTitle
            // 
            this.ApptTitle.AutoSize = true;
            this.ApptTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApptTitle.Location = new System.Drawing.Point(428, 9);
            this.ApptTitle.Name = "ApptTitle";
            this.ApptTitle.Size = new System.Drawing.Size(113, 43);
            this.ApptTitle.TabIndex = 27;
            this.ApptTitle.Text = "label1";
            // 
            // ApptIDLabel
            // 
            this.ApptIDLabel.AutoSize = true;
            this.ApptIDLabel.Location = new System.Drawing.Point(148, 97);
            this.ApptIDLabel.Name = "ApptIDLabel";
            this.ApptIDLabel.Size = new System.Drawing.Size(187, 29);
            this.ApptIDLabel.TabIndex = 28;
            this.ApptIDLabel.Text = "Appointment ID:";
            // 
            // ApptIDNumber
            // 
            this.ApptIDNumber.AutoSize = true;
            this.ApptIDNumber.Location = new System.Drawing.Point(379, 97);
            this.ApptIDNumber.Name = "ApptIDNumber";
            this.ApptIDNumber.Size = new System.Drawing.Size(75, 29);
            this.ApptIDNumber.TabIndex = 29;
            this.ApptIDNumber.Text = "label3";
            // 
            // DatePicker
            // 
            this.DatePicker.CustomFormat = "yyyy-MM-dd";
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePicker.Location = new System.Drawing.Point(153, 482);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(312, 36);
            this.DatePicker.TabIndex = 30;
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.CustomFormat = "HH:mm:ss";
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTimePicker.Location = new System.Drawing.Point(512, 482);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.ShowUpDown = true;
            this.StartTimePicker.Size = new System.Drawing.Size(138, 36);
            this.StartTimePicker.TabIndex = 32;
            this.StartTimePicker.ValueChanged += new System.EventHandler(this.StartTimePicker_ValueChanged);
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.CustomFormat = "HH:mm:ss";
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTimePicker.Location = new System.Drawing.Point(686, 482);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowUpDown = true;
            this.EndTimePicker.Size = new System.Drawing.Size(138, 36);
            this.EndTimePicker.TabIndex = 33;
            // 
            // currentMeetings
            // 
            this.currentMeetings.AllowUserToAddRows = false;
            this.currentMeetings.AllowUserToDeleteRows = false;
            this.currentMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currentMeetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentMeetings.Location = new System.Drawing.Point(153, 606);
            this.currentMeetings.Name = "currentMeetings";
            this.currentMeetings.RowHeadersVisible = false;
            this.currentMeetings.RowHeadersWidth = 62;
            this.currentMeetings.RowTemplate.Height = 28;
            this.currentMeetings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.currentMeetings.Size = new System.Drawing.Size(671, 193);
            this.currentMeetings.TabIndex = 34;
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.AutoSize = true;
            this.CurrentLabel.Location = new System.Drawing.Point(153, 566);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(458, 29);
            this.CurrentLabel.TabIndex = 35;
            this.CurrentLabel.Text = "Current Appointments Times For All Users";
            // 
            // ApptAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 1028);
            this.Controls.Add(this.CurrentLabel);
            this.Controls.Add(this.currentMeetings);
            this.Controls.Add(this.EndTimePicker);
            this.Controls.Add(this.StartTimePicker);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.ApptIDNumber);
            this.Controls.Add(this.ApptIDLabel);
            this.Controls.Add(this.ApptTitle);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.UserIDBox);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.CustIDBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustIDLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.CancelButton);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ApptAddUpdate";
            this.Text = "ApptAddUpdate";
            ((System.ComponentModel.ISupportInitialize)(this.currentMeetings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label CustIDLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CustIDBox;
        private System.Windows.Forms.ComboBox NameBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label UserID;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.ComboBox UserIDBox;
        private System.Windows.Forms.ComboBox UserNameBox;
        private System.Windows.Forms.Label ApptTitle;
        private System.Windows.Forms.Label ApptIDLabel;
        private System.Windows.Forms.Label ApptIDNumber;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.DataGridView currentMeetings;
        private System.Windows.Forms.Label CurrentLabel;
    }
}