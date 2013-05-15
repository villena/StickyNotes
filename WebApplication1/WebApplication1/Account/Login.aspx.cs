using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["RefUrl"] != null) ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies.Add(userCookie);
            }
            else
            {
                ViewState["RefUrl"] = "..//Default.aspx";
            }

            User_Class myUser = new User_Class();
            User_Class myUser2 = new User_Class();

            myUser.Nick = UserName.Text;
            myUser.Pass = Password.Text;
            object refUrl = ViewState["RefUrl"];

            if (myUser.existeUsuario(myUser.Nick))
            {
                myUser2 = myUser.getUser(myUser.Nick);
                if (myUser.Pass == myUser2.Pass)
                {

                    userCookie = new HttpCookie("UserId", myUser.Nick);
                    userCookie.Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies.Add(userCookie);
                    Label1.Text = (string)refUrl;
                    if (refUrl != null)
                    {
                        Response.Redirect((string)refUrl);
                    }
                }
                else
                {
                    Label1.Text = "Contraseña incorrecta";
                }

            }
            else
            {
                Label1.Text = "No existe el usuario";
            }
        }
    }
}