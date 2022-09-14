using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWorkBM5_Aplication.Pages
{
    public partial class Workplace : System.Web.UI.Page
    {
        readonly ConnectMySql con = new ConnectMySql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string option = Session["option"].ToString();
                if(option == "add")
                {
                    Button2.Text = "Dodaj wiersz";
                }
                else if(option == "modify")
                {
                    Button2.Text = "Modyfikuj wiersz";
                    // Get the value that was send from previous page.
                    string id = Session["id"].ToString();
                    con.StartConection(Response);
                    // Get all from workplace table in data base.
                    MySqlCommand cmd = new MySqlCommand($"SELECT doctorId, jobName, cityName, streetName, streetNumber, apartment, zipCode, province FROM workplace WHERE id = {id}", con.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DoctorId.Text = reader.GetValue(0).ToString();
                        JobName.Text = reader.GetString(1);
                        CityName.Text = reader.GetString(2);
                        StreetName.Text = reader.GetString(3);
                        StreetNumber.Text = reader.GetString(4);
                        Apartment.Text = reader.GetValue(5).ToString();
                        ZipCode.Text = reader.GetString(6);
                        Province.Text = reader.GetString(7);
                    }
                    con.CloseConection();
                }
            }
        }
        // Go back button
        protected void Button_Back(object sender, EventArgs e)
        {
            Response.Redirect("table.aspx");
        }
        readonly Functions function = new Functions();
        // Confirm the data button
        protected void Button_Send(object sender, EventArgs e)
        {
            function.AssignValues(ErrorMessage, B1, B2, B3, B4, B5, B7, B8);
            function.errorCatch = false;

            string doctorId = function.ErrorMessage(DoctorId.Text, 1);
            string jobName = function.ErrorMessage(JobName.Text, 2);
            string cityName = function.ErrorMessage(CityName.Text, 3);
            string streetName = function.ErrorMessage(StreetName.Text, 4);
            string streetNumber = function.ErrorMessage(StreetNumber.Text, 5);
            string apartment = Apartment.Text == "" ? "NULL" : "\'"+Apartment.Text+"\'";
            string zipCode = function.ErrorMessage(ZipCode.Text, 6);
            string province = function.ErrorMessage(Province.Text, 7);
            if (function.errorCatch)
            {
                ErrorMessage.Visible = true;
                return;
            }
            string option = Session["option"].ToString();
            if (option == "add")
            {
                con.StartConection(Response);
                // Add the record to workplace table in data base.
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO workplace (id,doctorId,jobName,cityName,streetName,streetNumber,apartment,zipCode,province) "+
                    $"VALUES (NULL, '{doctorId}', '{jobName}', '{cityName}', '{streetName}', '{streetNumber}', {apartment}, '{zipCode}', '{province}')", con.connection);
                cmd.ExecuteNonQuery();
                con.CloseConection();
            }
            else if (option == "modify")
            {
                con.StartConection(Response);
                string id = Session["id"].ToString();
                // Modify the values in the data base.
                MySqlCommand cmd = new MySqlCommand($"UPDATE workplace SET id = '{id}', doctorId = '{doctorId}', jobName = '{jobName}', cityName = '{cityName}', "+
                    $"streetName = '{streetName}', streetNumber = '{streetNumber}', apartment = {apartment}, zipCode = '{zipCode}', province = '{province}' WHERE id = {id}", con.connection);
                cmd.ExecuteNonQuery();
                con.CloseConection();
            }
            Response.Redirect("table.aspx");
        }

        // Refresh the red dot, when textbox is filed.
        protected void DoctorId_TextChanged(object sender, EventArgs e) { B1.Visible = false; }
        protected void JobName_TextChanged(object sender, EventArgs e) { B2.Visible = false; }
        protected void CityName_TextChanged(object sender, EventArgs e) { B3.Visible = false; }
        protected void StreetName_TextChanged(object sender, EventArgs e) { B4.Visible = false; }
        protected void StreetNumber_TextChanged(object sender, EventArgs e) { B5.Visible = false; }
        protected void ZipCode_TextChanged(object sender, EventArgs e) { B7.Visible = false; }
        protected void Province_TextChanged(object sender, EventArgs e) { B8.Visible = false; }
    }
}