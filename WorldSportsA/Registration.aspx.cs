using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WorldSportsA
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlDataReader reader = null;
        SqlCommand cmd = null;
        string query = "";
        string conString = "minidbConnectionString";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace((string)Session["username"]))
            {
                Response.Redirect("Registration.aspx");
            }

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings[conString].ConnectionString);
        }

        protected void signup_Click(object sender, EventArgs e)
        {

            string FirstName = txtfname.Text;
            string LastName = txtlname.Text;
            string Email = txtemailaddress.Text;
            string Username = txtUsername.Text;
            string Password = txtpassword.Text;

            conn.Open();

            query = "INSERT INTO [User](FirstName, LastName, Email, Username, Password) VALUES(@FirstName, @LastName, @Email, @Username, @Password)";

            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Username", Username);            
            cmd.Parameters.AddWithValue("@Password", Password);


            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            query = "SELECT Email FROM [User] WHERE Email=@getUser";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@getUser", Email);

            reader = cmd.ExecuteReader();
            reader.Read();
            Email = reader.GetString(0);
            reader.Close();

            conn.Close();
            Response.Redirect("Login.aspx");

        }
    }
}