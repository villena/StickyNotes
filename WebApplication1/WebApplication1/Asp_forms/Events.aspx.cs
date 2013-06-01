using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Events_Class event = new Events_Class();

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

                    //--------------------------
                    //NO BORRAR DECLARACIONES

                    Panel header = new Panel();
                    Panel content = new Panel();
                    Panel footer = new Panel();

                    Panel cal = new Panel();
                    Panel textcontent = new Panel();
                    Label texto2 = new Label();
                    //-----

                  /*
                    footer.CssClass = "calfooter";
                    header.CssClass = "calheader";
                    content.CssClass = "calcontent";
                    textcontent.CssClass = "caldefault";
                    content.BackColor = System.Drawing.Color.White;

                    header.Height = 82;
                    header.Width = 300;
                    footer.Height = 50;

                  

                    Label texto = new Label();
                    texto.Text = "Evento nuevo";
                    
                    texto2.Text = "Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2";
                    Label texto3 = new Label();
                    texto3.Text = "Evento nuevo2";
                    //header.Controls.Add(texto);
                    textcontent.Controls.Add(texto2);
                    //footer.Controls.Add(texto3);

                    content.Controls.Add(textcontent);

                    cal.Controls.Add(header);
                    cal.Controls.Add(content);
                    cal.Controls.Add(footer);

                    cal.Width=300;
                    cal.Height = 500;

                    Panel2.Controls.Add(cal);*/
                    //Panel2.Controls.Add(header);


                    //-----------------------------

                    while (counter < totalEvents)
                    {
                        string id = eventsList[counter].Id.ToString();
                        p = new Panel();
                        t = new Label();
                        le = new HyperLink();

                        p.ID = "panel" + id;
                        t.ID = "t" + id;
                        le.ID = "le" + id;

                        t.Text = "<BR>" + eventsList[counter].ToString() + "<BR>";
                        le.Text = "REMOVE";
                        le.NavigateUrl = "~/Asp_forms/RemoveUserFromEvents.aspx?ID=" + eventsList[counter].Id;

                       // p.Controls.Add(t);
                        //p.Controls.Add(le);
                        //Panel2.Controls.Add(p);


                        //--------------------------

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
                        content.CssClass = "calcontent";
                        textcontent.CssClass = "caldefault";
                        cal.CssClass = "cal";
                        content.BackColor = System.Drawing.Color.White;

                        header.Height = 82;
                        header.Width = 300;
                        footer.Height = 50;

                        textcontent.Controls.Add(t);
                        textcontent.Controls.Add(le);

                        
                       // texto2 = new Label();
                       // texto2.Text = "Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2 Evento nuevo 2";
                       
                        //header.Controls.Add(texto);
                        //textcontent.Controls.Add(texto2);
                        //footer.Controls.Add(texto3);

                        content.Controls.Add(textcontent);

                        cal.Controls.Add(header);
                        cal.Controls.Add(content);
                        cal.Controls.Add(footer);

                        cal.Width = 300;
                       // cal.Height = 500;

                        Panel2.Controls.Add(cal);
                        //Panel2.Controls.Add(header);

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