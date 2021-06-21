using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace C969_PA_Worun_Sukhtipyaroge
{
    public partial class CustAddUpdate : Form
    {
        public CustAddUpdate()
        {
            InitializeComponent();
            

            if (Form1.UpdateCust == true)
            {
                CustIDLabel.Visible = true;
                CustID.Visible = true;
                AddModCustomer.Text = "Update Customer";
                CustID.Text = Form1.CustTarget;
                FillForUpdate();
            } else if (Form1.UpdateCust == false)
            {
                CustIDLabel.Visible = false;
                CustID.Visible = false;
                AddModCustomer.Text = "Add Customer";
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public static int ErrorCounter;
        private void ValidateEntries()
        {
            ErrorCounter = 0;
            if (NameEntry.Text == string.Empty)
            {
                
                errorProvider1.SetError(NameEntry, "Cannot be empty.");
                ErrorCounter++;
            } else
            {
                
                errorProvider1.SetError(NameEntry, "");
            }
            if (AddressEntry.Text == string.Empty)
            {
                
                errorProvider1.SetError(AddressEntry, "Cannot be empty.");
                ErrorCounter++;
            }
            else
            {
                
                errorProvider1.SetError(AddressEntry, "");
            }
            if (CityEntry.Text == string.Empty)
            {
                errorProvider1.SetError(CityEntry, "Cannot be empty.");
                ErrorCounter++;
            }
            else
            {
                errorProvider1.SetError(CityEntry, "");
            }
            if (CountryEntry.Text == string.Empty)
            {
                errorProvider1.SetError(CountryEntry, "Cannot be empty.");
                ErrorCounter++;
            }
            else
            {
                errorProvider1.SetError(CountryEntry, "");
            }
            if (PostCodeEntry.Text == string.Empty)
            {
                errorProvider1.SetError(PostCodeEntry, "Cannot be empty.");
                ErrorCounter++;
            }
            else
            {
                try
                {
                    int.Parse(PostCodeEntry.Text);
                    errorProvider1.SetError(PostCodeEntry, "");
                }
                catch (FormatException)
                {
                    errorProvider1.SetError(PostCodeEntry, "Must be a number.");
                    ErrorCounter++;
                }
            }
            if (PhoneMaskEntry.MaskCompleted != true)
            {
                errorProvider1.SetError(PhoneMaskEntry, "Invalid input.");
                ErrorCounter++;
            }
            else if(PhoneMaskEntry.MaskCompleted == true)
            {
                errorProvider1.SetError(PhoneMaskEntry, "");
            }           
        }

        
        
        public static int CountryIDEntry;
        public static int CityIDEntry;
        public static int AddressIDEntry;
        delegate bool IsNew(string old);
        delegate bool RecycleID(int id);
        private void UpdateAddCustomer()
        {


            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            
           
            //Check to see if a new country needs to be added to the country table
            string sqlStringCountry = "select country, countryId from country order by countryId";
            MySqlCommand cmd = new MySqlCommand(sqlStringCountry, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable CountryCheck = new DataTable();
            adp.Fill(CountryCheck);
            foreach (DataRow row in CountryCheck.Rows)
            {
                string old = row["country"].ToString();

                //Lambda to simplify the check if a new country was entered
                IsNew isNew = s => old != CountryEntry.Text;
                newCountry = (isNew(old) ? true: false);
                if(!newCountry)
                {
                    CountryIDEntry = Convert.ToInt32(row["countryId"]);
                    break;
                }
                
            }
            if (newCountry)
            {
                for (int i = 0; i < CountryCheck.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(CountryCheck.Rows[i]["countryId"]);
                    RecycleID recycleID = s => id != i + 1;
                    if (recycleID(id))
                    {
                        CountryIDEntry = i + 1;
                        break;
                    }
                    else
                    {
                        CountryIDEntry = CountryCheck.Rows.Count + 1;
                    }
                }
            }
            
            //Check to see if a new city needs to be added to the city table
            string sqlStringCity = "select city, cityId from city order by cityId";
            cmd = new MySqlCommand(sqlStringCity, con);
            adp = new MySqlDataAdapter(cmd);
            DataTable CityCheck = new DataTable();
            adp.Fill(CityCheck);
            foreach (DataRow row in CityCheck.Rows)
            {
                string old = row["city"].ToString();

                //Lambda to simplify the check if a new city was entered
                IsNew isNew = s => old != CityEntry.Text;
                newCity = (isNew(old) ? true: false);
                if(!newCity)
                {

                    CityIDEntry = Convert.ToInt32(row["cityId"]);
                    break;
                }
                
            }
            if(newCity)
            {
                for(int i = 0; i < CityCheck.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(CityCheck.Rows[i]["cityId"]);
                    RecycleID recycleID = s => id != i+1;
                    if(recycleID(id))
                    {
                        CityIDEntry = i + 1;
                        break;
                    } else
                    {
                        CityIDEntry = CityCheck.Rows.Count + 1;
                    }
                }
            }

            string sqlStringAddress = "select addressId from address order by addressId";
            cmd = new MySqlCommand(sqlStringAddress, con);
            adp = new MySqlDataAdapter(cmd);
            DataTable AddressCheck = new DataTable();
            adp.Fill(AddressCheck);
            for(int i = 0; i <  AddressCheck.Rows.Count; i++)
            {
                int id = Convert.ToInt32(AddressCheck.Rows[i]["addressId"]);

                //Lambda simplifies recycling IDs that have opened up due to deletion of previous ID holder
                RecycleID recycleID = s => id != i + 1;
                if(recycleID(id))
                {
                    AddressIDEntry = i + 1;
                    break;
                } else
                {
                    AddressIDEntry = AddressCheck.Rows.Count + 1;
                }
            }
            

            //Add new country to country table
            if (newCountry == true)
            {
                AddCountry();
            }
            //Add new city to city table
            if (newCity == true)
            {
                AddCity();
            }

            if (Form1.UpdateCust == false)
            {
                AddAddress();
                AddCustomer();
            }
            else if (Form1.UpdateCust == true)
            {
                UpdateAddress();
                UpdateCustomer();
            }
        }

        private void AddCustomer()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string addToCustomer = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) values(\"" + NameEntry.Text + "\","+ AddressIDEntry +", 1, \"" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + "\", \"" + Login.LoggedInUser + "\", \"" + Login.LoggedInUser + "\")";
            MySqlCommand cmd = new MySqlCommand(addToCustomer, con);

            cmd.ExecuteNonQuery();
        }

        private void AddAddress()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            string addToAddress = "INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) values("+ AddressIDEntry +",\"" + AddressEntry.Text + "\", \"\", " + CityIDEntry + ", \"" + PostCodeEntry.Text + "\", \"" + PhoneMaskEntry.Text + "\", \"" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + "\", \"" + Login.LoggedInUser + "\", \"" + Login.LoggedInUser + "\")";
            MySqlCommand cmd = new MySqlCommand(addToAddress, con);
            cmd.ExecuteNonQuery();
        }
            
        

        private void AddCity()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string addToCity = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) values (\"" + CityEntry.Text + "\", " + CountryIDEntry + ", \"" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + "\", \"" + Login.LoggedInUser + "\", \"" + Login.LoggedInUser + "\")";
            MySqlCommand cmd = new MySqlCommand(addToCity, con);
            cmd.ExecuteNonQuery();
        }

        private void AddCountry()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string addToCountry = "INSERT INTO country (country, createDate, createdBy, lastUpdateBy) values (\"" + CountryEntry.Text + "\", \"" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + "\", \"" + Login.LoggedInUser + "\", \"" + Login.LoggedInUser + "\")";
            MySqlCommand cmd = new MySqlCommand(addToCountry, con);
            cmd.ExecuteNonQuery();
        }

        private void UpdateCustomer()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStringUpdateCustomerName = "update customer set customerName = \"" + NameEntry.Text + "\", lastUpdateBy = \"" + Login.LoggedInUser + "\" where customerId = " + Form1.CustTarget;
            MySqlCommand cmd = new MySqlCommand(sqlStringUpdateCustomerName, con);
            cmd.ExecuteNonQuery();
        }

        private void UpdateAddress()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStringUpdateAddressInfo = "update address set address = \"" + AddressEntry.Text + "\", phone = \"" + PhoneMaskEntry.Text + "\", postalCode = \"" + PostCodeEntry.Text + "\", cityId = "+ CityIDEntry+ ", lastUpdateBy = \"" + Login.LoggedInUser + "\" where address.addressId = (select addressId from customer where customerId = " + Form1.CustTarget +")";
            MySqlCommand cmd = new MySqlCommand(sqlStringUpdateAddressInfo, con);
            cmd.ExecuteNonQuery();
        }
        



        private void FillForUpdate()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UCDB"].ConnectionString;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStringCustData = "select customer.customerName, address.address, address.postalCode, address.phone, city.city, country.country from customer  inner join address on customer.addressId = address.addressId inner join city on address.cityId = city.cityId inner join country on country.countryId = city.countryId where customer.customerId = "+ Form1.CustTarget;
            MySqlCommand cmd = new MySqlCommand(sqlStringCustData, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable CustomerData = new DataTable();
            adp.Fill(CustomerData);
            
            NameEntry.Text = CustomerData.Rows[0]["customerName"].ToString();
            AddressEntry.Text = CustomerData.Rows[0]["address"].ToString();
            CityEntry.Text = CustomerData.Rows[0]["city"].ToString();
            CountryEntry.Text = CustomerData.Rows[0]["country"].ToString();
            PostCodeEntry.Text = CustomerData.Rows[0]["postalCode"].ToString();
            PhoneMaskEntry.Text = CustomerData.Rows[0]["phone"].ToString();

        }

        public static bool newCity;
        public static bool newCountry;
        
        
        
       

        private void Save_Click(object sender, EventArgs e)
        {
            ValidateEntries();
            if(ErrorCounter == 0)
            {
                UpdateAddCustomer();
                this.DialogResult = DialogResult.OK;
                
            }
            
        }
    }
}
