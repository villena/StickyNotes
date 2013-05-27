using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            User_Class usuario_sesion = new User_Class();
            usuario_sesion = usuario_sesion.getUser(userCookie.Value);

            usuario_sesion.deleteFriend(int.Parse(Request.QueryString["id"]));
            Response.Redirect("../Asp_forms/Friends.aspx");
        }
    }
}