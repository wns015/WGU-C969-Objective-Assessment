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
using System.Configuration;
using MySql.Data.MySqlClient;

namespace C969_PA_Worun_Sukhtipyaroge
{
    public partial class Login : Form
    {
        public Login()
        {
            LoginList = new BindingList<LoginInfo>();
            PopulateLoginList();
            InitializeComponent();
            SysRegion = RegionInfo.CurrentRegion.DisplayName;

            //Check if region is Thailand for localization
            if(SysRegion == "Thailand")
            {
                UsernameLabel.Text = "ชื่อผู้ใช้";
                PasswordLabel.Text = "รหัสผ่าน";
                LoginButton.Text = "เข้าสู่ระบบ";
                ExitButton.Text = "ออกจากโปรแกรม";

            }
            
        }

        public static string SysRegion;
        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool LoginCheck = false;
            for(int i = 0; i < LoginList.Count; i++)
            {
                if(LoginList[i].username == UsernameEntry.Text)
                {
                    if(LoginList[i].password == PasswordEntry.Text)
                    {
                        LoginCheck = true;
                        LoggedInUser = UsernameEntry.Text;
                    }
                }
                              
            }
            PasswordEntry.Clear();
            if(LoginCheck == true)
            {
                this.Hide();
                LoggedInTime = DateTime.UtcNow;
                Form1 F1 = new Form1();
                F1.ShowDialog();
                this.Show();

            }else
            {
                //Localized failed login message box for Thailand
                if(SysRegion == "Thailand")
                {
                    const string message = "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง";
                    const string caption = "ผิดพลาด";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    const string message = "Invalid username and/or password.";
                    const string caption = "Login Failed";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }   
                
            }
            
        }
        private void PopulateLoginList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStringUserID = "select userName, password from user";
            MySqlCommand cmd = new MySqlCommand(sqlStringUserID, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable LoginTable = new DataTable();
            adp.Fill(LoginTable);
            foreach(DataRow row in LoginTable.Rows)
            {
                string un = row["userName"].ToString();
                string pw = row["password"].ToString();
                LoginList.Add(new LoginInfo(un, pw));
            }
            
        }

        public class LoginInfo
        {
            public string username;
            public string password;

            public LoginInfo(string un, string pw)
            {
                this.username = un;
                this.password = pw;
            }
        }

        public static BindingList<LoginInfo> LoginList;
        public static string LoggedInUser;
        public static DateTime LoggedInTime;

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PasswordEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(this, new EventArgs());
            }
        }
    }

}
