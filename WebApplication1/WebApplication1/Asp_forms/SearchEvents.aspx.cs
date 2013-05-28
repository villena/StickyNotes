using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class SearchEvents : System.Web.UI.Page
    {
        Events_Class auxiliar = new Events_Class();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Events_Class event = new Events_Class();

            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];

            if (userCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {

            }
        }

        protected void Search(object sender, EventArgs e)
        {
            Events_Class events = new Events_Class();
            List<Events_Class> eventsList = new List<Events_Class>();

            eventsList = events.searchEvents(TextBox1.Text);

            int totalEvents = eventsList.Count();
            int counter = 0;
            Panel p = new Panel();
            Label t = new Label();
            HyperLink le = new HyperLink();

            while (counter < totalEvents)
            {
                string id = eventsList[counter].Id.ToString();
                p = new Panel();
                t = new Label();
                le = new HyperLink();

                p.ID = "panel" + id;
                t.ID = "t" + id;
                le.ID = "le" + id;

                t.Text = eventsList[counter].ToString()+ "<BR>";
                le.Text = "ADD";

                le.NavigateUrl = "~/Asp_forms/AddToEvents.aspx?ID=" + eventsList[counter].Id;

                p.Controls.Add(t);
                p.Controls.Add(le);
                Panel2.Controls.Add(p);

                counter++;
            }
        }

        protected void ShowAll(object sender, EventArgs e)
        {
            Events_Class events = new Events_Class();
            List<Events_Class> eventsList = new List<Events_Class>();

            eventsList = events.searchEvents("");

            int totalEvents = eventsList.Count();
            int counter = 0;
            Panel p = new Panel();
            Label t = new Label();
            HyperLink le = new HyperLink();

            while (counter < totalEvents)
            {
                string id = eventsList[counter].Id.ToString();
                p = new Panel();
                t = new Label();
                le = new HyperLink();

                p.ID = "panel" + id;
                t.ID = "t" + id;
                le.ID = "le" + id;

                t.Text = eventsList[counter].ToString() + "<BR>";
                le.Text = "ADD";

                le.NavigateUrl = "~/Asp_forms/AddToEvents.aspx?ID=" + eventsList[counter].Id;

                p.Controls.Add(t);
                p.Controls.Add(le);
                Panel2.Controls.Add(p);

                counter++;
            }
        }
    }
}