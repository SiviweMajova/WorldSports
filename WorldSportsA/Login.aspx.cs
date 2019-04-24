using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WorldSportsA
{
    public partial class Login : System.Web.UI.Page
    {
        string query = "";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        string conString = "minidbConnectionString";
        string sesh;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace((string)Session["Username"]))
            {
                Response.Redirect("Login.aspx");
                sesh = Session["Username"].ToString();
                Session.Add("Username", login.Text);

            }
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings[conString].ConnectionString);

        }

        protected void saveForm_Click(object sender, EventArgs e)
        {
            string Password = password.Text;
            string Email = login.Text;
            query = "select * from [User] where Email=@Email AND Password=@Password";
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                    Response.Redirect("/allteams");

            }
        }
    }
}