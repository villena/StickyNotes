using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace StickyNotesWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            HttpCookie passCookie;
            userCookie = Request.Cookies["UserID"];
            passCookie = Request.Cookies["UserPass"];
            if (userCookie == null || passCookie == null)
            {

            }
            else
            {
                User_Class myUser = new User_Class();
                myUser = myUser.getUser(userCookie.Value);
                if (myUser.Pass == passCookie.Value)
                {
                    Label1.Text = "Welcome " + myUser.Nick;
                    UserLabel.Visible = false;
                    UserName.Visible = false;
                    PasswordLabel.Visible = false;
                    Password.Visible = false;
                    Button1.Visible = false;
                    Button3.Visible = false;
                    Button2.Visible = true;
                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }
            } 

            if (!IsPostBack)
            {
                if (ViewState["RefUrl"] != null) ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
        }

        protected void Login_Master(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            HttpCookie passCookie;
            userCookie = Request.Cookies["UserID"];
            passCookie = Request.Cookies["UserPass"];
            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddMonths(-1);                
                Response.Cookies.Add(userCookie);
            }
            if (passCookie != null)
            { 
                passCookie.Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies.Add(passCookie);
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

                    userCookie = new HttpCookie("UserID", myUser2.Nick);
                    passCookie = new HttpCookie("UserPass", myUser2.Pass);
                    userCookie.Expires = DateTime.Now.AddMonths(1);
                    passCookie.Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies.Add(userCookie);
                    Response.Cookies.Add(passCookie);
                    Label1.Text = "Welcome " + myUser.Nick;
                    UserLabel.Visible = false;
                    UserName.Visible = false;
                    PasswordLabel.Visible = false;
                    Password.Visible = false;
                    Button1.Visible = false;
                    Button3.Visible = false;
                    Button2.Visible = true;

                    if (HttpContext.Current.Request.Url.LocalPath == "/default.aspx" || HttpContext.Current.Request.Url.LocalPath == "/Default.aspx" || HttpContext.Current.Request.Url.LocalPath == "/About.aspx")
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    else
                    {
                        Response.Redirect("../Default.aspx");
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
        protected void LogOut_Master(object sender, EventArgs e)
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
                Response.Cookies.Add(passCookie);
                Response.Redirect(Request.RawUrl);
            }


            Label1.Text = "";

            UserLabel.Visible = true;
            UserName.Visible = true;
            PasswordLabel.Visible = true;
            Password.Visible = true;
            Button1.Visible = true;
            Button3.Visible = true;
            Button2.Visible = false;
        }

        protected void SignUp(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Register2.aspx");
        }
    }
}
