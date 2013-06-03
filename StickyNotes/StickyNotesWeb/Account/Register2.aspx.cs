using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;
using System.Net.Mail;
using System.Net;
using System.Text;


namespace StickyNotesWeb
{
    public partial class Register2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;


            HttpCookie userCookie;
            HttpCookie passCookie;

            userCookie = Request.Cookies["UserID"];
            passCookie = Request.Cookies["UserPass"];

            if (userCookie == null || passCookie == null)
            {


                if (!IsPostBack)
                {
                    ListBox1.Items.Clear();
                    ListBox1.Width = 100;
                    ListBox1.Height = 60;
                    ListItem f = new ListItem("Female", "0");
                    ListItem m = new ListItem("Male", "1");
                    ListBox1.Items.Add(f);
                    ListBox1.Items.Add(m);
                }
            }
            else
            {
                Response.Redirect("..//Default.aspx");
            }


        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            User_Class newUser = new User_Class();

            newUser.Name = Name.Text;
            newUser.Surname = Surname.Text;
            newUser.Pass = Password.Text;
            newUser.Nick = UserName.Text;
            newUser.Email = Email.Text;

            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected == true)
                {
                    if (Int32.Parse(li.Value) == 0)
                    {
                        newUser.Gender = 'F';
                    }
                    else if (Int32.Parse(li.Value) == 1)
                    {
                        newUser.Gender = 'M';
                    }

                }
            }

            newUser.Entry_date = DateTime.Now.ToShortDateString();
            newUser.Birth_date = Calendar1.SelectedDate.ToString();
            newUser.Image_url = "../Images/no_image.jpeg";


            if (!newUser.existeUsuario(newUser.Nick))
            {
                newUser.addUser();

                string subject = "[Thanks for signing up Sticky Notes]";
                MailMessage mail = new MailMessage();
                mail.To.Add(Email.Text);
                mail.From = new MailAddress("stickynotes.hada@gmail.com");
                mail.Subject = subject;
                mail.Body = "Thanks by have been registered in Sticky Notes.\n\nYour User information is:\nUser: " + UserName.Text + "\nPass: " + Password.Text + "\n\nI hope you enjoy our social network.\nSticky Notes’ team.";
                mail.IsBodyHtml = false;
                mail.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("stickynotes.hada@gmail.com", "projecthada");
                smtp.Send(mail);

                Response.Redirect("..//Account/Login.aspx");

                Response.Redirect("..//Account/Login.aspx");
            }
            else
            {
               // RequiredFieldValidator sameUser = new RequiredFieldValidator();
                //sameUser.ErrorMessage = "The user already exists.";

                SameUserfailure.Text = "This UserName already exists.";
            }
            

        }
    }
}