using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeWorkBM5_Aplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        connectMySql con = new connectMySql();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.StartConection();
            MySqlCommand cmd = new MySqlCommand("SELECT id, firstName, secondName FROM doctors", con.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Response.Write("<script>test("+reader.GetString(1)+");</script>");
                HtmlGenericControl createDiv = new HtmlGenericControl("div");
                createDiv.Attributes.Add("class", "doctor");
                createDiv.InnerHtml = 
                    "<div class=\"normal\"> \n"+
                        "<h3 style=\"float:left;\">" + reader.GetString(1) + " " + reader.GetString(2) + "</h3> \n" +
                        //"<button OnClick=\"Button_Generated\" style=\"float:right;\"><i class=\"fa-solid fa-chevron-down\"></i></button> \n" +
                        //"<asp:Button ID=\"Button_"+ reader.GetValue(0)+ "\" runat=\"server\" OnClick=\"Button_Generated\" Text=\"<i class=\"fa-solid fa-chevron-down\"></i>\" />" +
                    "</div> \n" +
                    "<div class=\"\"></div> \n";
                //createDiv.InnerHtml = "document.getElementById('contentBox').innerHTML = \""+newDoctor+"\";";

                contentBox.Controls.Add(createDiv);

                Button button = new Button();
                button.Text = "Edit";
                button.UseSubmitBehavior = false;
                button.Click += new EventHandler(Button_Generated);
                button.CommandArgument = ""+reader.GetValue(0);
                contentBox.Controls.Add(button);
            }
            con.CloseConection();
        }

        protected void Button_Add(object sender, EventArgs e)
        {
            Response.Redirect("addDoctor.aspx");
        }
        protected void Button_Remove(object sender, EventArgs e)
        {
            
        }
        protected void Button_Table(object sender, EventArgs e)
        {
            Response.Redirect("table.aspx");
        }

        protected void Button_Generated(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            Response.Write("<script>console.log('"+ but.CommandArgument.ToString() + "');</script>");
        }
    }
}