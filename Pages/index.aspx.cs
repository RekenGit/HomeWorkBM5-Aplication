using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWorkBM5_Aplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        readonly ConnectMySql con = new ConnectMySql();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.StartConection(Response);
            // Get id, firstName, lastName, academicTitle, email, phoneNumber, specialization form database.
            MySqlCommand cmd = new MySqlCommand("SELECT doctors.id, doctors.firstName, doctors.lastName, doctors.academicTitle, doctors.email, doctors.phoneNumber, " +
                "specialization.name as specialization FROM doctors, specialization where doctors.specialization = specialization.id", con.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Create DIV that hold all data of a doctor.
                HtmlGenericControl createDiv = new HtmlGenericControl("div");
                createDiv.Attributes.Add("class", "doctor");
                contentBox.Controls.Add(createDiv);

                // Create Header that show only firstname and lastname.
                HtmlGenericControl createDiv2 = new HtmlGenericControl("div");
                createDiv2.Attributes.Add("class", "doctorHeader");
                createDiv2.InnerHtml = $"<h3 style=\"float:left;\">{reader.GetString(1)} {reader.GetString(2)}</h3>";
                createDiv.Controls.Add(createDiv2);

                // Create View button that hide and unhide content.
                LinkButton button = new LinkButton();
                button.ID = "dhc_button_" + reader.GetValue(0);
                button.Attributes.Add("class", "viewButton");
                button.Text = "<i class=\"fa-solid fa-chevron-down\"></i>";
                button.Click += new EventHandler(Button_Generated);
                button.CommandArgument = "" + reader.GetValue(0);
                createDiv2.Controls.Add(button);

                // Create content DIV that contain all the data.
                HtmlGenericControl createDiv3 = new HtmlGenericControl("div");
                createDiv3.ID = "Content_" + reader.GetValue(0);
                createDiv3.Attributes.Add("class", "doctorHidenContent");
                createDiv3.Visible = false;
                createDiv3.InnerHtml = 
                    $"<div class=\"hiddenContentDivide\"><h3>Tytuł naukowy: </h3><h4>{reader.GetString(3)}</h4></div>"+
                    $"<div class=\"hiddenContentDivide\"><h3>Email: </h3><h4>{reader.GetString(4)}</h4></div>"+
                    $"<div class=\"hiddenContentDivide\"><h3>Numer telefonu: </h3><h4>{reader.GetString(5)}</h4></div>"+
                    $"<div class=\"hiddenContentDivide\"><h3>Specializacja: </h3><h4>{reader.GetString(6)}</h4></div>";
                contentBox.Controls.Add(createDiv3);

                // Create second MySQL connection to load all jobs.
                ConnectMySql quickConnect = new ConnectMySql();
                quickConnect.StartConection(Response);
                MySqlCommand cmd2 = new MySqlCommand($"SELECT jobName, cityName, streetName, streetNumber, apartment, zipCode, province FROM workplace WHERE doctorId = {reader.GetValue(0)}", quickConnect.connection);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2 != null)
                {
                    // Create Div that contain all workplaces that doctor have.
                    HtmlGenericControl createDiv4 = new HtmlGenericControl("div");
                    createDiv4.Attributes.Add("class", "doctorHidenJobs");
                    createDiv4.InnerHtml = "<br/><h2>Prace:</h2>";
                    createDiv3.Controls.Add(createDiv4);

                    while (reader2.Read())
                    {
                        // Create Div that contain specific job.
                        HtmlGenericControl createDiv5 = new HtmlGenericControl("div");
                        string local = reader2.GetValue(4).ToString() == "" ? "" : $" lok. {reader2.GetValue(4)}"; ;
                        createDiv5.InnerHtml = $"<h4>{reader2.GetValue(0)}</h4>"+
                            $"<p>{reader2.GetString(6)} </p>"+
                            $"<p>ul. {reader2.GetString(2)} {reader2.GetValue(3)}" + local + "<br>"+
                            $"{reader2.GetString(5)} {reader2.GetString(1)}</p>";
                        createDiv4.Controls.Add(createDiv5);
                        
                    }
                }
                quickConnect.CloseConection();
            }
            con.CloseConection();
        }
        // Table view button
        protected void Button_Table(object sender, EventArgs e)
        {
            Response.Redirect("table.aspx");
        }
        // View button function
        // If button is pressed then content is folded or unfolded.
        protected void Button_Generated(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            bool isVisible = contentBox.FindControl("Content_" + id).Visible;
            contentBox.FindControl("Content_" + id).Visible = !isVisible;

            LinkButton d1 = (LinkButton)contentBox.FindControl("dhc_button_" + id);
            if (isVisible) d1.Text = "<i class=\"fa-solid fa-chevron-down\"></i>";
            else d1.Text = "<i class=\"fa-solid fa-chevron-up\"></i>";
        }
    }
}