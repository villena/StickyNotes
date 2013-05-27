using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1.Asp_forms
{
    public partial class AddNote : System.Web.UI.Page
    {
        User_Class user;
        List<User_Class> usersToAdd=new List<User_Class>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ListBox1.Items.Clear();
                    ListBox2.Items.Clear();
                    ListBox3.Items.Clear();
                    ListBox1.Width = 100;
                    ListBox2.Width = 100;
                    ListBox3.Width = 100;

                    user = new User_Class();
                    user = user.getUser(userCookie.Value);
                    user.getFriends();

                    int i = 0;

                    ListItem l = new ListItem();
                    while (i < user.Friends.Count)
                    {
                        l = new ListItem();

                        l.Text = user.Friends[i].Name;
                        l.Value = i.ToString();
                        ListBox2.Items.Add(l);
                        i++;
                    }
                }

            }


        }

        protected void Add(object sender, EventArgs e)
        {
            ListItem l = new ListItem();

            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected == true)
                {

                    l = new ListItem();
                   
                    l.Value = li.Value;
                    l.Text = li.Text;
                    ListBox3.Items.Add(l);
                    
                }
            }

        }

        protected void Send(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            user = new User_Class();
            user = user.getUser(userCookie.Value);
            user.getFriends();

            Note_Class note = new Note_Class();

            note.Text = TextBox1.Text;
            note.Date = DateTime.Now.ToShortDateString();

            Category_Class category = new Category_Class();
            
            //note.Category = TextBox2.Text;

        }
    }
}