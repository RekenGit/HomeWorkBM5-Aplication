using MySql.Data.MySqlClient;
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
        connectMySql con = new connectMySql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con.StartConection();
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
        protected void Button_Back(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        bool errorCatch;
        protected void Button_Send(object sender, EventArgs e)
        {
            errorCatch = false;
            string firstName = errorMessage(FirstName.Text, "Imię");
            string secoundName = errorMessage(SecondName.Text, "Nazwisko");
            string title = errorMessage(Title.Text, "Tytuł naukowy");
            string email = errorMessage(Email.Text, "Email");
            string phone = errorMessage(PhoneNum.Text, "Numer telefonu");
            int spec = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            if (errorCatch) return;

            con.StartConection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `doctors` (`id`, `firstName`, `secondName`, `academicTitle`, `email`, `phoneNumber`, `specialization`)" +
                $" VALUES (NULL, '{firstName}', '{secoundName}', '{title}', '{email}', '{phone}', '{spec}')", con.connection);
            cmd.ExecuteNonQuery();
            con.CloseConection();
        }
        string errorMessage(string str, string err)
        {
            if (str == "")
            {
                errorCatch = true;
                ErrorMessage.Visible = true;
                ErrorMessage.InnerHtml = "UWAGA: Nie uzupełniono wszystkich wymaganych pól.";
                switch (err)
                {
                    case "Imię":
                        B1.Visible = true;
                        break;
                    case "Nazwisko":
                        B2.Visible = true;
                        break;
                    case "Tytuł naukowy":
                        B3.Visible = true;
                        break;
                    case "Email":
                        B4.Visible = true;
                        break;
                    case "Numer telefonu":
                        B5.Visible = true;
                        break;
                }
                return null;
            }

            ErrorMessage.Visible = false;
            return str;
        }

        protected void FirstName_TextChanged(object sender, EventArgs e) { B1.Visible = false; }
        protected void SecondName_TextChanged(object sender, EventArgs e) { B2.Visible = false; }
        protected void Title_TextChanged(object sender, EventArgs e) { B3.Visible = false; }
        protected void Email_TextChanged(object sender, EventArgs e) { B4.Visible = false; }
        protected void PhoneNum_TextChanged(object sender, EventArgs e) { B5.Visible = false; }
    }
}