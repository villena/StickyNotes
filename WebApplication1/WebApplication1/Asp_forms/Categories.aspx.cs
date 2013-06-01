using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;


namespace WebApplication1
{
    public partial class Formulario_web12 : System.Web.UI.Page
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

                    List<Category_Class> lista = new List<Category_Class>();
                    Category_Class category = new Category_Class();

                    if (Request.QueryString["cadena"] != null)
                        lista = filterCategories(Request.QueryString["cadena"], category.Categories());
                    else
                        lista = category.Categories();

                    if (lista.Count() == 0)
                    {
                        Label label = new Label();
                        label.Attributes.Add("style", "float:center; margin-left:50px;");
                        label.ID = "LabelX";
                        label.Text = "<h2> No categories found! </h2>";
                        Panel2.Controls.Add(label);
                    }

                    for (int j = 0; j < lista.Count(); j++)
                    {
                        Panel p = createPanel();
                        p.Controls.Add(createLabel(lista.ElementAt(j).Nombre));
                        p.Controls.Add(createNotesButton(lista.ElementAt(j).Id));
                        Panel2.Controls.Add(p);

                    }
                }
                else
                {
                    Response.Redirect("../Account/Login.aspx");
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
            p.CssClass = "postitnotes";

            return p;
        }

        protected Button createNotesButton(int id)
        {
            Button profile = new Button();
            profile.Text = "Notes";
            profile.Attributes.Add("style", "float:right; clear:both;");
            profile.PostBackUrl = "Category_Notes.aspx?id=" + id.ToString();

            return profile;
        }

        protected List<Category_Class> filterCategories(string string_comp, List<Category_Class> lista)
        {
            List<Category_Class> resultado = new List<Category_Class>();
            for (int i = 0; i < lista.Count(); i++)
            {
                string cadena_comp;
                cadena_comp = lista.ElementAt(i).Nombre;
                if (cadena_comp.Contains(string_comp)) resultado.Add(lista.ElementAt(i));
            }

            return resultado;
        }

        protected void searchCategory(object sender, EventArgs e)
        {
            Response.Redirect("./Categories.aspx?cadena=" + SearchBox.Text);
        }
    }
}