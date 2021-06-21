using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Globalization;

namespace C969_PA_Worun_Sukhtipyaroge
{
    public partial class ApptAddUpdate : Form
    {
        public ApptAddUpdate()
        {
            
            InitializeComponent();
            
            CustomerBoxesLoad();
            TypeBoxLoad();
            UserBoxesLoad();
            FillCurrentAppt();
            StartTimePicker.MinDate = OpenHour.ToLocalTime();
            StartTimePicker.MaxDate = CloseHour.ToLocalTime();
            EndTimePicker.MinDate = OpenHour.ToLocalTime();
            EndTimePicker.MaxDate = CloseHour.ToLocalTime();
            if(DateTime.Now > CloseHour.ToLocalTime())
            {
                DatePicker.MinDate = DateTime.Now.AddDays(1);
            } else
            {
                DatePicker.MinDate = DateTime.Now;
            }
            

            if(Form1.UpdateAppt == true)
            {
                ApptIDLabel.Visible = true;
                ApptIDNumber.Visible = true;
                ApptIDNumber.Text = Form1.ApptTarget;
                UpdateInfoFill();
                
            } else if(Form1.UpdateAppt == false)
            {
                ApptIDLabel.Visible = false;
                ApptIDNumber.Visible = false;
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

       
        

        private void TypeBoxLoad()
        {
            string[] Type = { "Presentation", "Scrum", "Consultation", "Status Update", "General" };
            for(int i = 0; i < Type.Length; i++)
            {
                TypeBox.Items.Add(Type[i]);
            }
        }

        
        private void CustomerBoxesLoad()
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlString = "select customerId, customerName from customer";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable cg = new DataTable();
            adp.Fill(cg);
            foreach (DataRow row in cg.Rows)
            {
                string cid = row["customerId"].ToString();
                string cn = row["customerName"].ToString();
                CustIDBox.Items.Add(cid);
                NameBox.Items.Add(cn);
            }

        }

        private void UserBoxesLoad()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlString = "select userId, userName from user";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable userlist = new DataTable();
            adp.Fill(userlist);
            foreach (DataRow row in userlist.Rows)
            {
                string uid = row["userId"].ToString();
                string un = row["userName"].ToString();
                UserIDBox.Items.Add(uid);
                UserNameBox.Items.Add(un);
            }
        }

        private void IDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CustIDBox.SelectedIndex;
            NameBox.SelectedIndex = index;
        }

