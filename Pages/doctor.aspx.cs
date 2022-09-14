using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWorkBM5_Aplication.Pages
{
    public partial class Doctor : System.Web.UI.Page
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

                string option = Session["option"].ToString();
                if (option == "add")
                {
                    Button2.Text = "Dodaj wiersz";
                }
                else if (option == "modify")
                {
                    Button2.Text = "Modyfikuj wiersz";

                    // Get the value that was send from previous page.
                    string id = Session["id"].ToString();
                    con.StartConection(Response);
                    // Get firstName, lastName, academicTitle, email, phoneNumber, specialization from data base.
                    cmd = new MySqlCommand($"SELECT firstName, lastName, academicTitle, email, phoneNumber, specialization FROM doctors WHERE {id} = id", con.connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FirstName.Text = reader.GetString(0);
                        LastName.Text = reader.GetString(1);
                        TitleName.Text = reader.GetString(2);
                        Email.Text = reader.GetString(3);
                        PhoneNum.Text = reader.GetString(4);
                        DropDownList1.SelectedValue = reader.GetValue(5) + "";
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
            function.AssignValues(ErrorMessage, B1, B2, B3, B4, B5, null, null);
            function.errorCatch = false;

            string firstName = function.ErrorMessage(FirstName.Text, 1);
            string lastName = function.ErrorMessage(LastName.Text, 2);
            string title = function.ErrorMessage(TitleName.Text, 3);
            string email = function.ErrorMessage(Email.Text, 4);
            string phone = function.ErrorMessage(PhoneNum.Text, 5);
            int spec = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            if (function.errorCatch) return;

            string option = Session["option"].ToString();
            if (option == "add")
            {
                con.StartConection(Response);
                // Insert the values to the data base.
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `doctors` (`id`, `firstName`, `lastName`, `academicTitle`, `email`, `phoneNumber`, `specialization`)" +
                    $" VALUES (NULL, '{firstName}', '{lastName}', '{title}', '{email}', '{phone}', '{spec}')", con.connection);
                cmd.ExecuteNonQuery();
                con.CloseConection();
            }
            else if (option == "modify")
            {
                con.StartConection(Response);
                string id = Session["id"].ToString();
                // Modify the values in the data base.
                MySqlCommand cmd = new MySqlCommand($"UPDATE doctors SET firstName = '{firstName}', lastName = '{lastName}', " +
                    $"academicTitle = '{title}', email = '{email}', phoneNumber = '{phone}', specialization = '{spec}' WHERE id = {id}", con.connection);
                cmd.ExecuteNonQuery();
                con.CloseConection();
            }
            Response.Redirect("table.aspx");
        }
        // Refresh the red dot, when textbox is filed.
        protected void FirstName_TextChanged(object sender, EventArgs e) { B1.Visible = false; }
        protected void LastName_TextChanged(object sender, EventArgs e) { B2.Visible = false; }
        protected void Title_TextChanged(object sender, EventArgs e) { B3.Visible = false; }
        protected void Email_TextChanged(object sender, EventArgs e) { B4.Visible = false; }
        protected void PhoneNum_TextChanged(object sender, EventArgs e) { B5.Visible = false; }
    }
}