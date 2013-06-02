using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace StickyNotesWeb.Asp_forms
{
    public partial class UserTable : System.Web.UI.Page
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

                    String s;
                    s = Request.QueryString["ID"];
                    User_Class user = new User_Class();
                    int uid = -1;

                    if (s != null || s == "")
                    {

                        uid = Int32.Parse(s);
                        user=user.getUser(uid);
                        Name.Text = user.Name + " "+ user.Surname + " |";
                        Nick.Text = user.Nick;
                        HyperLink3.NavigateUrl = "~//Asp_forms/UserTable.aspx/?ID=" + uid.ToString();
                        HyperLink3.Text = user.Nick;
                        Page.Title = user.Nick;

                    }
                    else
                        Response.Redirect("~//Asp_forms/Friends.aspx");

                  
                    Panel p = new Panel();

                    Label t = new Label();
                    Label f = new Label();
                    Label a = new Label();

                    Panel psub = new Panel();

                    Note_Class note=new Note_Class();


                    user.Notes=note.getNotesUserOpen(uid);
  

                   foreach(Note_Class personalnote in user.Notes)
                    {
                        p = new Panel();
                        psub = new Panel();

                        t = new Label();
                        f = new Label();
                        a = new Label();

                        psub.CssClass = "default_panel";
                        psub.HorizontalAlign = HorizontalAlign.Right;


                        string id = personalnote.Id.ToString();

                        p.ID = "p" + id;
                        if (personalnote.Type == 'O')
                            p.CssClass = "postitnotes";
                        else if (personalnote.Type == 'P')
                            p.CssClass = "postitnotespink";
                        
                        t.ID = "t" + id;
                        f.ID = "f" + id;

                        t.Text = personalnote.Text.ToString() + "<BR>";
                        a.Text = "<br/>" + user.getUser(personalnote.Author).Nick;
                        a.CssClass = "noteauthor";

                        psub.Controls.Add(a);

                        p.Controls.Add(t);
                        p.Controls.Add(f);


                        p.Controls.Add(psub);
                        Panel1.Controls.Add(p);

                    }

                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }
            }
        }
    }
}