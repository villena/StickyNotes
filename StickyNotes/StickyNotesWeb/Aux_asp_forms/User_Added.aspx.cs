using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace StickyNotesWeb
{
    public partial class Formulario_web14 : System.Web.UI.Page
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

                    if (usuario_sesion.addFriend(int.Parse(Request.QueryString["id"])))
                    {
                        LabelHecho.Text = "<h2> User Added </h2>";
                        System.Threading.Thread.Sleep(5000);
                        Response.Redirect("../Asp_forms/Friends.aspx");
                    }
                    else
                    {
                        LabelHecho.Text = "<h2> Fail Adding User </h2>";
                        System.Threading.Thread.Sleep(5000);
                        Response.Redirect("../Asp_forms/Friends.aspx");
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