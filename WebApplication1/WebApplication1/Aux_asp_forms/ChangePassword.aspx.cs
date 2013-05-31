using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1.Account
{
    public partial class ChangePassword : System.Web.UI.Page
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
                    CompareValidator pass = new CompareValidator();
                    pass.ID = "CorrectPasswordCompare";
                    pass.ValueToCompare = usuario_sesion.Pass;
                    pass.ControlToValidate = "CurrentPassword";
                    pass.CssClass = "failureNotification";
                    pass.ErrorMessage = "*</br>The passwords is not correct.";
                    CurrentPasswordRequired.Controls.Add(pass);
                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }
            }
        }

        protected void Change_Pass(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            User_Class usuario_sesion = new User_Class();
            usuario_sesion = usuario_sesion.getUser(userCookie.Value);
            usuario_sesion.Pass = NewPassword.Text;
            usuario_sesion.changePass(NewPassword.Text);
            Response.Redirect("./ChangePasswordSuccess.aspx");
        }
    }
}
