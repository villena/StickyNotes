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
    public partial class Notes : System.Web.UI.Page
    {
        public int i;

        protected void increaseCounter()
        {
            i++;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /* Falta implementar las notas del usuario */



            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            con.Open();
            string sql = "SELECT TEXT FROM NOTES";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            StringBuilder htmlStr = new StringBuilder("");

            while (reader.Read())
            {
                htmlStr.Append("<div class = 'postit'>");
                htmlStr.Append(reader["TEXT"]);
                htmlStr.Append("<b>");
                htmlStr.Append(reader["CREATION_DATE"].ToString());
                htmlStr.Append("</b>");
                htmlStr.Append("</div>");
            }

            reader.Close();
            con.Close();
            NotasPrueba.Text = htmlStr.ToString();

            
        }

        protected void Create_Note(object sender, EventArgs e)
        {
            
            /* Create note with the button 'New Note' */
            Note_Class note = new Note_Class();
            note.Text = DescripcionNota.Text;
            note.Date = DateTime.Now.ToShortDateString();

            /* Add note in the Database */
            /*note.addNote();*/
        }

    }
}
