using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;

namespace C969_PA_Worun_Sukhtipyaroge
{
    public partial class Form1 : Form
    {
        private StreamWriter fileWriter;
        string fileName = Login.LoggedInUser + "Log.txt";

        public Form1()
        {
            

            InitializeComponent();
            FillAppointmentGrid();
            FillCustomerGrid();
            FillReportChoices();
            
            
            FileStream inp = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            fileWriter = new StreamWriter(inp);
            fileWriter.WriteLine("Log in - " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            
        }

        public string sqlString;
        public static DataTable dt;
        
        private void FillAppointmentGrid()
        {
            

            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            sqlString = "select appointment.appointmentId, user.userName, appointment.type, appointment.start, appointment.end, customer.customerName, country.country from((appointment inner join customer on customer.customerId = appointment.customerId) inner join user on appointment.userId = user.userId) inner join address on customer.addressId = address.addressId inner join city on city.cityId = address.cityId inner join country on country.countryId = city.countryId";
            if(MonthRadio.Checked == true)
            {
                sqlString += " where month(appointment.start) = month(\"" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "\")"; 
            } else if(WeekRadio.Checked == true)
            {
                sqlString += " where week(appointment.start) = week(\"" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "\")";
            }
            
            AllUsers();
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            AppointmentGrid.DataSource = dt;
            foreach(DataRow row in dt.Rows)
            {
                DateTime dateTimeStart = (DateTime)row["start"];
                DateTime dateTimeEnd = (DateTime)row["end"];
                row["start"] = dateTimeStart.ToLocalTime();
                row["end"] = dateTimeEnd.ToLocalTime();
            }
        }

        private void FillCustomerGrid()
        {
            CustomerDataGrid.Rows.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlString = "select customerId, customerName from customer";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable cg = new DataTable();
            adp.Fill(cg);
            foreach(DataRow row in cg.Rows)
            {
                string cid = row["customerId"].ToString();
                string cn = row["customerName"].ToString();
                string[] cust = { cid, cn };
                CustomerDataGrid.Rows.Add(cust);
            }

        }

        public static bool UpdateCust = false;
        private void AddCustButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateCust = false;
            CustAddUpdate cau = new CustAddUpdate();
            cau.ShowDialog();
            this.Show();
            FillCustomerGrid();
        }

        private void UpdateCustButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateCust = true;
            
            FindCustTarget();
            
            CustAddUpdate cau = new CustAddUpdate();
            cau.ShowDialog();
            this.Show();
            FillCustomerGrid();
        }

        public static string CustTarget;

        private void FindCustTarget()
        {
            for(int i = 0; i < CustomerDataGrid.Rows.Count; i++)
            {
                if(CustomerDataGrid.Rows[i].Selected == true)
                {
                    CustTarget = CustomerDataGrid.Rows[i].Cells[0].Value.ToString();
                    break;
                }
            }
        }

        private void DeleteCustButton_Click(object sender, EventArgs e)
        {
            FindCustTarget();
            string message = "Do you want to delete this customer and all related entries?";
            string caption = "Confirm Delete";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(result == DialogResult.OK)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                string sqlString = "select customerId from appointment";
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable UserApptList = new DataTable();
                adp.Fill(UserApptList);
                bool hasAppt = false;
                foreach (DataRow row in UserApptList.Rows)
                {
                    if (row["customerId"].ToString() == CustTarget)
                    {
                        hasAppt = true;
                        sqlString = "delete from appointment where customerId = " + CustTarget + "; delete customer, address from customer inner join address on address.addressId = customer.addressId where customer.customerId = " + CustTarget;
                        break;
                    }else
                    {
                        sqlString = "delete customer, address from customer inner join address on address.addressId = customer.addressId where customer.customerId = " + CustTarget;
                    }
                }
                            
                
                cmd = new MySqlCommand(sqlString, con);
                cmd.ExecuteNonQuery();
                FillCustomerGrid();
                if(hasAppt == true)
                {
                    FillAppointmentGrid();
                }
            }
        }
        public static bool UpdateAppt;
        private void AddApptButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateAppt = false;
            ApptAddUpdate aau = new ApptAddUpdate();
            aau.ShowDialog();
            FillAppointmentGrid();
            this.Show();
        }

        private void UpdateApptButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateAppt = true;
            FindApptTarget();
            ApptAddUpdate aau = new ApptAddUpdate();
            aau.ShowDialog();
            this.Show();
            FillAppointmentGrid();
        }

        private void DeleteApptButton_Click(object sender, EventArgs e)
        {
            FindApptTarget();
            
            string message = "Do you want to delete this appointment?";
            string caption = "Confirm Delete";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(result == DialogResult.OK)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                string sqlString = "delete from appointment where appointmentId = " + ApptTarget;
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                cmd.ExecuteNonQuery();
                FillAppointmentGrid();
            }

        }

        public static string ApptTarget;
        private void FindApptTarget()
        {
            for (int i = 0; i < AppointmentGrid.Rows.Count; i++)
            {
                if (AppointmentGrid.Rows[i].Selected == true)
                {
                    ApptTarget = AppointmentGrid.Rows[i].Cells[0].Value.ToString();
                    break;
                }
            }
        }
        private void AllUsers()
        {
            if(AllUserCheck.Checked == false && AllRadio.Checked == true)
            {
                sqlString += " where user.userName = \"" + Login.LoggedInUser + "\"";
            } else if (AllUserCheck.Checked == false && AllRadio.Checked == false)
            {
                sqlString += " and user.userName = \"" + Login.LoggedInUser + "\"";
            }
        }

        private void AllUserCheck_CheckedChanged(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            FillAppointmentGrid();
        }

        private void AllRadio_CheckedChanged(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            FillAppointmentGrid();
        }

        private void MonthRadio_CheckedChanged(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            FillAppointmentGrid();
        }

        private void WeekRadio_CheckedChanged(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            FillAppointmentGrid();
        }

        //Appointment alert for login within 15 minutes of an appointment
        private void ApptAlert()
        {
            DateTime InTime = Login.LoggedInTime.AddMinutes(15).ToLocalTime();
            foreach(DataRow row in dt.Rows)
            {
                DateTime start = (Convert.ToDateTime(row["start"]));
                if(InTime >= start && InTime < start.AddMinutes(15))
                {
                    string custName = row["customerName"].ToString();
                    string type = row["type"].ToString();
                    string time = (start.ToLocalTime()).ToString("HH:mm:ss");
                    string message = "You have a " + type + " with " + custName + " at " + time + ".";
                    string caption = "Appointment Alert";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }

        public static int ReportType;
        private void FillReportChoices()
        {
            string[] ReportList = { "Select a Report Type", "Meeting Types Per Month", "User Schedules", "User Customers" };
            for(int i = 0; i < ReportList.Length; i++)
            {
                ReportChoices.Items.Add(ReportList[i]);
            }
            ReportChoices.SelectedIndex = 0;
        }
        


        private void GenerateReport_Click(object sender, EventArgs e)
        {
            ReportType = ReportChoices.SelectedIndex;
            if(ReportType == 0)
            {
                string message = "Please select a report type.";
                string caption = "No Type Selected";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.Hide();
                Report rep = new Report();
                rep.ShowDialog();
                this.Show();
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ApptAlert();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            fileWriter.WriteLine("Logged out: " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            fileWriter.Close();
        }
    }

    public static class Extensions
    {
        public static bool CaseInsensitiveContains(this string text, string value, StringComparison
            stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
    }
    
   
    
}
