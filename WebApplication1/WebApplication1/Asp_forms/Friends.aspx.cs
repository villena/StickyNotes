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
                if (Request.QueryString["all"] == "yes") RadioButtonList1.Items[1].Selected = true;
                else RadioButtonList1.Items[0].Selected = true;
                User_Class usuario_sesion = new User_Class();
                usuario_sesion = usuario_sesion.getUser(userCookie.Value);

                if(RadioButtonList1.Text == "Only my friends") {
                    List<User_Class> lista = new List<User_Class>();
                    usuario_sesion.getFriends();

                    if (Request.QueryString["cadena"] != null)
                    {
                        lista = filterFriends(Request.QueryString["cadena"], usuario_sesion.Friends);
                    }
                    else
                    {
                        lista = usuario_sesion.Friends;
                    }

                    if (lista.Count() == 0)
                    {
                        Label label = new Label();
                        label.Attributes.Add("style", "float:center; margin-left:50px;");
                        label.ID = "LabelX";
                        label.Text = "<h2> No friends found! </h2>";
                        Panel2.Controls.Add(label);
                    }

                    for (int j = 0; j < lista.Count(); j++)
                    {
                        Panel p = createPanel();
                        Panel2.Controls.Add(p);
                        p.Controls.Add(createImage(lista.ElementAt(j).Image_url));
                        p.Controls.Add(createLabel(lista.ElementAt(j).Name));
                        p.Controls.Add(createPrfButton(lista.ElementAt(j).Id));
                        p.Controls.Add(createDelButton(lista.ElementAt(j).Id));
                    }
                }

                else if (RadioButtonList1.Text == "All Users")
                {
                    List<User_Class> lista = new List<User_Class>();
                    if (Request.QueryString["cadena"] != null)
                    {
                        lista = filterFriends(Request.QueryString["cadena"], usuario_sesion.getAllUser());
                    }
                    else
                    {
                        lista = usuario_sesion.getAllUser();
                    }

                    for (int j = 0; j < lista.Count(); j++)
                    {
                        Panel p = createPanel();
                        Panel2.Controls.Add(p);
                        p.Controls.Add(createImage(lista.ElementAt(j).Image_url));
                        p.Controls.Add(createLabel(lista.ElementAt(j).Name));

                        if (usuario_sesion.isFriend(lista.ElementAt(j).Id))
                        {
                            p.Controls.Add(createPrfButton(lista.ElementAt(j).Id));
                        }

                        if (!usuario_sesion.isFriend(lista.ElementAt(j).Id))
                        {
                            p.Controls.Add(createAddButton(lista.ElementAt(j).Id));
                        }
                        else
                        {
                            p.Controls.Add(createDelButton(lista.ElementAt(j).Id));
                        }
                    }
                }
            }
        }

        protected Label createLabel(string name)
        {
            Label label = new Label();
            label.Attributes.Add("style", "clear:both; margin-left:50px;");
            label.Text = name + "<br />";

            return label;
        }

        protected Panel createPanel()
        {
            Panel p = new Panel();
            p.CssClass = "postit";
            p.Height = 100;

            return p;
        }

        protected Image createImage(string image_url)
        {
            Image i = new Image();
            i.Attributes.Add("style", "float:left; max-width: auto; max-height: 75px; border: 5px groove brown;");
            i.ImageUrl = image_url;

            return i;
        }

        protected Button createAddButton(int id)
        {
            Button add = new Button();
            add.Text = "Add Friend";
            add.Attributes.Add("style", "float:right; clear:left;");
            add.PostBackUrl = "../Aux_asp_forms/User_Added.aspx?id=" + id.ToString();

            return add;
        }

        protected Button createDelButton(int id)
        {
            Button del = new Button();
            del.Text = "Delete Friend";
            del.Attributes.Add("style", "float:right; clear:left;");
            del.PostBackUrl = "../Aux_asp_forms/User_Deleted.aspx?id=" + id.ToString();

            return del;
        }

        protected Button createPrfButton(int id)
        {
            Button profile = new Button();
            profile.Text = "Ver Perfil";
            profile.Attributes.Add("style", "float:right; clear:both;");
            profile.PostBackUrl = "../Aux_asp_forms/Friend_Profile.aspx?id=" + id.ToString();

            return profile;
        }

        protected List<User_Class> filterFriends(string string_comp, List<User_Class> lista)
        {
            List<User_Class> resultado = new List<User_Class>();
            for (int i = 0; i < lista.Count(); i++)
            {
                string cadena_comp;
                cadena_comp = lista.ElementAt(i).Name + " " + lista.ElementAt(i).Surname +
                    " " + lista.ElementAt(i).Nick;
                if (cadena_comp.Contains(string_comp)) resultado.Add(lista.ElementAt(i));
            }

            return resultado;
        }

        protected void SearchFriend(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[1].Selected)
            {
                Response.Redirect("./Friends.aspx?all=yes&cadena=" + TextBox3.Text);
            }
            else
            {
                Response.Redirect("./Friends.aspx?all=no&cadena=" + TextBox3.Text);
            }
        }

        protected void SearchAll(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[1].Selected)
            {
                Response.Redirect("./Friends.aspx?all=yes&cadena=");
            }
            else
            {
                Response.Redirect("./Friends.aspx?all=no&cadena=");
            }
        }
    }
}