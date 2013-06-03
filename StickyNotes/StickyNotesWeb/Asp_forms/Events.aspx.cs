using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace StickyNotesWeb
{
    public partial class Events : System.Web.UI.Page
    {
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
                    User_Class myUser = new User_Class();
                    myUser = myUser.getUser(userCookie.Value);

                    Events_Class events = new Events_Class();
                    List<Events_Class> eventsList = new List<Events_Class>();

                    eventsList = events.userEvents(myUser.Id);

                    int totalEvents = eventsList.Count();
                    int counter = 0;
                    Panel p = new Panel();
                    Label t = new Label();
                    HyperLink le = new HyperLink();

                    Panel header = new Panel();
                    Panel content = new Panel();
                    Panel footer = new Panel();

                    Panel cal = new Panel();
                    Panel textcontent = new Panel();
                    Label texto2 = new Label();

                    while (counter < totalEvents)
                    {
                        string id = eventsList[counter].Id.ToString();
                        p = new Panel();
                        t = new Label();
                        Label t2 = new Label();
                        Label t3 = new Label();
                        le = new HyperLink();
                        ImageButton removeButton = new ImageButton();

                        p.ID = "panel" + id;
                        t.ID = "t" + id;
                        le.ID = "le" + id;

                        t3.Text = "<BR><BR>" + eventsList[counter].Date.ToString();
                        t2.Text = "<BR>" + eventsList[counter].Description.ToString() + "<BR><BR>";
                        t.Text = eventsList[counter].Location.ToString() + "<BR>";
                        t.CssClass = "cal_location";
                        t2.CssClass = "cal_description";
                        t3.CssClass = "cal_date";

                        removeButton.ToolTip = "Remove";
                        removeButton.ImageUrl = "../Images/deleteButton.png";
                        removeButton.PostBackUrl = "~/Asp_forms/RemoveUserFromEvents.aspx?ID=" + eventsList[counter].Id;
                        removeButton.Width = 20;


                        header = new Panel();
                        content = new Panel();
                        footer = new Panel();

                        cal = new Panel();
                        textcontent = new Panel();

                        texto2 = new Label();

                        header.ID = "header" + id;
                        content.ID = "content" + id;
                        footer.ID = "footer" + id;
                        cal.ID = "cal" + id;


                        footer.CssClass = "calfooter";
                        header.CssClass = "calheader";
                        header.HorizontalAlign = HorizontalAlign.Center;
                        content.CssClass = "calcontent";
                        textcontent.CssClass = "caldefault";
                        cal.CssClass = "cal";
                        content.BackColor = System.Drawing.Color.White;

                        header.Height = 82;
                        header.Width = 300;
                        footer.Height = 50;

                        header.Controls.Add(t3);
                        textcontent.Controls.Add(t);
                        textcontent.Controls.Add(t2);
                        textcontent.Controls.Add(le);
                        textcontent.Controls.Add(removeButton);

                        content.Controls.Add(textcontent);

                        cal.Controls.Add(header);
                        cal.Controls.Add(content);
                        cal.Controls.Add(footer);

                        cal.Width = 300;

                        Panel2.Controls.Add(cal);

                        counter++;
                    }
                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
                }
            }
        }
    }
}