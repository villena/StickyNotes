using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication1.Aux_asp_forms
{
    public partial class Category_Notes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {
                String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string sql = "SELECT * FROM NOTES WHERE ID = " + int.Parse(Request.QueryString["id"]) + "ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder htmlStr = new StringBuilder("");

                //Panel p = new Panel();
                Panel p = new Panel();

                Label t = new Label();
                Label f = new Label();
                Image ie = new Image();
                ie.ImageUrl = "../Images/editButton.png";


                HyperLink le = new HyperLink();
                HyperLink lb = new HyperLink();
                Button b = new Button();

                while (reader.Read())
                {
                    p = new Panel();

                    t = new Label();
                    f = new Label();

                    le = new HyperLink();
                    lb = new HyperLink();


                    string id = reader["ID"].ToString();

                    p.ID = "p" + id;
                    p.CssClass = "postitnotes";
                    t.ID = "t" + id;

                    f.ID = "f" + id;
                    le.ID = "l" + id;
                    le.Text = "Editar" + "<BR>";
                    lb.Text = "Borrar";


                    // le.CssClass = "editButton";
                    //le.ImageUrl = "../Images/editButton.png";



                    // le.Controls.Add(ie);
                    le.NavigateUrl = "~/Asp_forms/Editnotes.aspx?ID=" + reader["ID"].ToString();
                    lb.NavigateUrl = "~/Asp_forms/Deletenote.aspx?ID=" + reader["ID"].ToString();
                    t.Text = reader["TEXT"].ToString() + "<BR>";

                    //f.Text =reader["CREATION_DATE"].ToString();

                    p.Controls.Add(t);
                    p.Controls.Add(f);
                    p.Controls.Add(le);
                    p.Controls.Add(lb);

                    Panel1.Controls.Add(p);
                }

                reader.Close();
                con.Close();
                //NotasPrueba.Text = htmlStr.ToString();


            }
        }
    }


}
