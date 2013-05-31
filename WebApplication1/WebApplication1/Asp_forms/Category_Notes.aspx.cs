using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication1
{
    public partial class Category_Notes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            HttpCookie passCookie;

            userCookie = Request.Cookies["UserID"];
            passCookie = Request.Cookies["UserPass"];

            if (userCookie == null || passCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {
                User_Class usuario_sesion = new User_Class();
                usuario_sesion = usuario_sesion.getUser(userCookie.Value);

                if (usuario_sesion.Pass == passCookie.Value)
                {
                    String id = Request.QueryString["id"];
                    String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string sql = "SELECT * FROM NOTES WHERE CATEGORY_ID = " + id;
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

                        Panelnota.Controls.Add(p);
                    }

                    reader.Close();
                    con.Close();
                    //NotasPrueba.Text = htmlStr.ToString();


                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }
            }
        }
        protected void Create_Note(object sender, EventArgs e)
        {

            /* Create note with the button 'New Note' */
            Note_Class note = new Note_Class();
            note.Text = DescripcionNota.Text;
            note.Date = DateTime.Now.ToShortDateString();

            /* Add note in the Database */
            note.addNote(1);
            Response.AppendHeader("Refresh", "0;URL=Notes.aspx");

        }


        public HyperLink le { get; set; }
    }


}
