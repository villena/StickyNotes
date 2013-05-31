using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;


namespace WebApplication1
{
    public partial class AddEvents : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cuando refresca la pagina, mantiene el cursor en la posicion en la que estaba.
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
                    User_Class myUser = new User_Class();
                    myUser = myUser.getUser(userCookie.Value);

                    Events_Class events = new Events_Class();

                    myUser.getFriends();

                    ListBox1.Items.Clear();
                    ListBox1.Width = 100;
                    ListBox2.Width = 100;

                    int i = 0;

                    ListItem l = new ListItem();

                    while (i < myUser.Friends.Count)
                    {
                        l = new ListItem();

                        l.Text = myUser.Friends[i].Name;
                        l.Value = i.ToString();
                        ListBox1.Items.Add(l);
                        i++;
                    }
                }
            }
        }

        protected void newEvent(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];

            User_Class myUser = new User_Class();
            myUser = myUser.getUser(userCookie.Value);
            myUser.getFriends();

            Events_Class events = new Events_Class();
            //events.Date = TextBoxDate.Text;
            //TextBoxDate.Text = "disabled";

            events.Date = Calendar1.SelectedDate.ToString();
            events.Location = TextBoxLocation.Text;
            events.Description = TextBoxDescription.Text;
            int indice = 0;

            events.Users.Add(myUser);

            foreach (ListItem li in ListBox2.Items)
            {
                indice = Int32.Parse(li.Value);
                events.Users.Add(myUser.Friends[indice]);

            }

            events.addEvent();
            Response.Redirect("Events.aspx", true);

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
                    ListBox2.Items.Add(l);
                    li.Enabled = false;
                    
                }
            }
        }

        protected void Remove(object sender, EventArgs e)
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