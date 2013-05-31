using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1.Asp_forms
{
    public partial class Create_Group : System.Web.UI.Page
    {

        //int last = 0;
        User_Class user;
        List<User_Class> usersToAdd=new List<User_Class>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
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
                    //ListBox ListBox1 = new ListBox();
                    ListBox1.Items.Clear();
                    ListBox1.Width = 150;
                    ListBox1.Height = 200;
                    ListBox2.Width = 150;
                    ListBox2.Height = 200;

                    user = new User_Class();
                    user = user.getUser(userCookie.Value);

                    user.getFriends();

                   


                    int i = 0;

                    ListItem l = new ListItem();
                    while (i < user.Friends.Count)
                    {
                        l = new ListItem();

                        l.Text = user.Friends[i].Nick;
                        l.Value = i.ToString();
                        ListBox1.Items.Add(l);
                        i++;
                    }


                    //  this.Controls.Add(ListBox1);

                }
            }


        }

        protected void Add(object sender, EventArgs e)
        {
            
            ListItem l = new ListItem();

         
            
            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected==true)
                {
                   
                    l = new ListItem();
                   
                    l.Value = li.Value;
                    l.Text = li.Text;
                    ListBox2.Items.Add(l);
                    li.Enabled = false;
                }
            }
             
        }

        protected void SendGroup(object sender, EventArgs e)
        {

            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            user = new User_Class();
            user = user.getUser(userCookie.Value);
            user.getFriends();

            Party_Class newParty = new Party_Class();
            newParty.Name = TextBox1.Text;
            
            Label3.Text = ListBox2.Items.Count.ToString();
            int indice=0;

            newParty.Users.Add(user);

            foreach (ListItem li in ListBox2.Items)
            {
                indice = Int32.Parse(li.Value);
                newParty.Users.Add(user.Friends[indice]);  
            }


            if (ListBox2.Items.Count == 0 || TextBox1.Text == "")
            {
                Label3.Text = "Add users and set Name.";
            }
            else
            {
                if (newParty.createParty())
                    Response.Redirect("..//Asp_forms/Groups.aspx");
                else
                    Label3.Text = "error";
            }
        }

        protected void RemoveUser(object sender, EventArgs e)
        {

            ListItem l = new ListItem();
            foreach (ListItem li in ListBox2.Items)
            {
                if (li.Selected == true)
                {

                    l = new ListItem();

                    l.Value = li.Value;
                    l.Text = li.Text;
                    ListBox1.Items.Add(l);
                    li.Enabled = false;

                }
            }
        }
    }
}