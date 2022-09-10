﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWorkBM5_Aplication.Pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        readonly ConnectMySql con = new ConnectMySql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con.StartConection(Response);
                // Get all specializations from database and fill Drop down list with the data.
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM specialization", con.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    DropDownList1.DataSource = reader;
                    DropDownList1.DataTextField = "name";
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataBind();
                }
                con.CloseConection();
            }
        }
        // Go back button
        protected void Button_Back(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        readonly Functions function = new Functions();
        // Confirm the data button
        protected void Button_Send(object sender, EventArgs e)
        {
            function.AssignValues(ErrorMessage, B1, B2, B3, B4, B5);
            function.errorCatch = false;

            string firstName = function.ErrorMessage(FirstName.Text, "Imię");
            string lastName = function.ErrorMessage(LastName.Text, "Nazwisko");
            string title = function.ErrorMessage(TitleName.Text, "Tytuł naukowy");
            string email = function.ErrorMessage(Email.Text, "Email");
            string phone = function.ErrorMessage(PhoneNum.Text, "Numer telefonu");
            int spec = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            if (function.errorCatch) return;

            con.StartConection(Response);
            // Insert the values to the data base.
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `doctors` (`id`, `firstName`, `lastName`, `academicTitle`, `email`, `phoneNumber`, `specialization`)" +
                $" VALUES (NULL, '{firstName}', '{lastName}', '{title}', '{email}', '{phone}', '{spec}')", con.connection);
            cmd.ExecuteNonQuery();
            con.CloseConection();
        }
        // Refresh the red dot, when textbox is filed.
        protected void FirstName_TextChanged(object sender, EventArgs e) { B1.Visible = false; }
        protected void LastName_TextChanged(object sender, EventArgs e) { B2.Visible = false; }
        protected void Title_TextChanged(object sender, EventArgs e) { B3.Visible = false; }
        protected void Email_TextChanged(object sender, EventArgs e) { B4.Visible = false; }
        protected void PhoneNum_TextChanged(object sender, EventArgs e) { B5.Visible = false; }
    }
}