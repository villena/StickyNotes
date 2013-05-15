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
            User_Class usuario_friend = new User_Class();
            usuario_friend = usuario_friend.getUser(int.Parse(Request.QueryString["id"]));

            Image1.ImageUrl = usuario_friend.Image_url;
            Label3.Text = usuario_friend.Name;
            Label4.Text = usuario_friend.Surname;
            Label5.Text = usuario_friend.Email;


        }
    }
}