        private void NameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = NameBox.SelectedIndex;
            CustIDBox.SelectedIndex = index;
        }

        private void UpdateInfoFill()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlString = "select userId, type, start, end, customerId from appointment where appointmentId = " + Convert.ToInt32(Form1.ApptTarget);
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable apptList = new DataTable();
            adp.Fill(apptList);
            string userID = apptList.Rows[0]["userId"].ToString();
            DateTime StartDate = Convert.ToDateTime(apptList.Rows[0]["start"].ToString()).ToLocalTime();
            DateTime EndDate = Convert.ToDateTime(apptList.Rows[0]["end"].ToString()).ToLocalTime() ;
            string customerID = apptList.Rows[0]["customerId"].ToString();
            string mtype = apptList.Rows[0]["type"].ToString();
            UserIDBox.SelectedIndex = UserIDBox.FindStringExact(userID);
            TypeBox.SelectedIndex = TypeBox.FindStringExact(mtype);
            
            
            if(StartDate < DateTime.Now)
            {
                DatePicker.Value = DateTime.Now;
            } else
            {
                DatePicker.Value = StartDate;
            }
            StartTimePicker.Value = Convert.ToDateTime(StartDate.ToString("HH:mm:ss"));
            CustIDBox.SelectedIndex = CustIDBox.FindStringExact(customerID);
            EndTimePicker.Value = Convert.ToDateTime(StartDate.ToString("HH:mm:ss"));


            
        }

        private void UserIDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = UserIDBox.SelectedIndex;
            UserNameBox.SelectedIndex = index;
        }

        private void UserNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = UserNameBox.SelectedIndex;
            UserIDBox.SelectedIndex = index;
        }

        public static DateTime OpenHour = DateTime.SpecifyKind(Convert.ToDateTime("12:00:00"), DateTimeKind.Utc);
        public static DateTime CloseHour = DateTime.SpecifyKind(Convert.ToDateTime("21:00:00"), DateTimeKind.Utc);

        private void StartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndTimePicker.MinDate = StartTimePicker.Value;
        }

        private void UpdateAppointment()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            ChangeToUTC();
            string sqlString = "update appointment set userId = " + UserIDBox.Text + ", customerId = " + CustIDBox.Text + ", type = \"" + TypeBox.Text + "\", start = \"" + starttime + "\", end = \"" + endtime +"\" where appointmentId = " + Form1.ApptTarget;
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            cmd.ExecuteNonQuery();
        }
        private void AddAppt()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            ChangeToUTC();
            string sqlString = "insert into appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) values(" + CustIDBox.Text + ", " + UserIDBox.Text + ", \'not needed\', \'not needed\', \'not needed\', \'not needed\', \'" + TypeBox.Text + "\', \'not needed\', \"" + starttime + "\", \"" + endtime + "\", \"" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + "\", \"" + Login.LoggedInUser + "\", \"" + Login.LoggedInUser + "\")";

            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            cmd.ExecuteNonQuery();
        }

        public static string starttime;
        public static string endtime;
        public static DataTable dt;
        public static bool DateOK;
        public static bool BoxesOK;
        
        private void FillCurrentAppt()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlString = "select appointmentId, userId, start, end from appointment";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            currentMeetings.DataSource = dt;
            foreach(DataRow row in dt.Rows)
            {
                DateTime ustart = Convert.ToDateTime(row["start"]);
                DateTime uend = Convert.ToDateTime(row["end"]);
                row["start"] = ustart.ToLocalTime();
                row["end"] = uend.ToLocalTime();
            }
        }
        private void ValidateApptDate()
        {
            bool dateCheck = true;
            DateTime d1 = Convert.ToDateTime(starttime);
            DateTime d2 = Convert.ToDateTime(endtime);
            foreach (DataRow row in dt.Rows)
            {
                DateTime startCheck = Convert.ToDateTime(row["start"].ToString());
                DateTime endCheck = Convert.ToDateTime(row["end"].ToString());
                string message = "The time for this meeting overlaps with another meeting.";
                string caption = "Schedule Overlap";
                if (Form1.UpdateAppt == true)
                {
                    if(Convert.ToInt32(row["appointmentId"]) != Convert.ToInt32(Form1.ApptTarget))
                    {
                        if ((d1 >= startCheck && d1 < endCheck) || (d2 > startCheck && d2 <= endCheck)||(d1 <= startCheck && d2 >= endCheck) && Convert.ToInt32(UserIDBox.Text) == Convert.ToInt32(row["userId"]))
                        {
                            
                            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dateCheck = false;
                            break;
                        } 
                    }
                } else
                {
                    if ((d1 >= startCheck && d1 < endCheck) || (d2 > startCheck && d2 <= endCheck || (d1 <= startCheck && d2 >= endCheck)) && Convert.ToInt32(UserIDBox.Text) == Convert.ToInt32(row["userId"]))
                    {
                
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dateCheck = false;
                        break;
                    }
                }
                
                
            }
            if(d1 < DateTime.Now || d2 < DateTime.Now)
            {
                string message = "The time for this meeting has already passed.";
                string caption = "Past Meeting";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dateCheck = false;
            }
            if(dateCheck == true)
            {
                DateOK = true;
            } else
            {
                DateOK = false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            starttime = DatePicker.Value.ToString("yyyy-MM-dd") + " " + (StartTimePicker.Value).ToString("HH:mm:ss");
            endtime = DatePicker.Value.ToString("yyyy-MM-dd") + " " + (EndTimePicker.Value).ToString("HH:mm:ss");
            ValidateBoxes();
            ValidateApptDate();
            if (DateOK == true && BoxesOK == true)
            {
                if (Form1.UpdateAppt == true)
                {
                    UpdateAppointment();
                }
                else if (Form1.UpdateAppt == false)
                {
                    AddAppt();
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ChangeToUTC()
        {
            starttime = (Convert.ToDateTime(starttime).ToUniversalTime()).ToString("yyyy-MM-dd HH:mm:ss");
            endtime = (Convert.ToDateTime(endtime).ToUniversalTime()).ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ValidateBoxes()
        {
            if(UserIDBox.Text == string.Empty || CustIDBox.Text == string.Empty || TypeBox.Text == string.Empty)
            {
                string message = "One or more boxes have not been selected.";
                string caption = "Empty Selections";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BoxesOK = false;
            }else
            {
                BoxesOK = true;
            }
        }
    }

    
}
