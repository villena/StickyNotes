using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {
                User_Class usuario_sesion = new User_Class();
                usuario_sesion = usuario_sesion.getUser(userCookie.Value);
                if (!usuario_sesion.isFriend(int.Parse(Request.QueryString["id"]))) { Response.Redirect("../Asp_forms/Friends.aspx?all=yes"); }
                User_Class usuario_friend = new User_Class();
                usuario_friend = usuario_friend.getUser(int.Parse(Request.QueryString["id"]));

                Image1.ImageUrl = usuario_friend.Image_url;
                Label1.Text = usuario_friend.Nick;
                Label2.Text = usuario_friend.Name;
                Label3.Text = usuario_friend.Surname;
                Label4.Text = usuario_friend.Email;
                Label5.Text = usuario_friend.Gender.ToString();
                Label6.Text = usuario_friend.Entry_date;
                Label7.Text = usuario_friend.Birth_date;
            }


        }
    }
}