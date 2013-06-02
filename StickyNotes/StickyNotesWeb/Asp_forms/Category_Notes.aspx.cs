using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;
using System.Data.SqlClient;
using System.Text;

namespace StickyNotesWeb
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
                    int categoryid = int.Parse(Request.QueryString["id"]);
                    Category_Class category = new Category_Class();
                    category = category.getCategoria(categoryid);
                    
                    CategoryLabel.Text = category.Nombre + " Notes";
                    Panel p = new Panel();

                    Label t = new Label();
                    Label f = new Label();
                    Image ie = new Image();
                    ie.ImageUrl = "../Images/editButton.png";
                    ImageButton imgbuttone = new ImageButton();
                    ImageButton imgbuttonb = new ImageButton();

                    Panel psub = new Panel();


                    Note_CAD notaTemp = new Note_CAD();
                    List<Note_Class> notes = new List<Note_Class>();

                    User_Class userTemp = new User_Class();
                    userTemp = userTemp.getUser(userCookie.Value);

                    notes = notaTemp.notesCategory(userTemp.Id, category.Id);

                    int i = notes.Count() - 1;
                    if (notes.Count() == 0)
                    {
                        noCategories.Text = "No " + category.Nombre + " notes found. Start creating one up here!";
                    }
                    else
                    {
                        while (i >= 0)
                        {
                            p = new Panel();
                            psub = new Panel();

                            t = new Label();
                            f = new Label();

                            imgbuttone = new ImageButton();
                            imgbuttonb = new ImageButton();

                            imgbuttone.ImageUrl = "../Images/editButton.png";
                            imgbuttone.PostBackUrl = "~/Asp_forms/Editnotes.aspx?ID=" + notes[i].Id.ToString();
                            imgbuttone.Width = 30;
                            imgbuttone.ToolTip = "Edit";

                            imgbuttonb.ImageUrl = "../Images/deleteButton.png";
                            imgbuttonb.PostBackUrl = "~/Asp_forms/Deletenote.aspx?ID=" + notes[i].Id.ToString();
                            imgbuttonb.Width = 30;
                            imgbuttonb.ToolTip = "Delete";

                            psub.CssClass = "default_panel";
                            psub.HorizontalAlign = HorizontalAlign.Right;

                            psub.Controls.Add(imgbuttonb);
                            psub.Controls.Add(imgbuttone);



                            string id = notes[i].Id.ToString();

                            p.ID = "p" + id;
                            p.CssClass = "postitnotes";
                            t.ID = "t" + id;
                            f.ID = "f" + id;

                            t.Text = notes[i].Text.ToString() + "<BR>";

                            p.Controls.Add(t);
                            p.Controls.Add(f);


                            p.Controls.Add(psub);
                            Panelnota.Controls.Add(p);

                            i--;
                        }

                    }
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
            /* Note_Class note = new Note_Class();
             note.Text = DescripcionNota.Text;
             note.Date = DateTime.Now.ToShortDateString();*/

            /* Add note in the Database */
            /* HttpCookie userCookie;
             userCookie = Request.Cookies["UserID"];
             User_Class userTemp = new User_Class();
             userTemp = userTemp.getUser(userCookie.Value);
             note.addNote(userTemp.Id);
             Response.AppendHeader("Refresh", "0;URL=Notes.aspx");*/

            Response.Redirect("../Asp_forms/AddNote.aspx");

        }


        public HyperLink le { get; set; }
    }


}
