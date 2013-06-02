using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication1.Asp_forms
{
    public partial class Groups_Notes : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {

            Page.MaintainScrollPositionOnPostBack = true;

            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {

           

                string s = Request.QueryString["ID"];
                if (s != null && s!="")
                {

                    Party_Class party = new Party_Class();
                    party.Id = Int32.Parse(s);
                    party.obtainNotes();
                    party.getName();
                    Label1.Text = party.Name;

                    HyperLink3.NavigateUrl = "~/Asp_forms/Groups_Notes.aspx?ID=" + party.Id;
                    HyperLink3.Text = party.Name;


                    Panel p = new Panel();
                    Label t = new Label();
                    Label f = new Label();
                    Label a = new Label();
                                                          
                    Button b = new Button();
                    ImageButton imgbuttone = new ImageButton();
                    ImageButton imgbuttonb = new ImageButton();

                    Panel psub = new Panel();
                                     

                    User_Class userTemp = new User_Class();
                    userTemp = userTemp.getUser(userCookie.Value);

                    User_Class userNote = new User_Class();
                    



                    foreach (Note_Class note in party.Notes)
                    {

                        p = new Panel();
                        a = new Label();
                        userNote = new User_Class();
                        psub = new Panel();

                        t = new Label();
                        f = new Label();

                       

                        imgbuttone = new ImageButton();
                        imgbuttonb = new ImageButton();

                        imgbuttone.ImageUrl = "../Images/editButton.png";
                        imgbuttone.PostBackUrl = "~/Asp_forms/Editnotes.aspx?ID=" + note.Id.ToString();
                        imgbuttone.Width = 30;

                        imgbuttonb.ImageUrl = "../Images/deleteButton.png";
                        imgbuttonb.PostBackUrl = "~/Asp_forms/Deletenote.aspx?ID=" + note.Id.ToString();
                        
                        imgbuttonb.Width = 30;
                        imgbuttonb.ToolTip = "Delete";
                        imgbuttone.ToolTip = "Edit";

                        psub.CssClass = "default_panel";
                        psub.HorizontalAlign = HorizontalAlign.Right;

                        psub.Controls.Add(imgbuttonb);
                        psub.Controls.Add(imgbuttone);


                        string id = note.Id.ToString();

                        p.ID = "p" + id;
                        p.CssClass = "postitnotesblue";
                        t.ID = "t" + id;

                        f.ID = "f" + id;
                       
                        t.Text = note.Text.ToString() + "<BR><BR>";
                        a.Text = "<BR>"+userNote.getUser(note.Author).Nick;
                        a.CssClass = "noteauthor";


                        p.Controls.Add(t);
                        p.Controls.Add(f);
                        //p.Controls.Add(a);

                        psub.Controls.Add(a);
                        p.Controls.Add(psub);

                        Panel1.Controls.Add(p);

 
                    }

                }
                else
                    Response.Redirect("~/Asp_forms/Groups.aspx");




            
        }
     }

        protected void Create_Note(object sender, EventArgs e)
        {

             HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {
             
             string s = Request.QueryString["ID"];
             if (s != null)
             {
                 Party_Class party = new Party_Class();
                 party.Id = Int32.Parse(s);

                 User_Class user = new User_Class();
                 user = user.getUser(userCookie.Value);

                 Note_Class note = new Note_Class();
                 note.Text = DescripcionNota.Text;
                 note.Date = DateTime.Now.ToShortDateString();

                 if (party.addNote(note, user.Id))
                 {
                     Page.MaintainScrollPositionOnPostBack = true;
                     Response.Redirect("~/Asp_forms/Groups_Notes.aspx?ID=" + party.Id);
                 }
                 else
                     Label2.Text = "An error has occurred";
             }

            }

            /* Create note with the button 'New Note' */
                 
        }

        protected void Delete(object sender, EventArgs e)
        {

             string s = Request.QueryString["ID"];
             if (s != null)
             {
                 Party_Class party = new Party_Class();
                 party.Id = Int32.Parse(s);

                 if (party.deleteParty())
                 {
                     Response.Redirect("~/Asp_forms/Groups.aspx");
                 }
                 else
                 {
                     Label l = new Label();
                     l.Text = "An error has occurred. Please clean up the cork table before perform this action.";
                     Panel2.Controls.Add(l);
                 }

             }
        }


        
    }

}
