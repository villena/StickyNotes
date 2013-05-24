using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Formulario_web13 : System.Web.UI.Page
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

                Image1.ImageUrl = usuario_sesion.Image_url;
                Label1.Text = usuario_sesion.Nick;
                Label2.Text = usuario_sesion.Name;
                Label3.Text = usuario_sesion.Surname;
                Label4.Text = usuario_sesion.Email;
                Label5.Text = usuario_sesion.Gender.ToString();
                Label6.Text = usuario_sesion.Entry_date;
                Label7.Text = usuario_sesion.Birth_date;
            }

        }
    }
}