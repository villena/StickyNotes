using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace StickyNotesWeb.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["RefUrl"] != null) ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
            else
            {
                ViewState["RefUrl"] = "..//Default.aspx";
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            HttpCookie passCookie;

            userCookie = Request.Cookies["UserID"];
            passCookie = Request.Cookies["UserPass"];
            
            if (userCookie != null || passCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddMonths(-1);
                passCookie.Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies.Add(userCookie);
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

                    userCookie = new HttpCookie("UserID", myUser.Nick);
                    passCookie = new HttpCookie("UserPass", myUser.Pass);
                    userCookie.Expires = DateTime.Now.AddMonths(1);
                    passCookie.Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies.Add(userCookie);
                    Response.Cookies.Add(passCookie);
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