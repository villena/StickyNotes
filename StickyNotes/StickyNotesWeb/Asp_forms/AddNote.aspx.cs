using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace StickyNotesWeb.Asp_forms
{
    public partial class AddNote : System.Web.UI.Page
    {
        User_Class user;
        List<User_Class> usersToAdd=new List<User_Class>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            HttpCookie passCookie;

            userCookie = Request.Cookies["UserID"];
            passCookie = Request.Cookies["UserPass"];

            if (userCookie == null || passCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {
                User_Class usuario_sesion = new User_Class();
                usuario_sesion = usuario_sesion.getUser(userCookie.Value);

                if (usuario_sesion.Pass == passCookie.Value)
                {
                    if (!IsPostBack)
                    {
                        ListBox1.Items.Clear();
                        ListBox2.Items.Clear();
                        ListBox3.Items.Clear();
                        ListBox1.Width = 100;
                        ListBox1.Height = 60;
                        // ListBox1.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
                        ListBox2.Width = 150;
                        ListBox3.Width = 150;

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
                            ListBox2.Items.Add(l);
                            i++;
                        }

                        ListItem o = new ListItem("Public", "0");
                        ListItem p = new ListItem("Private", "1");
                        ListBox1.Items.Add(o);
                        ListBox1.Items.Add(p);

                    }
                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }

            }


        }

        protected void Add(object sender, EventArgs e)
        {
            ListItem l = new ListItem();

            foreach (ListItem li in ListBox2.Items)
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

            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected == true)
                {
                    if (Int32.Parse(li.Value) == 0)
                    {
                        note.Type = 'O';
                    }
                    else if (Int32.Parse(li.Value) == 1)
                    {
                        note.Type = 'P';
                    }                 

                }
            }
            

            Category_Class category = new Category_Class();
            if (TextBox2.Text != null && TextBox2.Text != "")
            {
                category.Nombre = TextBox2.Text;
                note.Category = category.getCategoryId();
            }
            else
                note.Category = -1;

            List<User_Class> users = new List<User_Class>();
            int indice = 0;
            foreach (ListItem li in ListBox2.Items)
            {
                indice = Int32.Parse(li.Value);
                users.Add(user.Friends[indice]);
            }

            if (note.Type!=' ' && note.addNote(user.Id, users))
                Response.Redirect("../Asp_forms/Notes.aspx");
            else
                Label4.Text = "An error has occurred";


        }
    }
}