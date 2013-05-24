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
            userCookie = Request.Cookies["UserID"];
            User_Class usuario_sesion = new User_Class();
            usuario_sesion = usuario_sesion.getUser(userCookie.Value);
            CompareValidator pass = new CompareValidator();
            pass.ID = "CorrectPasswordCompare";
            pass.ValueToCompare = usuario_sesion.Pass;
            pass.ControlToValidate = "CurrentPassword";
            pass.CssClass = "failureNotification";
            pass.ErrorMessage = "*</br>The passwords is not correct.";
            CurrentPasswordRequired.Controls.Add(pass);
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
