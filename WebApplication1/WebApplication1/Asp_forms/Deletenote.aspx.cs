using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1.Asp_forms
{
    public partial class Deletenote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String s;
            s = Request.QueryString["ID"];

            if (s != null)
            {

                int id = Int32.Parse(s);

                 

                Note_Class note = new Note_Class();

                note.Id = id;

                if (note.deleteNote())
                    Response.Redirect("..//Asp_forms/Notes.aspx");
                else
                {
                    Label l = new Label();
                      
                    l.Text = "An error has occurred, please try again later.";
                    Panel1.Controls.Add(l);
                }
                   



                
            }
        }
    }
}