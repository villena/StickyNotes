using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Register2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            User_Class newUser = new User_Class();

            newUser.Pass = Password.Text;
            newUser.Nick = UserName.Text;
            newUser.Email = Email.Text;
            

            if (!newUser.existeUsuario(newUser.Nick))
            {
                newUser.addUser();
            }

            Label1.Text = newUser.Nick;
            

        }
    }
}