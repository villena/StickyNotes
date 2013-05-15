using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
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
                User_Class usuario_sesion = new User_Class();
                usuario_sesion = usuario_sesion.getUser(userCookie.Value);

                if(RadioButtonList1.SelectedItem.Text == "Only my friends") {
                    usuario_sesion.getFriends();

                    if (usuario_sesion.Friends.Count() == 0)
                    {
                        Label label = new Label();
                        label.Attributes.Add("style", "float:center; margin-left:50px;");
                        label.ID = "LabelX";
                        label.Text = "<h2> No friends found! </h2>";
                        Panel2.Controls.Add(label);
                    }

                    for (int j = 0; j < usuario_sesion.Friends.Count(); j++)
                    {
                        Panel p = new Panel();
                        p.CssClass = "postit";
                        p.Height = 100;
                        p.ID = "panelF" + j;
                        Panel2.Controls.Add(p);

                        Image i = new Image();
                        i.Attributes.Add("style", "float:left; max-width: auto; max-height: 75px; border: 5px groove brown;");
                        i.ID = "ImageF" + j;
                        i.ImageUrl = usuario_sesion.Friends.ElementAt(j).Image_url.ToString();
                        p.Controls.Add(i);

                        Label label = new Label();
                        label.Attributes.Add("style", "clear:both; margin-left:50px;");
                        label.ID = "LabelF" + j;
                        label.Text = usuario_sesion.Friends.ElementAt(j).Name + "<br />";
                        p.Controls.Add(label);

                        Button profile = new Button();
                        profile.ID = "ButtonP" + j;
                        profile.Text = "Ver Perfil";
                        profile.Attributes.Add("style", "margin-left:400px");
                        profile.PostBackUrl = "../Aux_asp_forms/Friend_Profile.aspx?id="+usuario_sesion.Friends.ElementAt(j).Id.ToString();
                        p.Controls.Add(profile);

                        Button del = new Button();
                        del.ID = "ButtonD" + j;
                        del.Text = "Delete Friend";
                        del.Attributes.Add("style", "margin-left:400px");
                        del.PostBackUrl = "../Aux_asp_forms/User_Deleted.aspx?id=" + usuario_sesion.Friends.ElementAt(j).Id.ToString();

                        p.Controls.Add(del);
                    }
                }

                else if (RadioButtonList1.SelectedItem.Text == "All Users")
                {
                    List<User_Class> lista = new List<User_Class>();
                    lista = usuario_sesion.getAllUser();

                    for (int j = 0; j < lista.Count(); j++)
                    {
                        Panel p = new Panel();
                        p.CssClass = "postit";
                        p.Height = 100;
                        p.ID = "panelF" + j;
                        Panel2.Controls.Add(p);

                        Image i = new Image();
                        i.Attributes.Add("style", "float:left; max-width: auto; max-height: 75px; border: 5px groove brown;");
                        i.ID = "ImageF" + j;
                        i.ImageUrl = lista.ElementAt(j).Image_url;
                        p.Controls.Add(i);

                        Label label = new Label();
                        label.Attributes.Add("style", "clear:both; margin-left:50px;");
                        label.ID = "LabelF" + j;
                        label.Text = lista.ElementAt(j).Name + "<br />";
                        p.Controls.Add(label);

                        if (usuario_sesion.isFriend(lista.ElementAt(j).Id))
                        {
                            Button profile = new Button();
                            profile.ID = "ButtonP" + j;
                            profile.Text = "Ver Perfil";
                            profile.Attributes.Add("style", "margin-left:400px");
                            profile.PostBackUrl = "../Aux_asp_forms/Friend_Profile.aspx?id=" + lista.ElementAt(j).Id.ToString();
                            p.Controls.Add(profile);
                        }

                        if (!usuario_sesion.isFriend(lista.ElementAt(j).Id))
                        {
                            Button add = new Button();
                            add.ID = "ButtonA" + j;
                            add.Text = "Add Friend";
                            add.Attributes.Add("style", "margin-left:400px");
                            add.PostBackUrl = "../Aux_asp_forms/User_Added.aspx?id=" + lista.ElementAt(j).Id.ToString();

                            p.Controls.Add(add);
                        }
                        else
                        {
                            Button del = new Button();
                            del.ID = "ButtonD" + j;
                            del.Text = "Delete Friend";
                            del.Attributes.Add("style", "margin-left:400px");
                            del.PostBackUrl = "../Aux_asp_forms/User_Deleted.aspx?id=" + lista.ElementAt(j).Id.ToString();

                            p.Controls.Add(del);
                        }
                    }
                }
            }
        }
    }
}