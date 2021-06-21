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
using System.IO;

namespace C969_PA_Worun_Sukhtipyaroge
{
    public partial class Report : Form
    {
        

        public Report()
        {
            InitializeComponent();
            ReportType();
            ReportBox.Text = TextAdd;
        }

        public string sqlString;
        public static DataTable dt;
        public string TextAdd;

        private void ReportType()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            if (Form1.ReportType == 1) //Meeting types per month
            {
                ReportLabel.Text = "Number of Meeting Types Per Month";
                sqlString = "select month(start), count(distinct(type)) from appointment group by month(start)";
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    TextAdd += (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(row["month(start)"]))).ToString() + ": " + row["count(distinct(type))"].ToString() + Environment.NewLine;
                }
            } 
            else if(Form1.ReportType == 2) //User Schedules
            {
                ReportLabel.Text = "User Schedules";
                sqlString = "select user.userName, appointment.start, appointment.end from user inner join appointment on user.userId = appointment.userId order by user.userName, appointment.start";
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);
                DateTime start;
                DateTime end;
                string userNamePrevious = "prev";
                foreach(DataRow row in dt.Rows)
                {
                    start = Convert.ToDateTime(row["start"]).ToLocalTime();
                    end = Convert.ToDateTime(row["end"]).ToLocalTime();
                    string userNameCurrent = row["userName"].ToString();
                    if(userNameCurrent != userNamePrevious)
                    {
                        TextAdd += userNameCurrent + ":" + Environment.NewLine + "    " + start.ToString() + " - " + end.ToString() + Environment.NewLine;
                        userNamePrevious = userNameCurrent;
                    } 
                    else if(userNameCurrent == userNamePrevious)
                    {
                        TextAdd += "    " + start.ToString() + " - " + end.ToString() + Environment.NewLine;
                    }
                }

            }    
            else if(Form1.ReportType == 3) //User Customers
            {
                ReportLabel.Text = "User Customers";
                sqlString = "select user.userName, customer.customerName from ((appointment inner join customer on customer.customerId = appointment.customerId) inner join user on appointment.userId = user.userId) order by userName";
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);
                string userPrevious = "prev";
                string custPrevious = "prev";
                foreach(DataRow row in dt.Rows)
                {
                    string userCurrent = row["userName"].ToString();
                    string custCurrent = row["customerName"].ToString();
                    if(userCurrent != userPrevious)
                    {
                        TextAdd += userCurrent + ":" + Environment.NewLine + "    " + custCurrent + Environment.NewLine;
                        userPrevious = userCurrent;
                        custPrevious = custCurrent;
                    } else if (userCurrent == userPrevious)
                    {
                        if(custCurrent != custPrevious)
                        {
                            TextAdd += "    " + custCurrent + Environment.NewLine;
                            custPrevious = custCurrent;
                        }
                    }
                }
            }
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
