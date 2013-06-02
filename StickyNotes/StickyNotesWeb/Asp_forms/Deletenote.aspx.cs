using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace StickyNotesWeb.Asp_forms
{
    public partial class Deletenote : System.Web.UI.Page
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
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }
            }
        }
    }
}