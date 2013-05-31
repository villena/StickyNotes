using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1.Asp_forms
{
    public partial class RemoveUserFromEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Events_Class event = new Events_Class();

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

                        User_Class myUser = new User_Class();
                        myUser = myUser.getUser(userCookie.Value);

                        Events_Class events = new Events_Class();
                        events = events.getEvent(id);
                        events.removeUser(myUser);
                        //Label1.Text = events.ToString();
                        Response.Redirect("..//Asp_forms/Events.aspx");


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