using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["RefUrl"] != null) ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
        }

        protected void Login_Master(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies.Add(userCookie);
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
                    Label1.Text = "Welcome " + myUser.Nick;
                    UserLabel.Visible = false;
                    UserName.Visible = false;
                    PasswordLabel.Visible = false;
                    Password.Visible = false;
                    Button1.Visible = false;
                    Button2.Visible = true;

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
        protected void LogOut_Master(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies.Add(userCookie);
            }

            Label1.Text = "";

            UserLabel.Visible = true;
            UserName.Visible = true;
            PasswordLabel.Visible = true;
            Password.Visible = true;
            Button1.Visible = true;
            Button2.Visible = false;
        }
    }
}
