using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CargaBase(object sender, EventArgs e) {
            string s = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection c = new SqlConnection(s);
            c.Open();
            SqlCommand com = new SqlCommand("Select * from users", c);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                LabelPrueba.Text += "<p>" + dr["user"].ToString() + "<p>";
            }
        }
    }
}