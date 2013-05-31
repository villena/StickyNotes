using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Formulario_web17 : System.Web.UI.Page
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
                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }
            }
        }
        protected void ChangeData(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            User_Class usuario_sesion = new User_Class();
            usuario_sesion = usuario_sesion.getUser(userCookie.Value);

            if (Email.Text != "")
            usuario_sesion.Email = Email.Text;
            if (Name.Text != "")
            usuario_sesion.Name = Name.Text;
            if (Surname.Text != "")
            usuario_sesion.Surname = Surname.Text;
            if (RadioButtonList1.Items[0].Selected) usuario_sesion.Gender = 'F';
            else if(RadioButtonList1.Items[1].Selected) usuario_sesion.Gender = 'M';
            if (ImageUrl.Text != "") usuario_sesion.Image_url = ImageUrl.Text;

            userCookie = new HttpCookie("UserID", usuario_sesion.Nick);
            userCookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(userCookie);
            if(usuario_sesion.updateUser())
            Label1.Text = "Done!";
        }
    }
}